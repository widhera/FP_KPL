using DrawingToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    class AddPointTool : ToolStripButton, ITool
    {
        private DrawingObject selectedObject;
        private ICanvas canvas;
        private DrawingObject varChart;
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
        public AddPointTool()
        {
            this.Name = "Stateful Add Chart Point tool";
            this.ToolTipText = "Stateful Add Chart Point tool";
            this.Text = "Add Chart Point";
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            DrawingObject chart = canvas.GetChart(e.Location.X, e.Location.Y);
            if (chart != null)
            {
                Debug.WriteLine(e.Location);
                chart.AddGraphPoint(new Point(e.X,e.Y));
                //varChart = chart;
                //canvas.AddDrawingObject(varChart);
                ////chart.Select();
            }
                
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    if (this.varChart != null)
            //    {
            //        varChart.Select();
            //    }
            //}
        }
    }
}
