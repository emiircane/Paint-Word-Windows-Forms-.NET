namespace paintwordödevgörsel
{
    partial class MiniPaintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniPaintForm));
            panelCizim = new Panel();
            txtYazi = new TextBox();
            cmbSekil = new ComboBox();
            cmbRenk = new ComboBox();
            button1 = new Button();
            txtR = new TextBox();
            txtG = new TextBox();
            txtB = new TextBox();
            pictureBoxKaydet = new PictureBox();
            pictureBoxYukle = new PictureBox();
            pictureBoxGeri = new PictureBox();
            panel1 = new Panel();
            pbDoldur = new PictureBox();
            pbYaziModu = new PictureBox();
            pictureBoxRenk = new PictureBox();
            label1 = new Label();
            pictureBoxUndo = new PictureBox();
            pictureBoxSilgi = new PictureBox();
            pictureBoxCiz = new PictureBox();
            cmbKalem = new ComboBox();
            pictureBoxRGB = new PictureBox();
            panelCizim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYukle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGeri).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDoldur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbYaziModu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRenk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUndo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSilgi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCiz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRGB).BeginInit();
            SuspendLayout();
            // 
            // panelCizim
            // 
            panelCizim.Controls.Add(txtYazi);
            panelCizim.Location = new Point(0, 152);
            panelCizim.Name = "panelCizim";
            panelCizim.Size = new Size(802, 484);
            panelCizim.TabIndex = 0;
            // 
            // txtYazi
            // 
            txtYazi.Location = new Point(313, 147);
            txtYazi.Name = "txtYazi";
            txtYazi.Size = new Size(100, 23);
            txtYazi.TabIndex = 0;
            txtYazi.Visible = false;
            // 
            // cmbSekil
            // 
            cmbSekil.FormattingEnabled = true;
            cmbSekil.Location = new Point(12, 12);
            cmbSekil.Name = "cmbSekil";
            cmbSekil.Size = new Size(161, 23);
            cmbSekil.TabIndex = 1;
            // 
            // cmbRenk
            // 
            cmbRenk.FormattingEnabled = true;
            cmbRenk.Location = new Point(177, 13);
            cmbRenk.Name = "cmbRenk";
            cmbRenk.Size = new Size(161, 23);
            cmbRenk.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(1278, 305);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtR
            // 
            txtR.Location = new Point(12, 69);
            txtR.Name = "txtR";
            txtR.Size = new Size(100, 23);
            txtR.TabIndex = 4;
            // 
            // txtG
            // 
            txtG.Location = new Point(12, 98);
            txtG.Name = "txtG";
            txtG.Size = new Size(100, 23);
            txtG.TabIndex = 5;
            // 
            // txtB
            // 
            txtB.Location = new Point(12, 127);
            txtB.Name = "txtB";
            txtB.Size = new Size(100, 23);
            txtB.TabIndex = 6;
            // 
            // pictureBoxKaydet
            // 
            pictureBoxKaydet.Image = (Image)resources.GetObject("pictureBoxKaydet.Image");
            pictureBoxKaydet.Location = new Point(577, 13);
            pictureBoxKaydet.Name = "pictureBoxKaydet";
            pictureBoxKaydet.Size = new Size(67, 40);
            pictureBoxKaydet.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxKaydet.TabIndex = 7;
            pictureBoxKaydet.TabStop = false;
            pictureBoxKaydet.Click += pictureBoxKaydet_Click;
            // 
            // pictureBoxYukle
            // 
            pictureBoxYukle.Image = Properties.Resources.upload;
            pictureBoxYukle.Location = new Point(650, 13);
            pictureBoxYukle.Name = "pictureBoxYukle";
            pictureBoxYukle.Size = new Size(66, 40);
            pictureBoxYukle.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxYukle.TabIndex = 8;
            pictureBoxYukle.TabStop = false;
            pictureBoxYukle.Click += pictureBoxYukle_Click;
            // 
            // pictureBoxGeri
            // 
            pictureBoxGeri.Image = Properties.Resources.pngegg;
            pictureBoxGeri.Location = new Point(722, 13);
            pictureBoxGeri.Name = "pictureBoxGeri";
            pictureBoxGeri.Size = new Size(67, 40);
            pictureBoxGeri.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGeri.TabIndex = 9;
            pictureBoxGeri.TabStop = false;
            pictureBoxGeri.Click += pictureBoxGeri_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(pbDoldur);
            panel1.Controls.Add(pbYaziModu);
            panel1.Controls.Add(pictureBoxRenk);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBoxUndo);
            panel1.Controls.Add(pictureBoxSilgi);
            panel1.Controls.Add(pictureBoxCiz);
            panel1.Controls.Add(cmbKalem);
            panel1.Controls.Add(pictureBoxRGB);
            panel1.Controls.Add(cmbRenk);
            panel1.Controls.Add(txtG);
            panel1.Controls.Add(txtB);
            panel1.Controls.Add(pictureBoxKaydet);
            panel1.Controls.Add(pictureBoxYukle);
            panel1.Controls.Add(txtR);
            panel1.Controls.Add(pictureBoxGeri);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 156);
            panel1.TabIndex = 10;
            // 
            // pbDoldur
            // 
            pbDoldur.Image = (Image)resources.GetObject("pbDoldur.Image");
            pbDoldur.Location = new Point(463, 42);
            pbDoldur.Name = "pbDoldur";
            pbDoldur.Size = new Size(38, 33);
            pbDoldur.SizeMode = PictureBoxSizeMode.Zoom;
            pbDoldur.TabIndex = 18;
            pbDoldur.TabStop = false;
            pbDoldur.Click += pbDoldur_Click;
            // 
            // pbYaziModu
            // 
            pbYaziModu.Image = (Image)resources.GetObject("pbYaziModu.Image");
            pbYaziModu.Location = new Point(419, 42);
            pbYaziModu.Name = "pbYaziModu";
            pbYaziModu.Size = new Size(38, 33);
            pbYaziModu.SizeMode = PictureBoxSizeMode.Zoom;
            pbYaziModu.TabIndex = 17;
            pbYaziModu.TabStop = false;
            // 
            // pictureBoxRenk
            // 
            pictureBoxRenk.Image = Properties.Resources.color_picker;
            pictureBoxRenk.Location = new Point(375, 42);
            pictureBoxRenk.Name = "pictureBoxRenk";
            pictureBoxRenk.Size = new Size(38, 33);
            pictureBoxRenk.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRenk.TabIndex = 16;
            pictureBoxRenk.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 15;
            label1.Text = "RGB ";
            // 
            // pictureBoxUndo
            // 
            pictureBoxUndo.Image = Properties.Resources.reverse;
            pictureBoxUndo.Location = new Point(330, 42);
            pictureBoxUndo.Name = "pictureBoxUndo";
            pictureBoxUndo.Size = new Size(39, 33);
            pictureBoxUndo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUndo.TabIndex = 14;
            pictureBoxUndo.TabStop = false;
            pictureBoxUndo.Click += pictureBoxUndo_Click;
            // 
            // pictureBoxSilgi
            // 
            pictureBoxSilgi.Image = Properties.Resources.silgi;
            pictureBoxSilgi.Location = new Point(285, 42);
            pictureBoxSilgi.Name = "pictureBoxSilgi";
            pictureBoxSilgi.Size = new Size(39, 33);
            pictureBoxSilgi.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSilgi.TabIndex = 13;
            pictureBoxSilgi.TabStop = false;
            pictureBoxSilgi.Click += pictureBoxSilgi_Click;
            // 
            // pictureBoxCiz
            // 
            pictureBoxCiz.Image = Properties.Resources.brush;
            pictureBoxCiz.Location = new Point(240, 42);
            pictureBoxCiz.Name = "pictureBoxCiz";
            pictureBoxCiz.Size = new Size(39, 33);
            pictureBoxCiz.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCiz.TabIndex = 12;
            pictureBoxCiz.TabStop = false;
            pictureBoxCiz.Click += pictureBoxCiz_Click;
            // 
            // cmbKalem
            // 
            cmbKalem.FormattingEnabled = true;
            cmbKalem.Location = new Point(344, 13);
            cmbKalem.Name = "cmbKalem";
            cmbKalem.Size = new Size(161, 23);
            cmbKalem.TabIndex = 11;
            // 
            // pictureBoxRGB
            // 
            pictureBoxRGB.Image = Properties.Resources.tik;
            pictureBoxRGB.Location = new Point(118, 98);
            pictureBoxRGB.Name = "pictureBoxRGB";
            pictureBoxRGB.Size = new Size(60, 35);
            pictureBoxRGB.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRGB.TabIndex = 10;
            pictureBoxRGB.TabStop = false;
            pictureBoxRGB.Click += pictureBoxRGB_Click;
            // 
            // MiniPaintForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 635);
            Controls.Add(button1);
            Controls.Add(cmbSekil);
            Controls.Add(panelCizim);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MiniPaintForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniPaintForm";
            panelCizim.ResumeLayout(false);
            panelCizim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxYukle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGeri).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDoldur).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbYaziModu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRenk).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUndo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSilgi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCiz).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRGB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCizim;
        private ComboBox cmbSekil;
        private ComboBox cmbRenk;
        private Button button1;
        private TextBox txtR;
        private TextBox txtG;
        private TextBox txtB;
        private PictureBox pictureBoxKaydet;
        private PictureBox pictureBoxYukle;
        private PictureBox pictureBoxGeri;
        private Panel panel1;
        private PictureBox pictureBoxRGB;
        private Label label1;
        private PictureBox pictureBoxUndo;
        private PictureBox pictureBoxSilgi;
        private PictureBox pictureBoxCiz;
        private ComboBox cmbKalem;
        private PictureBox pictureBoxRenk;
        private TextBox txtYazi;
        private PictureBox pbYaziModu;
        private PictureBox pbDoldur;
    }
}