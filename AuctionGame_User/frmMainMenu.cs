using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionGame_User
{
    public partial class frmMainMenu : Form
    {
        private int _xClick = 0, _yClick = 0;

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void txbName_Enter(object sender, EventArgs e)
        {
            DataControl.PlaceHolder_Enter((TextBox)sender);
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            DataControl.placeHolder_Leave((TextBox)sender);

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
