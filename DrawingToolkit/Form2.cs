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
    public partial class Form2 : Form
    {
        private DrawingObject selectObject;
        private ICanvas canvas;
        public Form2(string text,DrawingObject obj, ICanvas canvas)
        {
            InitializeComponent();
            this.textBox1.Text = text;
            this.selectObject = obj;
            this.canvas = canvas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DrawingObject> CanvasObject = canvas.GetCanvasObject();
            foreach(DrawingObject obj in CanvasObject)
            {
                if(obj == this.selectObject)
                {
                    selectObject.ChangeText(this.textBox1.Text);
                    break;
                }
            }
            this.Close();
        }
    }
}
