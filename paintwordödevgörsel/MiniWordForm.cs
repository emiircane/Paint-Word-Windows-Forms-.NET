using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
namespace paintwordödevgörsel
{
    public partial class MiniWordForm: Form
    {
        PrintDocument yazdirBelgesi = new PrintDocument();
        string yazilacakMetin = "";
        public MiniWordForm()
        {
            InitializeComponent();
            cmbFont.SelectedIndexChanged += cmbFont_SelectedIndexChanged;
            cmbFontSize.SelectedIndexChanged += cmbFontSize_SelectedIndexChanged;
            this.Load += new System.EventHandler(this.MiniWordForm_Load);
            richTextBox1.TextChanged += richTextBox1_TextChanged;
        }
        private void MiniWordForm_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFont.Items.Add(font.Name);
            }
            cmbFont.SelectedIndex = 0;
            
            cmbFontSize.Items.AddRange(new object[] { "8", "10", "12", "14", "16", "18", "20", "24", "28", "32", "36", "48", "72" });
            cmbFontSize.SelectedIndex = 2;
            richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
        }
        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFont.SelectedItem != null)
            {
                string fontAdi = cmbFont.SelectedItem.ToString();
                float fontBoyutu = richTextBox1.SelectionFont?.Size ?? 12;
                FontStyle stil = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionFont = new Font(fontAdi, fontBoyutu, stil);
                }
                else
                {
                    richTextBox1.Font = new Font(fontAdi, fontBoyutu, stil);
                }
            }
        }


        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFontSize.SelectedItem != null)
            {
                float boyut = float.Parse(cmbFontSize.SelectedItem.ToString());
                string fontAdi = richTextBox1.SelectionFont?.FontFamily.Name ?? "Arial";
                FontStyle stil = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionFont = new Font(fontAdi, boyut, stil);
                }
                else
                {
                    richTextBox1.Font = new Font(fontAdi, boyut, stil);
                }
            }
        }

        private void pbBold_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
        }

        private void pbItalic_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
        }

        private void pbUnderline_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
        }
        private void pbRenk_Click(object sender, EventArgs e)
        {
            ColorDialog renkSec = new ColorDialog();
            if (renkSec.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = renkSec.Color;
            }
        }
        private void pbAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Dosyası|*.txt|Word Belgesi|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void pbKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Dosyası|*.txt|Word Belgesi|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
            }
        }
        private void pbGeriDon_Click(object sender, EventArgs e)
        {
            AnaForm ana = new AnaForm();
            ana.Show();
            this.Hide();
        }
        private void pbHizalaSol_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void pbHizalaOrta_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void pbHizalaSag_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void pbYazdir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            yazilacakMetin = richTextBox1.Text;
            yazdirBelgesi.PrintPage += YazdirBelgesi_PrintPage;
            pd.Document = yazdirBelgesi;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                yazdirBelgesi.Print();
            }
        }

        private void YazdirBelgesi_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(yazilacakMetin, richTextBox1.Font, Brushes.Black, 100, 100);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int kelimeSayisi = richTextBox1.Text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int satirSayisi = richTextBox1.Lines.Length;

            lblSayac.Text = $"Kelime: {kelimeSayisi} | Satır: {satirSayisi}";
        }
    }
}
