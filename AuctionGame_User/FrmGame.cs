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
        private static readonly TcpConnection TcpConnection = new TcpConnection();
        private static readonly string Ipaddress = "127.0.0.1";
        private const int Port = 1698;

        private int _xclick, _yclick;
        readonly Font _font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);

        private List<Product> _products;
        private List<Family> _families;
        private List<VirtualBidder> _virtualBidders;

        private User _player;


        private readonly string _namePlayer;

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
                var package = new Package("newConnection", _namePlayer);
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
            var package = new Package(datos);
            var command = package.Command;
            switch (command)
            {
                case "connectionResult":
                    ConnectionResult(package.Content);
                    break;
                case "bidResult":
                    BidResult(package.Content);
                    break;
                case "newAuction":
                    NewAuctionUpdate(package.Content);
                    break;
                case "updateBidd":
                {
                    var values = Map.Deserialize(package.Content);
                    Invoke(new Action(() =>
                    {
                        txbCurrentWinner.Text = values[0];
                        txbLastOffer.Text = values[1];
                    }));
                    break;
                }
                case "updateClock":
                    UpdateClock(package.Content);
                    break;
                case "auctionFinished":
                    AuctionFinished(package.Content);
                    break;

                default: 
                    Console.WriteLine($@"Mensaje con comando desconocido: {command}");
                    break;
            }
        }

        private void ConnectionResult(string content)
        {
            var values = Map.Deserialize(content);
            var result = bool.Parse(values[0]);
            if (result)
            {
                _player = User.GetUserById(int.Parse(values[1]));
                var routine = Routine.GetRoutineById(int.Parse(values[2]));
                _products = routine.AllProducts;
                _families = routine.Families;
                _virtualBidders = routine.VirtualBidders;
                var time = new Time(values[3], "ss");


                Invoke(new Action(() =>
                {
                    lblPlayerName.Text = _player.NameBidder;
                    lblMoneyUser.Text = _player.Wallet.ToString(CultureInfo.InvariantCulture);
                    txbClock.Text = time.Format("mm:ss");
                    LoadProducts();
                    LoadFamilies();
                }));
            }
            else
            {
                MessageBox.Show($@"El servidor rechazó la conexión: {values[1]}");
                Environment.Exit(0);
            }
        }

        private void BidResult(string content)
        {
            var values = Map.Deserialize(content);
            var result = bool.Parse(values[0]);
            if (result)
            {
                Invoke(new Action(() =>
                {
                    txbLastOfferPlayer.Text = txbLastOffer.Text = values[1];
                    txbCurrentWinner.Text = _player.IdBidder.ToString();
                }));
            }
            else
            {
                MessageBox.Show($@"La oferta fue rechazada: {values[1]}");
            }
        }

        private void NewAuctionUpdate(string content)
        {
            var values = Map.Deserialize(content);
            var product = Product.GetProductById(int.Parse(values[1]));

            Invoke(new Action(() =>
            {
                lblAuctionNumber.Text = values[0];
                lblRoundNumber.Text = @"1";
                lblCurrentNameProduct.Text = product.Name;
                lblCurrentPriceProduct.Text = product.Price.ToString(CultureInfo.InvariantCulture);
                lblCurrentPointsProduct.Text = product.Points.ToString(CultureInfo.InvariantCulture);
                pboxCurrentProduct.Image = product.ImageProduct;
                txbCurrentWinner.Text = @"-";
                txbLastOffer.Text = @"000";
            }));
        }

        private void UpdateClock(string content)
        {
            var values = Map.Deserialize(content);
            Invoke( new Action(() => { txbClock.Text = values[0]; }));
        }

        private void AuctionFinished(string content)
        {
            var values = Map.Deserialize(content);
            var result = bool.Parse(values[0]);
            if (result)
            {
                MessageBox.Show(@"¡Has ganado la subasta!");
                Invoke(new Action(() =>
                {
                    lblPointsUser.Text = values[1];
                    lblMoneyUser.Text = values[2];
                }));
            }
            else
            {
                MessageBox.Show(@"Has perdido la subasta");
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

        private void pboxDecrementBid_Click(object sender, EventArgs e)
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

            //if (!_activeAuction) return;

            var newOffer = decimal.Parse(txbOffer.Text);
            var package = new Package("newBid", newOffer.ToString(CultureInfo.InvariantCulture));
            TcpConnection.EnviarPaquete(package);
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
