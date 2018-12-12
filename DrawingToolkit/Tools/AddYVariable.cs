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
    class AddYVariable : ToolStripButton, ITool
    {
        private List<DrawingObject> varChartPoint;
        private DrawingObject PointArea;
        private List<DrawingObject> textX;
        private ICanvas canvas;
        private int xInitial;
        private int yInitial;

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
        public AddYVariable()
        {
            this.textX = new List<DrawingObject>();
            this.varChartPoint = new List<DrawingObject>();
            this.Name = "Y Variable tool";
            this.ToolTipText = "Y Variable tool";
            this.Text = "Y Variable";
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
            PointArea = chart;
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (chart != null)
            {
                if (e.Button == MouseButtons.Left && canvas != null)
                {
                    bool isAllowed = false;
                    if (chart.GetPointYAll().Count < 1)
                    {
                        isAllowed = true;
                    }
                    if (isAllowed)
                    {
                        int xChart = chart.GetStartpoint().X;
                        int endyChart = chart.GetStartpoint().Y;
                        int startyChart = chart.GetEndpoint().Y;
                        int temp = e.Y - startyChart;
                        int charty = startyChart + temp;
                        int county = (endyChart - startyChart) / temp;
                        //int yTemp = 
                        DrawingObject point;
                        for (int i = 0; i < county; i++)
                        {
                            point = new ChartPoint(new Point(xChart - 6, charty - 3), chart);
                            chart.AddYPoint(point);
                            canvas.AddDrawingObject(point);
                            Text text = new Text(new Point(xChart - 60, charty + temp / 2));
                            text.Endpoint = new Point(xChart - 6, charty - temp / 2);
                            text.ChangeText("Text" + (i + 1));
                            chart.AddYLabel(text);
                            canvas.AddDrawingObject(text);
                            this.varChartPoint.Add(point);
                            this.textX.Add(text);
                            charty += temp;
                        }
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.textX != null)
                {
                    foreach (DrawingObject obj in textX)
                    {
                        obj.Select();
                    }
                }
                canvas.DeselectAllObject();

            }
        }
    }
}
