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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlProductInformation = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNameProduct = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInitialPrice = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPointsProduct = new System.Windows.Forms.Label();
            this.pboxCloseProductInformation = new System.Windows.Forms.PictureBox();
            this.pboxProduct = new System.Windows.Forms.PictureBox();
            this.pboxClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlProductInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseProductInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.pboxClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // txbTime
            // 
            this.txbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTime.AutoSize = true;
            this.txbTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txbTime.Font = new System.Drawing.Font("DS-Digital", 42F, System.Drawing.FontStyle.Bold);
            this.txbTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txbTime.Location = new System.Drawing.Point(431, 6);
            this.txbTime.Name = "txbTime";
            this.txbTime.Size = new System.Drawing.Size(154, 58);
            this.txbTime.TabIndex = 0;
            this.txbTime.Text = "00:00";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txbTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 70);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(885, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "000";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(671, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "000";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(234, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 28);
            this.label8.TabIndex = 6;
            this.label8.Text = "000";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(37, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 28);
            this.label9.TabIndex = 5;
            this.label9.Text = "000";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(859, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 28);
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
            this.label4.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(645, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 28);
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
            this.label3.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(217, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 28);
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
            this.label2.Font = new System.Drawing.Font("Atomic Clock Radio", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subasta";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 485);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 80);
            this.panel3.TabIndex = 3;
            // 
            // pnlProducts
            // 
            this.pnlProducts.AutoScroll = true;
            this.pnlProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(92)))));
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProducts.Location = new System.Drawing.Point(0, 100);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlProducts.Size = new System.Drawing.Size(150, 385);
            this.pnlProducts.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(92)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(876, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 385);
            this.panel4.TabIndex = 5;
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
            this.pnlProductInformation.Size = new System.Drawing.Size(141, 385);
            this.pnlProductInformation.TabIndex = 6;
            this.pnlProductInformation.Visible = false;
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
            // pboxCloseProductInformation
            // 
            this.pboxCloseProductInformation.Image = global::AuctionGame_User.Properties.Resources.espalda;
            this.pboxCloseProductInformation.Location = new System.Drawing.Point(106, 349);
            this.pboxCloseProductInformation.Name = "pboxCloseProductInformation";
            this.pboxCloseProductInformation.Size = new System.Drawing.Size(30, 30);
            this.pboxCloseProductInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxCloseProductInformation.TabIndex = 7;
            this.pboxCloseProductInformation.TabStop = false;
            this.pboxCloseProductInformation.Click += new System.EventHandler(this.pboxCloseProductInformation_Click);
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
            // pboxClose
            // 
            this.pboxClose.Image = global::AuctionGame_User.Properties.Resources.cerrar;
            this.pboxClose.Location = new System.Drawing.Point(1001, 8);
            this.pboxClose.Name = "pboxClose";
            this.pboxClose.Size = new System.Drawing.Size(15, 15);
            this.pboxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxClose.TabIndex = 0;
            this.pboxClose.TabStop = false;
            this.pboxClose.Click += new System.EventHandler(this.pboxClose_Click);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1026, 565);
            this.Controls.Add(this.pnlProductInformation);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlProductInformation.ResumeLayout(false);
            this.pnlProductInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCloseProductInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pboxClose;
        private System.Windows.Forms.Label txbTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlProductInformation;
        private System.Windows.Forms.Label lblPointsProduct;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblInitialPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNameProduct;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pboxProduct;
        private System.Windows.Forms.PictureBox pboxCloseProductInformation;
    }
}

