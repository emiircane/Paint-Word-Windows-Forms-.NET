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
    public partial class AnaForm: Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MiniPaintForm paint = new MiniPaintForm();
            this.Hide();
            paint.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MiniWordForm word = new MiniWordForm();
            this.Hide();
            word.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // direkt uygulamayı kapatır
        }

    }
}
