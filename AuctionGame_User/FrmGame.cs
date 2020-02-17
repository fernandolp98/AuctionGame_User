using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class FrmGame : Form
    {
        public int Xclick, Yclick;
        private Time _time = new Time(0,0,60);

        private List<Product> _products;

        public FrmGame()
        {
            InitializeComponent();
            _products = Product.GetAllProducts();
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            var font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);
            for (var index = _products.Count - 1; index >= 0; index--)
            {
                var product = _products[index];

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
                pbox.Click += Pbox_Clic;

                var o = new Control[]
                {
                    pbox, nameProduct
                };
                pnlProducts.Controls.AddRange(o);
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            txbTime.Text = _time.Format("mm:ss");
            _time = new Time(_time.GetSeconds() - 1, "ss");
        }

        private void pboxCloseProductInformation_Click(object sender, EventArgs e)
        {
            pnlProductInformation.Visible = false;
        }

        protected virtual void Pbox_Clic(object o, EventArgs e)
        {
            var pbox = (PictureBox) o;
            var lbl = (Label)((object[]) pbox.Tag)[1];
            lbl.ForeColor = Color.Red;
            var product = (Product)((object[])pbox.Tag)[0];
            lblNameProduct.Text = product.Name;
            lblInitialPrice.Text = product.Price.ToString(CultureInfo.CurrentCulture);
            lblPointsProduct.Text = product.Points.ToString();
            pboxProduct.Image = product.ImageProduct;
            pnlProductInformation.Visible = true;
        }
    }
}
