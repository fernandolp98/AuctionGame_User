namespace AuctionGame_User
{
    partial class FrmGame
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pboxCloseForm = new System.Windows.Forms.PictureBox();
            this.txbClock = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblRoundNumber = new System.Windows.Forms.Label();
            this.lblAuctionNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerAuction = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pboxPlay = new System.Windows.Forms.PictureBox();
            this.pboxDecrementValueOffer = new System.Windows.Forms.PictureBox();
            this.pboxIncreaseValueOffer = new System.Windows.Forms.PictureBox();
            this.pboDecrementBid = new System.Windows.Forms.PictureBox();
            this.pboxIncreaseBid = new System.Windows.Forms.PictureBox();
            this.txbIncreaseOffert = new System.Windows.Forms.TextBox();
            this.txbOffer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pboxBid = new System.Windows.Forms.PictureBox();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.pnlFamilies = new System.Windows.Forms.Panel();
            this.pnlProductInformation = new System.Windows.Forms.Panel();
            this.pboxCloseProductInformation = new System.Windows.Forms.PictureBox();
            this.pboxProduct = new System.Windows.Forms.PictureBox();
            this.lblPointsProduct = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblInitialPrice = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNameProduct = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlProductsByFamily = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.pboxCurrentProduct = new System.Windows.Forms.PictureBox();
            this.lblPointsProductOfferded = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCurrentPriceProduct = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCurrentNameProduct = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txbLastOfferPlayer = new System.Windows.Forms.TextBox();
            this.txbLastOffer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbCurrentWinner = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseForm)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDecrementValueOffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncreaseValueOffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboDecrementBid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncreaseBid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBid)).BeginInit();
            this.pnlProductInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseProductInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduct)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.pboxCloseForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pboxCloseForm
            // 
            this.pboxCloseForm.Image = global::AuctionGame_User.Properties.Resources.cerrar;
            this.pboxCloseForm.Location = new System.Drawing.Point(1001, 8);
            this.pboxCloseForm.Name = "pboxCloseForm";
            this.pboxCloseForm.Size = new System.Drawing.Size(15, 15);
            this.pboxCloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCloseForm.TabIndex = 0;
            this.pboxCloseForm.TabStop = false;
            this.pboxCloseForm.Click += new System.EventHandler(this.pboxCloseForm_Click);
            // 
            // txbClock
            // 
            this.txbClock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbClock.AutoSize = true;
            this.txbClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbClock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txbClock.Font = new System.Drawing.Font("DS-Digital", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbClock.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txbClock.Location = new System.Drawing.Point(431, 6);
            this.txbClock.Name = "txbClock";
            this.txbClock.Size = new System.Drawing.Size(154, 58);
            this.txbClock.TabIndex = 0;
            this.txbClock.Text = "00:00";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel2.Controls.Add(this.lblPoints);
            this.panel2.Controls.Add(this.lblMoney);
            this.panel2.Controls.Add(this.lblRoundNumber);
            this.panel2.Controls.Add(this.lblAuctionNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txbClock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 70);
            this.panel2.TabIndex = 1;
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoints.AutoSize = true;
            this.lblPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPoints.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPoints.Location = new System.Drawing.Point(885, 31);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(65, 28);
            this.lblPoints.TabIndex = 8;
            this.lblPoints.Text = "000";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMoney
            // 
            this.lblMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoney.AutoSize = true;
            this.lblMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMoney.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMoney.Location = new System.Drawing.Point(671, 34);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(65, 28);
            this.lblMoney.TabIndex = 7;
            this.lblMoney.Text = "000";
            this.lblMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRoundNumber
            // 
            this.lblRoundNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoundNumber.AutoSize = true;
            this.lblRoundNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRoundNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRoundNumber.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundNumber.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRoundNumber.Location = new System.Drawing.Point(234, 34);
            this.lblRoundNumber.Name = "lblRoundNumber";
            this.lblRoundNumber.Size = new System.Drawing.Size(65, 28);
            this.lblRoundNumber.TabIndex = 6;
            this.lblRoundNumber.Text = "000";
            this.lblRoundNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAuctionNumber
            // 
            this.lblAuctionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuctionNumber.AutoSize = true;
            this.lblAuctionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuctionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAuctionNumber.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuctionNumber.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAuctionNumber.Location = new System.Drawing.Point(37, 34);
            this.lblAuctionNumber.Name = "lblAuctionNumber";
            this.lblAuctionNumber.Size = new System.Drawing.Size(65, 28);
            this.lblAuctionNumber.TabIndex = 5;
            this.lblAuctionNumber.Text = "000";
            this.lblAuctionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(859, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Puntos";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(645, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dinero";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(217, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Round";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subasta";
            // 
            // timerAuction
            // 
            this.timerAuction.Interval = 1000;
            this.timerAuction.Tick += new System.EventHandler(this.timerAuction_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.pboxPlay);
            this.panel3.Controls.Add(this.pboxDecrementValueOffer);
            this.panel3.Controls.Add(this.pboxIncreaseValueOffer);
            this.panel3.Controls.Add(this.pboDecrementBid);
            this.panel3.Controls.Add(this.pboxIncreaseBid);
            this.panel3.Controls.Add(this.txbIncreaseOffert);
            this.panel3.Controls.Add(this.txbOffer);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pboxBid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 475);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 90);
            this.panel3.TabIndex = 3;
            // 
            // pboxPlay
            // 
            this.pboxPlay.Image = global::AuctionGame_User.Properties.Resources.jugar;
            this.pboxPlay.Location = new System.Drawing.Point(936, 18);
            this.pboxPlay.Name = "pboxPlay";
            this.pboxPlay.Size = new System.Drawing.Size(60, 60);
            this.pboxPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxPlay.TabIndex = 16;
            this.pboxPlay.TabStop = false;
            this.pboxPlay.Click += new System.EventHandler(this.pboxPlay_Click);
            // 
            // pboxDecrementValueOffer
            // 
            this.pboxDecrementValueOffer.Image = global::AuctionGame_User.Properties.Resources.bajar_2_1;
            this.pboxDecrementValueOffer.Location = new System.Drawing.Point(720, 51);
            this.pboxDecrementValueOffer.Name = "pboxDecrementValueOffer";
            this.pboxDecrementValueOffer.Size = new System.Drawing.Size(30, 30);
            this.pboxDecrementValueOffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxDecrementValueOffer.TabIndex = 15;
            this.pboxDecrementValueOffer.TabStop = false;
            this.pboxDecrementValueOffer.Click += new System.EventHandler(this.pboxDecrementValueOffer_Click);
            this.pboxDecrementValueOffer.DoubleClick += new System.EventHandler(this.pboxDecrementValueOffer_Click);
            // 
            // pboxIncreaseValueOffer
            // 
            this.pboxIncreaseValueOffer.Image = global::AuctionGame_User.Properties.Resources.subir_2_;
            this.pboxIncreaseValueOffer.Location = new System.Drawing.Point(720, 15);
            this.pboxIncreaseValueOffer.Name = "pboxIncreaseValueOffer";
            this.pboxIncreaseValueOffer.Size = new System.Drawing.Size(30, 30);
            this.pboxIncreaseValueOffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxIncreaseValueOffer.TabIndex = 14;
            this.pboxIncreaseValueOffer.TabStop = false;
            this.pboxIncreaseValueOffer.Click += new System.EventHandler(this.pboxIncreaseValueOffer_Click);
            this.pboxIncreaseValueOffer.DoubleClick += new System.EventHandler(this.pboxIncreaseValueOffer_Click);
            // 
            // pboDecrementBid
            // 
            this.pboDecrementBid.Image = global::AuctionGame_User.Properties.Resources.bajar_2_;
            this.pboDecrementBid.Location = new System.Drawing.Point(269, 51);
            this.pboDecrementBid.Name = "pboDecrementBid";
            this.pboDecrementBid.Size = new System.Drawing.Size(30, 30);
            this.pboDecrementBid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboDecrementBid.TabIndex = 13;
            this.pboDecrementBid.TabStop = false;
            this.pboDecrementBid.Click += new System.EventHandler(this.pboDecrementBid_Click);
            this.pboDecrementBid.DoubleClick += new System.EventHandler(this.pboDecrementBid_Click);
            // 
            // pboxIncreaseBid
            // 
            this.pboxIncreaseBid.Image = global::AuctionGame_User.Properties.Resources.subir_2_;
            this.pboxIncreaseBid.Location = new System.Drawing.Point(269, 15);
            this.pboxIncreaseBid.Name = "pboxIncreaseBid";
            this.pboxIncreaseBid.Size = new System.Drawing.Size(30, 30);
            this.pboxIncreaseBid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxIncreaseBid.TabIndex = 12;
            this.pboxIncreaseBid.TabStop = false;
            this.pboxIncreaseBid.Click += new System.EventHandler(this.pboxIncreaseBid_Click);
            this.pboxIncreaseBid.DoubleClick += new System.EventHandler(this.pboxIncreaseBid_Click);
            // 
            // txbIncreaseOffert
            // 
            this.txbIncreaseOffert.Enabled = false;
            this.txbIncreaseOffert.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIncreaseOffert.Location = new System.Drawing.Point(554, 43);
            this.txbIncreaseOffert.Name = "txbIncreaseOffert";
            this.txbIncreaseOffert.Size = new System.Drawing.Size(160, 38);
            this.txbIncreaseOffert.TabIndex = 11;
            this.txbIncreaseOffert.Text = "000";
            this.txbIncreaseOffert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbOffer
            // 
            this.txbOffer.Enabled = false;
            this.txbOffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOffer.Location = new System.Drawing.Point(312, 43);
            this.txbOffer.Name = "txbOffer";
            this.txbOffer.Size = new System.Drawing.Size(160, 38);
            this.txbOffer.TabIndex = 10;
            this.txbOffer.Text = "000";
            this.txbOffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(582, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "Incremento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(358, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Oferta";
            // 
            // pboxBid
            // 
            this.pboxBid.Image = global::AuctionGame_User.Properties.Resources.oferta;
            this.pboxBid.Location = new System.Drawing.Point(478, 15);
            this.pboxBid.Name = "pboxBid";
            this.pboxBid.Size = new System.Drawing.Size(70, 70);
            this.pboxBid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxBid.TabIndex = 0;
            this.pboxBid.TabStop = false;
            this.pboxBid.Click += new System.EventHandler(this.pboxBid_Click);
            // 
            // pnlProducts
            // 
            this.pnlProducts.AutoScroll = true;
            this.pnlProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(92)))));
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProducts.Location = new System.Drawing.Point(0, 100);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlProducts.Size = new System.Drawing.Size(150, 375);
            this.pnlProducts.TabIndex = 4;
            // 
            // pnlFamilies
            // 
            this.pnlFamilies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(92)))));
            this.pnlFamilies.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFamilies.Location = new System.Drawing.Point(876, 100);
            this.pnlFamilies.Name = "pnlFamilies";
            this.pnlFamilies.Size = new System.Drawing.Size(150, 375);
            this.pnlFamilies.TabIndex = 5;
            // 
            // pnlProductInformation
            // 
            this.pnlProductInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(116)))), ((int)(((byte)(149)))));
            this.pnlProductInformation.Controls.Add(this.pboxCloseProductInformation);
            this.pnlProductInformation.Controls.Add(this.pboxProduct);
            this.pnlProductInformation.Controls.Add(this.lblPointsProduct);
            this.pnlProductInformation.Controls.Add(this.label14);
            this.pnlProductInformation.Controls.Add(this.lblInitialPrice);
            this.pnlProductInformation.Controls.Add(this.label12);
            this.pnlProductInformation.Controls.Add(this.lblNameProduct);
            this.pnlProductInformation.Controls.Add(this.label10);
            this.pnlProductInformation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProductInformation.Location = new System.Drawing.Point(150, 100);
            this.pnlProductInformation.Name = "pnlProductInformation";
            this.pnlProductInformation.Size = new System.Drawing.Size(141, 375);
            this.pnlProductInformation.TabIndex = 6;
            this.pnlProductInformation.Visible = false;
            // 
            // pboxCloseProductInformation
            // 
            this.pboxCloseProductInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pboxCloseProductInformation.Image = global::AuctionGame_User.Properties.Resources.espalda;
            this.pboxCloseProductInformation.Location = new System.Drawing.Point(0, 345);
            this.pboxCloseProductInformation.Name = "pboxCloseProductInformation";
            this.pboxCloseProductInformation.Size = new System.Drawing.Size(141, 30);
            this.pboxCloseProductInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxCloseProductInformation.TabIndex = 7;
            this.pboxCloseProductInformation.TabStop = false;
            this.pboxCloseProductInformation.Click += new System.EventHandler(this.pboxClose_Click);
            // 
            // pboxProduct
            // 
            this.pboxProduct.Location = new System.Drawing.Point(6, 6);
            this.pboxProduct.Name = "pboxProduct";
            this.pboxProduct.Size = new System.Drawing.Size(130, 170);
            this.pboxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxProduct.TabIndex = 6;
            this.pboxProduct.TabStop = false;
            // 
            // lblPointsProduct
            // 
            this.lblPointsProduct.AutoSize = true;
            this.lblPointsProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsProduct.ForeColor = System.Drawing.Color.Snow;
            this.lblPointsProduct.Location = new System.Drawing.Point(16, 324);
            this.lblPointsProduct.Name = "lblPointsProduct";
            this.lblPointsProduct.Size = new System.Drawing.Size(17, 23);
            this.lblPointsProduct.TabIndex = 5;
            this.lblPointsProduct.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Yellow;
            this.label14.Location = new System.Drawing.Point(16, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 24);
            this.label14.TabIndex = 4;
            this.label14.Text = "Puntos";
            // 
            // lblInitialPrice
            // 
            this.lblInitialPrice.AutoSize = true;
            this.lblInitialPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialPrice.ForeColor = System.Drawing.Color.Snow;
            this.lblInitialPrice.Location = new System.Drawing.Point(16, 267);
            this.lblInitialPrice.Name = "lblInitialPrice";
            this.lblInitialPrice.Size = new System.Drawing.Size(17, 23);
            this.lblInitialPrice.TabIndex = 3;
            this.lblInitialPrice.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(16, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "Precio Inicial";
            // 
            // lblNameProduct
            // 
            this.lblNameProduct.AutoSize = true;
            this.lblNameProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameProduct.ForeColor = System.Drawing.Color.Snow;
            this.lblNameProduct.Location = new System.Drawing.Point(16, 210);
            this.lblNameProduct.Name = "lblNameProduct";
            this.lblNameProduct.Size = new System.Drawing.Size(17, 23);
            this.lblNameProduct.TabIndex = 1;
            this.lblNameProduct.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(16, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nombre";
            // 
            // pnlProductsByFamily
            // 
            this.pnlProductsByFamily.AutoScroll = true;
            this.pnlProductsByFamily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(116)))), ((int)(((byte)(149)))));
            this.pnlProductsByFamily.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlProductsByFamily.Location = new System.Drawing.Point(735, 100);
            this.pnlProductsByFamily.Name = "pnlProductsByFamily";
            this.pnlProductsByFamily.Size = new System.Drawing.Size(141, 375);
            this.pnlProductsByFamily.TabIndex = 7;
            this.pnlProductsByFamily.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbCurrentWinner);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.pboxCurrentProduct);
            this.panel4.Controls.Add(this.lblPointsProductOfferded);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.lblCurrentPriceProduct);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.lblCurrentNameProduct);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.txbLastOfferPlayer);
            this.panel4.Controls.Add(this.txbLastOffer);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(291, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(444, 375);
            this.panel4.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Yellow;
            this.label22.Location = new System.Drawing.Point(163, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 45);
            this.label22.TabIndex = 25;
            this.label22.Text = "Producto en subasta";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pboxCurrentProduct
            // 
            this.pboxCurrentProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboxCurrentProduct.Image = ((System.Drawing.Image)(resources.GetObject("pboxCurrentProduct.Image")));
            this.pboxCurrentProduct.Location = new System.Drawing.Point(163, 54);
            this.pboxCurrentProduct.Name = "pboxCurrentProduct";
            this.pboxCurrentProduct.Size = new System.Drawing.Size(130, 170);
            this.pboxCurrentProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxCurrentProduct.TabIndex = 24;
            this.pboxCurrentProduct.TabStop = false;
            // 
            // lblPointsProductOfferded
            // 
            this.lblPointsProductOfferded.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPointsProductOfferded.AutoSize = true;
            this.lblPointsProductOfferded.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsProductOfferded.ForeColor = System.Drawing.Color.Snow;
            this.lblPointsProductOfferded.Location = new System.Drawing.Point(130, 327);
            this.lblPointsProductOfferded.Name = "lblPointsProductOfferded";
            this.lblPointsProductOfferded.Size = new System.Drawing.Size(17, 23);
            this.lblPointsProductOfferded.TabIndex = 23;
            this.lblPointsProductOfferded.Text = "-";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Yellow;
            this.label17.Location = new System.Drawing.Point(56, 326);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 24);
            this.label17.TabIndex = 22;
            this.label17.Text = "Puntos";
            // 
            // lblCurrentPriceProduct
            // 
            this.lblCurrentPriceProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentPriceProduct.AutoSize = true;
            this.lblCurrentPriceProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPriceProduct.ForeColor = System.Drawing.Color.Snow;
            this.lblCurrentPriceProduct.Location = new System.Drawing.Point(130, 291);
            this.lblCurrentPriceProduct.Name = "lblCurrentPriceProduct";
            this.lblCurrentPriceProduct.Size = new System.Drawing.Size(17, 23);
            this.lblCurrentPriceProduct.TabIndex = 21;
            this.lblCurrentPriceProduct.Text = "-";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Yellow;
            this.label19.Location = new System.Drawing.Point(8, 290);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 24);
            this.label19.TabIndex = 20;
            this.label19.Text = "Precio Inicial";
            // 
            // lblCurrentNameProduct
            // 
            this.lblCurrentNameProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentNameProduct.AutoSize = true;
            this.lblCurrentNameProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentNameProduct.ForeColor = System.Drawing.Color.Snow;
            this.lblCurrentNameProduct.Location = new System.Drawing.Point(130, 250);
            this.lblCurrentNameProduct.Name = "lblCurrentNameProduct";
            this.lblCurrentNameProduct.Size = new System.Drawing.Size(17, 23);
            this.lblCurrentNameProduct.TabIndex = 19;
            this.lblCurrentNameProduct.Text = "-";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Yellow;
            this.label21.Location = new System.Drawing.Point(45, 249);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 24);
            this.label21.TabIndex = 18;
            this.label21.Text = "Nombre";
            // 
            // txbLastOfferPlayer
            // 
            this.txbLastOfferPlayer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txbLastOfferPlayer.Enabled = false;
            this.txbLastOfferPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLastOfferPlayer.Location = new System.Drawing.Point(316, 31);
            this.txbLastOfferPlayer.Name = "txbLastOfferPlayer";
            this.txbLastOfferPlayer.Size = new System.Drawing.Size(120, 31);
            this.txbLastOfferPlayer.TabIndex = 17;
            this.txbLastOfferPlayer.Text = "000";
            this.txbLastOfferPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbLastOffer
            // 
            this.txbLastOffer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbLastOffer.Enabled = false;
            this.txbLastOffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLastOffer.Location = new System.Drawing.Point(6, 31);
            this.txbLastOffer.Name = "txbLastOffer";
            this.txbLastOffer.Size = new System.Drawing.Size(120, 31);
            this.txbLastOffer.TabIndex = 16;
            this.txbLastOffer.Text = "000";
            this.txbLastOffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Yellow;
            this.label15.Location = new System.Drawing.Point(336, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Mi Oferta";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(8, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Última Oferta";
            // 
            // txbCurrentWinner
            // 
            this.txbCurrentWinner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbCurrentWinner.Enabled = false;
            this.txbCurrentWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCurrentWinner.Location = new System.Drawing.Point(6, 103);
            this.txbCurrentWinner.Name = "txbCurrentWinner";
            this.txbCurrentWinner.Size = new System.Drawing.Size(120, 31);
            this.txbCurrentWinner.TabIndex = 27;
            this.txbCurrentWinner.Text = "-";
            this.txbCurrentWinner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(-1, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Ganador Actual";
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1026, 565);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlProductsByFamily);
            this.Controls.Add(this.pnlProductInformation);
            this.Controls.Add(this.pnlFamilies);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGame";
            this.Text = "|";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseForm)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDecrementValueOffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncreaseValueOffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboDecrementBid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncreaseBid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBid)).EndInit();
            this.pnlProductInformation.ResumeLayout(false);
            this.pnlProductInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseProductInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduct)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pboxCloseForm;
        private System.Windows.Forms.Label txbClock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblRoundNumber;
        private System.Windows.Forms.Label lblAuctionNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerAuction;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel pnlFamilies;
        private System.Windows.Forms.Panel pnlProductInformation;
        private System.Windows.Forms.Label lblPointsProduct;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblInitialPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNameProduct;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pboxProduct;
        private System.Windows.Forms.PictureBox pboxCloseProductInformation;
        private System.Windows.Forms.Panel pnlProductsByFamily;
        private System.Windows.Forms.TextBox txbIncreaseOffert;
        private System.Windows.Forms.TextBox txbOffer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pboxBid;
        private System.Windows.Forms.PictureBox pboxDecrementValueOffer;
        private System.Windows.Forms.PictureBox pboxIncreaseValueOffer;
        private System.Windows.Forms.PictureBox pboDecrementBid;
        private System.Windows.Forms.PictureBox pboxIncreaseBid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbLastOfferPlayer;
        private System.Windows.Forms.TextBox txbLastOffer;
        private System.Windows.Forms.PictureBox pboxCurrentProduct;
        private System.Windows.Forms.Label lblPointsProductOfferded;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCurrentPriceProduct;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCurrentNameProduct;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pboxPlay;
        private System.Windows.Forms.TextBox txbCurrentWinner;
        private System.Windows.Forms.Label label6;
    }
}

