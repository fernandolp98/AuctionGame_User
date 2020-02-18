using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class FrmGame : Form
    {
        public int Xclick, Yclick;
        private Time _time = new Time(0, 0, 60);
        Font font = new Font(new FontFamily("Comic Sans MS"), 14, FontStyle.Regular);

        private List<Product> _products;
        private List<Family> _families;

        public FrmGame()
        {
            InitializeComponent();
            _products = Product.GetAllProducts();
            _families = Family.GetAllFamilies();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            while(_time.GetSeconds() > 0)
            {
                txbTime.Text = _time.Format("mm:ss");
                _time = new Time(_time.GetSeconds() - 1, "ss");
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
