using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class Notifikasi : Form
    {
        public Notifikasi(string s)
        {
            InitializeComponent();
            this.textBox1.Text = s;
            this.textBox1.ReadOnly = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
