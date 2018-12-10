using DrawingToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle varCircle;
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
        public CircleTool()
        {
            this.Name = "Stateful Circle tool";
            this.ToolTipText = "Stateful Circle tool";
            //this.Image = IconSet.diagonal_line;
            this.Text = "Circle State";
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                varCircle = new Circle(new System.Drawing.Point(e.X, e.Y));
                varCircle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(varCircle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varCircle != null)
                {
                    varCircle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varCircle != null)
                {
                    varCircle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    varCircle.Select();
                    canvas.DeselectAllObject();
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
