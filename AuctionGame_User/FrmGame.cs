using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class FrmGame : Form
    {
        public int Xclick, Yclick;
        Font font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);

        private List<Product> _products;
        private List<Family> _families;
        private List<VirtualBidder> _virtualBidders;

        private Bidder _player;

        private int initialMinutes = 1, initialSeconds = 0;
        private int predeterminatedMinutes, predeterminatedSeconds;
        private int seconds, minutes;

        private int _currentProductIndex;
        private Product _curretnProduct;

        private decimal _lastOffert;
        private int _roundActivity;
        private int _round;

        private int _currentWinner;

        private bool _activeAuction;

        private string log;


        public FrmGame()
        {
            InitializeComponent();
            _products = Product.GetAllProducts();
            _families = Family.GetAllFamilies();
            _virtualBidders = VirtualBidder.GetAllVirtualBidders(null);
            _player = new Bidder();
        }

        private void pboxCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadFamilies();
        }
        private void AddProductsToPanel(List<Product> products, Panel panel)
        {
            for (var index = products.Count - 1; index >= 0; index--)
            {
                var product = products[index];

                var nameProduct = new Label()
                {
                    Text = $@"{product.Name}",
                    Dock = DockStyle.Top,
                    AutoSize = false,
                    Height = 60,
                    TextAlign = ContentAlignment.BottomCenter,
                    BackColor = Color.Transparent,
                    Font = font,
                    ForeColor = Color.Azure
                };
                var pbox = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Image = product.ImageProduct,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    Height = 170,
                    Tag = new object[] { product, nameProduct }
                };
                pbox.Click += Pbox_Click;

                var o = new Control[]
                {
                    pbox, nameProduct
                };
                panel.Controls.AddRange(o);
            }
        }
        private void LoadProducts()
        {
            AddProductsToPanel(_products, pnlProducts);
            pnlProducts.Controls.Add(new Label()
            {
                Text = $@"Productos",
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Font = font,
                ForeColor = Color.Yellow
            });
            pnlProducts.VerticalScroll.Visible = false;
        }
        private void LoadFamilies()
        {
            var font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);

            for (var index = _families.Count - 1; index >= 0; index--)
            {
                var family = _families[index];

                var btnFamily = new Button()
                {
                    Text = $@"{family.NameFamily}",
                    Dock = DockStyle.Top,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(29, 53, 80),
                    ForeColor = Color.Azure,
                    FlatStyle = FlatStyle.Flat,
                    Tag = family
                };
                btnFamily.Click += btnFamily_Click;

                var o = new Control[]
                {
                    btnFamily
                };
                pnlFamilies.Controls.AddRange(o);
            }
            pnlFamilies.Controls.Add(new Label()
            {
                Text = $@"Familias",
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Font = font,
                ForeColor = Color.Yellow
            });
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { Xclick = e.X; Yclick = e.Y; }
            else
            {
                Left += (e.X - Xclick);
                Top += (e.Y - Yclick);
            }
        }


        private void pboxClose_Click(object sender, EventArgs e)
        {
            if(((PictureBox)sender).Tag != null)
            {
                pnlProductsByFamily.Visible = false;
                return;
            }
            pnlProductInformation.Visible = false;
        }

        protected virtual void Pbox_Click(object o, EventArgs e)
        {
            var pbox = (PictureBox)o;
            var lbl = (Label)((object[])pbox.Tag)[1];
            lbl.ForeColor = Color.Red;
            var product = (Product)((object[])pbox.Tag)[0];
            lblNameProduct.Text = product.Name;
            lblInitialPrice.Text = product.Price.ToString(CultureInfo.CurrentCulture);
            lblPointsProduct.Text = product.Points.ToString();
            pboxProduct.Image = product.ImageProduct;
            pnlProductInformation.Visible = true;
        }

        private void pboxPlay_Click(object sender, EventArgs e)
        {
            using (Semaphore semaphore = new Semaphore(1, 1, "Semaphore"))
            {
                if (_virtualBidders != null)
                    foreach (var vb in _virtualBidders)
                    {
                        Thread thread = new Thread(() => ManagerBidder(vb));
                        vb.Hilo = thread;
                        vb.Hilo.Start();
                    }
                nextBid();
            }
            //pb.Visible = false;
        }
        private void nextBid()
        {
            if (_products.Count > 0 && _currentProductIndex < _products.Count)
            {
                txbClock.BackColor = Color.Green;
                seconds = predeterminatedSeconds = initialSeconds;
                minutes = predeterminatedMinutes = initialMinutes;
                //Selecciona el siguiente producto
                _curretnProduct = _products.ElementAt(_currentProductIndex);
                _currentProductIndex++;
                pboxCurrentProduct.Image = _curretnProduct.ImageProduct;
                _lastOffert = _curretnProduct.Price; //variables para modificar los datos de la barra de estadisticas
                _roundActivity = 0; //numero de ofertas en una ronda
                _round = 1; //numero de ronda actual
                txbLastOffer.Text = _curretnProduct.Price.ToString();
                lblCurrentNameProduct.Text = _curretnProduct.Name;
                addText($"Inicia subasta por ", Color.Black, true);
                addText(_curretnProduct.Name, Color.Red, false);
                addText($"\nPrecio Inicial ", Color.Black, false);
                addText(_curretnProduct.Price.ToString(), Color.Red, false);
                addText($"\nInicia Round 1\n", Color.Black, false);

                _currentWinner = 0;
                if (_virtualBidders != null)
                    foreach (VirtualBidder vb in _virtualBidders)
                    {
                        vb.OutBidder = false;
                        vb.Offert = 0;
                        vb.ParticipationsRound = 0;
                        vb.Rounds = 0;
                    }
                _activeAuction = true;
                timerAuction.Start();
                _player.ParticipationsRound = 0;
                _player.OutBidder = false;
                _player.Rounds = 0;
                _player.Offert = 0;
                _player.LastBiddTime = DateTime.Now;

            }
            else
            {
                MessageBox.Show("Ya no existen productos por subastar");
                _activeAuction = false;
                finishGame();
            }
        }

        private void timerAuction_Tick(object sender, EventArgs e)
        {//funcion tick que se ejecuta aca intervalo de tiempo (la tenemos en 1000 = 1 segundo)
            // codigo para controlar el cronometro

            if (seconds == 0 && minutes == 0)//si minutos y segundos llegana 0 se detiene el cronometro
            {
                if (_roundActivity < 2) //Cuando la actividad de la ronda es menor a 2, termina la subasta 
                {
                    _player.Statistics.AddRoundsForBidd(_player.Rounds);
                    _player.Statistics.AddBiddForRound(_player.ParticipationsRound);



                    addText($"Termina subasta, gana {_currentWinner}. \n", Color.Blue, true);
                    timerAuction.Stop();//se detiene la variable tiempo
                    txbClock.BackColor = Color.Red;//cambia el color del reloj
                    if (_currentWinner == _player.IdBidder)//si el ganador es el jugador
                    {
                        //productsEarned.Add(_curretnProduct);
                        //familyUpdate();
                        //player.Wallet = player.Wallet - player.Offert;// se le descuenta de su cartera el monto ofertado
                        //player.Points += productoActual.points;
                        //txbPoints.Text = player.Points.ToString();
                        //txbMoney.Text = player.Wallet.ToString();
                        //player.statistics.bidWin++;
                        //ListViewItem item = lvwProductsForEarn.Items.Find(productoActual.id_product.ToString(), false)[0];
                       // item.BackColor = Color.Green;
                    }
                    else
                    {
                        //ListViewItem item = lvwProductsForEarn.Items.Find(productoActual.id_product.ToString(), false)[0];
                        //item.BackColor = Color.Red;
                    }
                    if (_virtualBidders != null)
                        for (int index = 0; index < _virtualBidders.Count(); index++) //for  para recorrer el array de bidders
                        {
                            var vb = _virtualBidders.ElementAt(index);
                            vb.OutBidder = false;//se cambia la variable bidder fuera a false para que continuen en la nueva subasta
                            if (vb.IdBidder == _currentWinner)//si el id del bidder es igual al registrado como ganador
                            {
                                //se le resta el monto de la offerta a su cartera
                                vb.Wallet -= vb.Offert;
                            }
                            vb.Hilo.Suspend();
                        }
                }
                else //Se inicia una nueva ronda
                {
                    addText($"Inicia ronda {_round + 1}\n", Color.Black, true);
                    foreach (var vb in _virtualBidders)
                    {
                        if (!vb.OutBidder)
                        {
                            vb.Role.OffertsForRound.GetNewFinallyValue();
                        }
                    }
                    _roundActivity = 0;// se inicializa la actividad en la ronda
                    _round++;//se aumenta el round
                    if (predeterminatedMinutes == 0)//si los minutos que se dan de manera predeterminada llegan a 0
                    {
                        if (predeterminatedSeconds > 20)//si los segundos que se dan de manera predeterminada son mas de 20
                        {
                            predeterminatedSeconds -= 10;//se van restando 10 segundos por ronda
                        }
                        else
                        {
                            predeterminatedSeconds = 15;//se limita a 15 segundos la ronda
                        }
                    }
                    else if (predeterminatedMinutes == 1)
                    {
                        predeterminatedMinutes--;
                        predeterminatedSeconds = 50;
                    }
                    else
                    {
                        predeterminatedMinutes--;//disminuyen los minutos que se dan de manera predeterminada
                    }
                    //se igualan los minutos y segundos a los predeterminados
                    minutes = predeterminatedMinutes;
                    seconds = predeterminatedSeconds;
                    //for para recalcular el tiempo de las apuestas
                    for (int index = 0; index < _virtualBidders.Count(); index++) //for  para recorrer el array de bidders
                    {
                        var vb = _virtualBidders.ElementAt(index);
                        if (vb.ParticipationsRound == 0)
                        {
                            vb.OutBidder = true;//SE CAMBIA LA VARIABLE DE BIDDER FUERA A TRUE
                        }
                        vb.ParticipationsRound = 0;//LA PARTICIPACIPON DE LA NUEVA RONDA SE CAMBIA A 0                    
                    }
                    //si el jugador no participo en la ronda anterior
                    if (_player.ParticipationsRound == 0)
                    {
                        _player.OutBidder = true;//queda fuera de la subasta
                    }
                    _player.Statistics.AddBiddForRound(_player.ParticipationsRound);
                    _player.ParticipationsRound = 0;
                }
            }
            else //Continua la ronda
            {
                //aumentar segundos
                seconds -= 1;
                //si los segundos son -1
                if (seconds == -1)
                {   //DISMINUYE 1 minutos
                    minutes -= 1;
                    //regresa a 59 segundos
                    seconds = 59;
                }
                var time = new Time(0, minutes, seconds);
                txbClock.Text = time.Format("mm:ss");

            }

            //cambiar etiqueta de tiempo lblClock
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            finishGame();
        }

        private void finishGame()
        {
            _player.Statistics.Points = _player.Points;
            _player.Statistics.Wallet = _player.Wallet;
            _player.Statistics.Log = log;
            _player.Statistics.Results();
        }
        private void addText(string text, Color color, bool hora)
        {
            /*rtxbPujas.SelectionStart = rtxbPujas.TextLength;
            rtxbPujas.SelectionColor = color;
            if (hora)
                rtxbPujas.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} -> {text} ");
            else
                rtxbPujas.AppendText($"{text}");
            rtxbPujas.ScrollToCaret();*/
            if (string.IsNullOrEmpty(log))
                log = "";
            if (hora)
               log += $"{DateTime.Now.ToString("HH:mm:ss")} -> {text} ";
            else
                log += $"{text}";
            Console.WriteLine(log);
        }
        private void ManagerBidder(VirtualBidder vb)
        {
            try
            {
                using (Semaphore semaphore = Semaphore.OpenExisting("Semaphore"))
                {
                    Thread.Sleep(vb.Role.TimeToBid.FinallyValue * 1000);

                    while (true)
                    {
                        if (!vb.OutBidder)//si el bidder no esta fuera
                        {
                            if (minutes != 0 || seconds != 0)
                            {
                                semaphore.WaitOne();
                                //aumenta el tamaño de size para pasar al siguiente bidder
                                if (vb.WantToBid(_lastOffert, _currentWinner, _round))// si cambia el ultimo apostador ganador se modifican las etiquetas
                                {
                                    _currentWinner = vb.IdBidder;//Cambia el bidder que por el momento es el ganador
                                    _lastOffert = vb.Offert;//cambia la ultima offerta

                                    /*if (rtxbPujas.InvokeRequired)
                                    {
                                        rtxbPujas.Invoke(new MethodInvoker(delegate
                                        {
                                            string newPuja = vb.Bidder_id + " : " + ultimateOffert + "\n";
                                            addText(newPuja, Color.Red, true);

                                            // rtxbPujas.SelectionColor = (rtxbPujas.ForeColor == Color.Red) ? Color.Blue :Color.Red;
                                        }));
                                    }*/
                                    string newPuja = vb.IdBidder + " : " + _lastOffert + "\n";
                                    addText(newPuja, Color.Red, true);
                                    _roundActivity++;//aumenta la actividad en la ronda
                                    Thread.Sleep(2000);//Le da un margen de 2 segundos entre jugadores para evitar el solapamiento
                                }
                                semaphore.Release();
                                Thread.Sleep(vb.Role.TimeToBid.NewFinallyValue() * 1000);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void btnFamily_Click(object o, EventArgs e)
        {
            var btn = (Button)o;
            var family = (Family)btn.Tag;
            pnlProductsByFamily.Controls.Clear();
            AddProductsToPanel(family.Products, pnlProductsByFamily);


            var pbox = new PictureBox
            {
                Image = Properties.Resources.proximo,
                Dock = DockStyle.Bottom,
                Size = new Size(30, 30),
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = pnlProductsByFamily
            };
            pbox.Click += pboxClose_Click;
            pnlProductsByFamily.Controls.Add(pbox);

            pnlProductsByFamily.Visible = true;
        }
    }
}
