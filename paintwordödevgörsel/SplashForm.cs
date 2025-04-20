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
    public partial class SplashForm: Form
    {
        public SplashForm()
        {
            InitializeComponent();

            // BURASI ÖNEMLİ! OLAYLARI MANUEL BAĞLIYORUZ
            this.Load += SplashForm_Load;
            timer1.Tick += timer1_Tick;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
            }
            else
            {
                timer1.Stop();
                AnaForm ana = new AnaForm();
                this.Hide();
                ana.Show();
            }
        }
    }
}
