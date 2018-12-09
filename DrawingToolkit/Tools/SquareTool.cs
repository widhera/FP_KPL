using DrawingToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class SquareTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Square varSquare;
        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                this.canvas = value;
            }
        }
        public SquareTool()
        {
            this.Name = "Stateful Square tool";
            this.ToolTipText = "Stateful Square tool";
            //this.Image = IconSet.diagonal_line;
            this.Text = "Square State";
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                varSquare = new Square(new System.Drawing.Point(e.X, e.Y));
                varSquare.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(varSquare);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varSquare != null)
                {
                    varSquare.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varSquare != null)
                {
                    varSquare.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    varSquare.Select();
                }
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
