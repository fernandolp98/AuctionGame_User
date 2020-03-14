﻿using System;
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


        }
        private bool ValidData()
        {
            var controls = new object[]
            {
                txbName,
            };
            return !_dataControl.Validar(controls);
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!ValidData()) return;
            var game = new FrmGame(txbName.Text);
            Hide();
            game.ShowDialog();
            Show();
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
