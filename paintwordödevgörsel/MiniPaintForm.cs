using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paintwordödevgörsel
{ 

    public partial class MiniPaintForm : Form
    {
        private bool ciziliyor = false;
        private Point baslangic;
        private string secilenSekil = "Kare";
        private Color secilenRenk = Color.Black;
        private enum AracModu { Ciz, Sil }
        private AracModu aktifMod = AracModu.Ciz;

        private Stack<Bitmap> geriAlStack = new Stack<Bitmap>();
        private int kalemBoyutu = 2;
        bool yaziModu = false;
        bool doldurmaModu = false;
        public MiniPaintForm()
        {
            InitializeComponent();

            // ComboBox ve Panel event bağlantıları
            this.Load += MiniPaintForm_Load;
            panelCizim.MouseDown += panelCizim_MouseDown;
            panelCizim.MouseUp += panelCizim_MouseUp;

            cmbSekil.SelectedIndexChanged += cmbSekil_SelectedIndexChanged;
            cmbRenk.SelectedIndexChanged += cmbRenk_SelectedIndexChanged;
            pictureBoxRenk.Click += pictureBoxRenk_Click;
            cmbKalem.SelectedIndexChanged += (s, e) =>
            {
                kalemBoyutu = int.Parse(cmbKalem.SelectedItem.ToString());
            };

            // RGB ve Dosya İşlemleri
            pictureBoxRGB.Click += pictureBoxRGB_Click;
            pictureBoxKaydet.Click += pictureBoxKaydet_Click;
            pictureBoxYukle.Click += pictureBoxYukle_Click;

            // Ana forma dönüş
            pictureBoxGeri.Click += pictureBoxGeri_Click;

            // Çizim Modları
            pictureBoxCiz.Click += pictureBoxCiz_Click;
            pictureBoxSilgi.Click += pictureBoxSilgi_Click;


            // Geri alma
            pictureBoxUndo.Click += pictureBoxUndo_Click;

            // panel hareket
            panelCizim.MouseMove += panelCizim_MouseMove;
        }

        private void MiniPaintForm_Load(object sender, EventArgs e)
        {
            cmbSekil.Items.AddRange(new string[] { "Kare", "Elips", "Üçgen", "Serbest" });
            cmbSekil.SelectedIndex = 0;

            cmbRenk.Items.AddRange(new string[] { "Siyah", "Kırmızı", "Yeşil", "Mavi", "Sarı" });
            cmbRenk.SelectedIndex = 0;

            cmbKalem.Items.AddRange(new string[] { "2", "5", "10", "15", "20" });
            cmbKalem.SelectedIndex = 0;

            cmbKalem.SelectedIndexChanged += (s, e2) =>
            {
                kalemBoyutu = int.Parse(cmbKalem.SelectedItem.ToString());
            };

            // İlk boş paneli geri alma listesine ekle
            Bitmap ilkBos = new Bitmap(panelCizim.Width, panelCizim.Height);
            panelCizim.DrawToBitmap(ilkBos, new Rectangle(0, 0, panelCizim.Width, panelCizim.Height));
            geriAlStack.Push(ilkBos);
            txtYazi.KeyDown += txtYazi_KeyDown;
            txtYazi.Visible = false;
        }

        private void cmbSekil_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenSekil = cmbSekil.SelectedItem.ToString();
        }

        private void cmbRenk_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRenk.SelectedItem.ToString())
            {
                case "Siyah": secilenRenk = Color.Black; break;
                case "Kırmızı": secilenRenk = Color.Red; break;
                case "Yeşil": secilenRenk = Color.Green; break;
                case "Mavi": secilenRenk = Color.Blue; break;
                case "Sarı": secilenRenk = Color.Yellow; break;
            }
        }

        private void pictureBoxRGB_Click(object sender, EventArgs e)
        {
            try
            {
                int r = Convert.ToInt32(txtR.Text);
                int g = Convert.ToInt32(txtG.Text);
                int b = Convert.ToInt32(txtB.Text);

                secilenRenk = Color.FromArgb(r, g, b);
            }
            catch
            {
                MessageBox.Show("RGB değerleri 0-255 arasında olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelCizim_MouseDown(object sender, MouseEventArgs e)
        {
            ciziliyor = true;
            baslangic = e.Location;
        }

        private void pictureBoxKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Dosyası|*.png|JPEG Dosyası|*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(panelCizim.Width, panelCizim.Height);
                panelCizim.DrawToBitmap(bmp, new Rectangle(0, 0, panelCizim.Width, panelCizim.Height));
                bmp.Save(sfd.FileName);
            }
        }

        private void pictureBoxYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                Graphics g = panelCizim.CreateGraphics();
                g.DrawImage(img, new Rectangle(0, 0, panelCizim.Width, panelCizim.Height));
            }
        }

        private void pictureBoxGeri_Click(object sender, EventArgs e)
        {
            AnaForm ana = new AnaForm();
            this.Hide();
            ana.Show();
        }
        private void panelCizim_MouseClick(object sender, MouseEventArgs e)
        {
            // Yazı modu aktifse
            if (yaziModu)
            {
                txtYazi.Location = e.Location;
                txtYazi.Text = "";
                txtYazi.Visible = true;
                txtYazi.Focus();
                return;
            }

            // Doldurma modu aktifse
            if (doldurmaModu)
            {
                Bitmap bmp = new Bitmap(panelCizim.Width, panelCizim.Height);
                panelCizim.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                Color hedefRenk = bmp.GetPixel(e.X, e.Y);

                if (hedefRenk.ToArgb() != secilenRenk.ToArgb())
                {
                    AlanDoldur(bmp, e.X, e.Y, hedefRenk, secilenRenk);
                    Graphics g = panelCizim.CreateGraphics();
                    g.DrawImage(bmp, 0, 0);
                }

                doldurmaModu = false;
            }
        }

        private void pictureBoxCiz_Click(object sender, EventArgs e)
        {
            aktifMod = AracModu.Ciz;
        }
        private void pictureBoxUndo_Click(object sender, EventArgs e)
        {
            if (geriAlStack.Count > 1)
            {
                // En son yapılanı çıkar (son hareketi temizle)
                geriAlStack.Pop();

                // Bir önceki durumu göster
                Bitmap onceki = geriAlStack.Peek();
                Graphics g = panelCizim.CreateGraphics();
                g.Clear(panelCizim.BackColor);
                g.DrawImage(onceki, 0, 0);
            }
            else if (geriAlStack.Count == 1)
            {
                // Son çizimi de silip temiz ekran göster
                geriAlStack.Pop();
                Graphics g = panelCizim.CreateGraphics();
                g.Clear(panelCizim.BackColor);
            }
        }

        private void pictureBoxSilgi_Click(object sender, EventArgs e)
        {
            aktifMod = AracModu.Sil;
        }
        private void panelCizim_MouseMove(object sender, MouseEventArgs e)
        {
            if (ciziliyor && secilenSekil == "Serbest")
            {
                using (Graphics g = panelCizim.CreateGraphics())
                {
                    Pen kalem = new Pen(aktifMod == AracModu.Sil ? panelCizim.BackColor : secilenRenk, kalemBoyutu);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(kalem, baslangic, e.Location);
                }
                baslangic = e.Location;
            }
        }
        private void pictureBoxRenk_Click(object sender, EventArgs e)
        {
            ColorDialog renkSec = new ColorDialog();
            if (renkSec.ShowDialog() == DialogResult.OK)
            {
                secilenRenk = renkSec.Color;
            }
        }
        private void pbYaziModu_Click(object sender, EventArgs e)
        {
            yaziModu = true;
        }
        private void txtYazi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Graphics g = panelCizim.CreateGraphics();
                g.DrawString(txtYazi.Text, new Font("Arial", 14), new SolidBrush(secilenRenk), txtYazi.Location);
                txtYazi.Visible = false;
                yaziModu = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void pbDoldur_Click(object sender, EventArgs e)
        {
            doldurmaModu = true;
        }
       
        private void AlanDoldur(Bitmap bmp, int x, int y, Color eskiRenk, Color yeniRenk)
        {
            Queue<Point> kuyruk = new Queue<Point>();
            kuyruk.Enqueue(new Point(x, y));

            while (kuyruk.Count > 0)
            {
                Point p = kuyruk.Dequeue();
                if (p.X < 0 || p.Y < 0 || p.X >= bmp.Width || p.Y >= bmp.Height)
                    continue;

                if (bmp.GetPixel(p.X, p.Y).ToArgb() != eskiRenk.ToArgb())
                    continue;

                bmp.SetPixel(p.X, p.Y, yeniRenk);

                kuyruk.Enqueue(new Point(p.X + 1, p.Y));
                kuyruk.Enqueue(new Point(p.X - 1, p.Y));
                kuyruk.Enqueue(new Point(p.X, p.Y + 1));
                kuyruk.Enqueue(new Point(p.X, p.Y - 1));
            }
        }
        private void panelCizim_MouseUp(object sender, MouseEventArgs e)
        {
            ciziliyor = false;

            if (secilenSekil == "Serbest") return;

            Graphics g = panelCizim.CreateGraphics();
            Pen kalem = new Pen(aktifMod == AracModu.Sil ? panelCizim.BackColor : secilenRenk, kalemBoyutu);

            int genislik = e.X - baslangic.X;
            int yukseklik = e.Y - baslangic.Y;

            switch (secilenSekil)
            {
                case "Kare":
                    g.DrawRectangle(kalem, baslangic.X, baslangic.Y, genislik, yukseklik);
                    break;
                case "Elips":
                    g.DrawEllipse(kalem, baslangic.X, baslangic.Y, genislik, yukseklik);
                    break;
                case "Üçgen":
                    Point[] ucgen = {
                new Point(baslangic.X + genislik / 2, baslangic.Y),
                new Point(baslangic.X, baslangic.Y + yukseklik),
                new Point(baslangic.X + genislik, baslangic.Y + yukseklik)
            };
                    g.DrawPolygon(kalem, ucgen);
                    break;
            }

            // Geri alma kaydı
            Bitmap bmp = new Bitmap(panelCizim.Width, panelCizim.Height);
            panelCizim.DrawToBitmap(bmp, new Rectangle(0, 0, panelCizim.Width, panelCizim.Height));
            geriAlStack.Push(bmp);
        }
    }
}
