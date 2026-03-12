using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F1
{
    public partial class Piloti : Form
    {
        public Piloti()
        {
            InitializeComponent();
        }

        private void Piloti_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bRandom_Click(object sender, EventArgs e)
        {
            int numero_gara;
            Random random = new Random();
            numero_gara = random.Next(1, 99);
            for (int i = 0; i < 
        }
    }
}
