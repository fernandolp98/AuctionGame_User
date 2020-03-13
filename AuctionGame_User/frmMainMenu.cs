using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class FrmMainMenu : Form
    {
        private int _xClick, _yClick;
        private static readonly Font FontPlaceHolder = new Font("Comic Sans MS", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
        private static readonly Font FontRegular = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private readonly DataControl _dataControl = new DataControl(FontPlaceHolder, FontRegular, Color.DimGray, Color.DimGray, Color.Red);

        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void txbName_Enter(object sender, EventArgs e)
        {
            _dataControl.PlaceHolder_Enter((TextBox)sender);
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            _dataControl.placeHolder_Leave((TextBox)sender);

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
        private bool ValidData()
        {
            var controls = new object[]
            {
                txbName,
                txbInitialWallet
            };
            return !_dataControl.Validar(controls);
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!ValidData()) return;
            var query = $"SELECT insert_user('{txbName.Text}', {txbInitialWallet.Text})";
            var idUserTable = DbConnection.consultar_datos(query);
            if (idUserTable == null) return;
            var idUser = (int)idUserTable.Rows[0][0];
            query = $"SELECT BIDDER_idBidder, idStats FROM user WHERE idUser = {idUser}";
            var idResults = DbConnection.consultar_datos(query);
            if (idResults == null) return;
            var player = new User
            {
                IdUser = idUser,
                Bidder =
                {
                    NameBidder = txbName.Text,
                    Wallet = decimal.Parse(txbInitialWallet.Text),
                    IdBidder = (int) idResults.Rows[0][0]
                },
                Statistics = {IdStatistical = (int) idResults.Rows[0][1]}
            };
            var routine = (Routine)cboRoutines.SelectedItem;
                        

            var game = new FrmGame(player);
            game.Show();
        }

        private void txbName_Validated(object sender, EventArgs e)
        {
            _dataControl.Validar((TextBox)sender);
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
