﻿using System;
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
        private static readonly TcpConnection TcpConnection = new TcpConnection();
        private static readonly string Ipaddress = "127.0.0.1";
        private const int Port = 1698;

        private int _xclick, _yclick;
        readonly Font _font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);

        private List<Product> _products;
        private List<Family> _families;
        private List<VirtualBidder> _virtualBidders;

        private User _player;

        //private int initialMinutes =0, initialSeconds = 15;
        //private int predeterminatedMinutes, predeterminatedSeconds;
        //private int seconds, minutes;

        //private int _currentProductIndex;
        //private Product _currentProduct;

        //private decimal _lastOffert;
        //private int _roundActivity;
        //private int _round;

        //private int _currentWinner;

        //private bool _activeAuction;

        //private string log;

        //private bool firstBidd = true;

        private string _namePlayer;

        public FrmGame(string namePlayer)
        {
            InitializeComponent();
            _namePlayer = namePlayer;
        }

        private void pboxCloseForm_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            TcpConnection.OnDataRecieved += MensajeRecibido;

            if (TcpConnection.Connectar(Ipaddress, Port))
            {
                var package = new Package("newUser", _namePlayer);
                TcpConnection.EnviarPaquete(package);
            }
            else
            {
                MessageBox.Show(@"¡Error conectando con el servidor! ");
                this.Close();
            }

        }
        private void MensajeRecibido(string datos)
        {
            var paquete = new Package(datos);
            var comando = paquete.Command;
            if (comando == "connectionResultOk") //Se recibe información del juego idUser|idRutina|tiempoInicial
            {
                var contenido = paquete.Content;
                var values = Map.Deserialize(contenido);
                _player = User.GetUserById(int.Parse(values[0]));
                var routine = Routine.GetRoutineById(int.Parse(values[1]));
                _products = routine.AllProducts;
                _families = routine.Families;
                _virtualBidders = routine.VirtualBidders;
                var time = new Time(values[2], "ss");


                Invoke(new Action(() =>
                {
                    _player.Wallet = decimal.Parse(values[2]);
                    lblPlayerName.Text = _player.NameBidder;
                    lblMoney.Text = _player.Wallet.ToString(CultureInfo.InvariantCulture);
                    txbClock.Text = time.Format("mm:ss");
                    LoadProducts();
                    LoadFamilies();
                }));
            }
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
                    Font = _font,
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
                Font = _font,
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
            { _xclick = e.X; _yclick = e.Y; }
            else
            {
                Left += (e.X - _xclick);
                Top += (e.Y - _yclick);
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
                        _player.ProductsEarned.Add(_currentProduct);
                        VerifyFamiliesEarned();
                        _player.Wallet = _player.Wallet - _player.Offert;// se le descuenta de su cartera el monto ofertado
                        _player.Points += _currentProduct.Points;
                        lblPoints.Text = _player.Points.ToString();
                        lblMoney.Text = _player.Wallet.ToString();
                        _player.Statistics.BidWin++;
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
                    lblRoundNumber.Text = _round.ToString();
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
        }
        private void VerifyFamiliesEarned()
        {
            foreach (var family in _families)
            {
                int productsEarnedCount = 0;
                foreach (var productEarned in  _player.ProductsEarned)
                {
                    foreach (var productNeccesary in family.Products)
                    {
                        if (productNeccesary.Equals(productEarned))
                            productsEarnedCount++;
                    }
                }
                if (productsEarnedCount == family.Products.Count)
                {
                    MessageBox.Show($"Ganaste {family.Points} puntos por haber completado los productos de la familia {family.NameFamily}");
                    _player.Points += family.Points;
                    lblPoints.Text = _player.Points.ToString();
                }
            }
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            finishGame();
        }

        private void pboxIncreaseValueOffer_Click(object sender, EventArgs e)
        {
            var currentValue = int.Parse(txbIncreaseOffert.Text);
            currentValue++;
            if (currentValue < 10)
                txbIncreaseOffert.Text = "00" + currentValue;
            else if(currentValue < 100)
                txbIncreaseOffert.Text = "0" + currentValue;
            else
                txbIncreaseOffert.Text = currentValue.ToString();
        }
        private void pboxDecrementValueOffer_Click(object sender, EventArgs e)
        {
            var currentValue = int.Parse(txbIncreaseOffert.Text);
            currentValue--;
            if (currentValue < 10)
                txbIncreaseOffert.Text = "00" + currentValue;
            else if (currentValue < 100)
                txbIncreaseOffert.Text = "0" + currentValue;
            else
                txbIncreaseOffert.Text = currentValue.ToString();
        }

        private void pboxIncreaseBid_Click(object sender, EventArgs e)
        {
            var currentValue = int.Parse(txbOffer.Text);
            var increase = int.Parse(txbIncreaseOffert.Text);
            currentValue+=increase;
            if (currentValue < 10)
                txbOffer.Text = "00" + currentValue;
            else if (currentValue < 100)
                txbOffer.Text = "0" + currentValue;
            else
                txbOffer.Text = currentValue.ToString();
        }

        private void pboDecrementBid_Click(object sender, EventArgs e)
        {
            var currentValue = int.Parse(txbOffer.Text);
            if (currentValue == 0) return;
            currentValue--;
            if (currentValue < 10)
                txbOffer.Text = "00" + currentValue;
            else if (currentValue < 100)
                txbOffer.Text = "0" + currentValue;
            else
                txbOffer.Text = currentValue.ToString();
        }

        private void pboxBid_Click(object sender, EventArgs e)
        {
            if (!_activeAuction) return;
            var newOffer = decimal.Parse(txbOffer.Text);
            var increase = newOffer - _lastOffert;
            if (newOffer > _lastOffert && newOffer <= _player.Wallet && _player.OutBidder == false)
            {
                TimeSpan timeBetweenBidd = DateTime.Now - _player.LastBiddTime;
                _player.LastBiddTime = DateTime.Now;
                int secondsBetweenBidd = timeBetweenBidd.Seconds;

                //se le asigna el valor del campo TxtBoxValueOffert a la variable My ofert
                _player.Offert = newOffer;//Int32.Parse(TxtBoxValueOffert.Text);

                txbLastOfferPlayer.Text = _player.Offert.ToString();//se cambia el dato de mi ultima oferta en el campo de texto de la barra de estadisticas

                //se cambian los valores del campo de ultima oferta

                UpdateBid(_player);


                _player.UpdateParticipation();// se actualiza la participacion del jugador

                _player.Statistics.AddIncreaseForBidd(increase);
                _player.Statistics.AddSecondsBetweenBidd(secondsBetweenBidd);
            }
        }

        private void finishGame()
        {
            //foreach(var vb in _virtualBidders)
            //{
            //    vb.Hilo.Abort();
            //}
            //_player.Statistics.Points = _player.Bidder.Points;
            //_player.Statistics.Wallet = _player.Bidder.Wallet;
            //_player.Statistics.Log = log;
            //_player.Statistics.Results();
        }

        private void UpdateBid(Bidder bidder)
        {
            _currentWinner = bidder.IdBidder;
            _lastOffert = bidder.Offert;
            if (txbLastOffer.InvokeRequired)
            {
                txbLastOffer.Invoke(new MethodInvoker(delegate
                {
                    txbLastOffer.Text = _lastOffert.ToString();
                }));
            }
            else
            {
                txbLastOffer.Text = _lastOffert.ToString();
            }
            if (txbCurrentWinner.InvokeRequired)
            {
                txbCurrentWinner.Invoke(new MethodInvoker(delegate
                {
                    txbCurrentWinner.Text = _currentWinner.ToString();
                }));
            }
            else
            {
                txbCurrentWinner.Text = _currentWinner.ToString();
            }
            _roundActivity++;
            string newPuja = bidder.IdBidder + " : " + _lastOffert + "\n";
            addText(newPuja, Color.Red, true);

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
