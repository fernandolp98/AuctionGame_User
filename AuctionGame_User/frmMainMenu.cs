using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class frmMainMenu : Form
    {
        private int _xClick = 0, _yClick = 0;
        private static readonly Font FontPlaceHolder = new Font("Comic Sans MS", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
        private static readonly Font FontRegular = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private readonly DataControl dc = new DataControl(FontPlaceHolder, FontRegular, Color.DimGray, Color.DimGray, Color.Red);

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void txbName_Enter(object sender, EventArgs e)
        {
            dc.PlaceHolder_Enter((TextBox)sender);
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            dc.placeHolder_Leave((TextBox)sender);

        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                var routines = Routine.GetAllRoutines();
                cboRoutines.DataSource = routines;
                cboRoutines.DisplayMember = "NameRoutine";
                cboRoutines.ValueMember = "IdRoutine";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool validData()
        {
            var controls = new object[]
            {
                txbName,
                txbInitialWallet
            };
            return !dc.Validar(controls);
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(validData())
            {
                string query = $"SELECT insert_user('{txbName.Text}', {txbInitialWallet.Text})";
                var idUserTable = DbConnection.consultar_datos(query);
                if (idUserTable != null)
                {
                    int idUser = (int)idUserTable.Rows[0][0];
                    query = $"SELECT BIDDER_idBidder, idStats FROM user WHERE idUser = {idUser}";
                    var idResults = DbConnection.consultar_datos(query);
                    if (idResults != null)
                    {
                        var player = new Bidder();
                        player.NameBidder = txbName.Text;
                        player.Wallet = decimal.Parse(txbInitialWallet.Text);
                        player.IdBidder = (int)idResults.Rows[0][0];
                        player.Statistics.IdStatistical = (int)idResults.Rows[0][1];
                        var routine = (Routine)cboRoutines.SelectedItem;
                        

                        var game = new FrmGame(player, routine);
                        game.Show();

                    }
                }
            }
        }

        private void txbName_Validated(object sender, EventArgs e)
        {
            dc.Validar((TextBox)sender);
        }

        private void frmMainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                _xClick = e.X;
                _yClick = e.Y;
            }
            else
            {
                Left += e.X - _xClick;
                Top += e.Y - _yClick;
            }
        }
    }
}
