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
    class AddXVariable : ToolStripButton, ITool
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
        public AddXVariable()
        {
            this.textX = new List <DrawingObject>();
            this.varChartPoint = new List<DrawingObject>();
            this.Name = "X Variable tool";
            this.ToolTipText = "X Variable tool";
            this.Text = "X Variable";
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
                    bool isAllowed = false ;
                    if(chart.GetPointXtAll().Count < 1)
                    {
                        isAllowed = true;
                    }
                    if (isAllowed)
                    {
                        int yChart = chart.GetEndpoint().Y;
                        int yPointChart = chart.GetStartpoint().Y;
                        int endxChart = chart.GetEndpoint().X;
                        int startxChart = chart.GetStartpoint().X;
                        int temp = e.X - startxChart;
                        int chartx = startxChart + temp;
                        int countx = (endxChart - startxChart) / temp;
                        DrawingObject point;
                        for (int i = 0; i < countx; i++)
                        {
                            ChartPoint varChartPoint = new ChartPoint(new Point(chartx - 3, yPointChart), chart);
                            chart.AddGraphPoint(varChartPoint);
                            canvas.AddDrawingObject(varChartPoint);
                            varChartPoint.Select();
                            if (chart.GetPointCount() > 1)
                            {
                                DrawingObject Neighbour = chart.GetNeighbourKiri(varChartPoint);
                                Connector connector = new Connector(new Point(Neighbour.GetStartpoint().X + 3, Neighbour.GetStartpoint().Y + 3));
                                connector.Endpoint = new System.Drawing.Point(varChartPoint.GetStartpoint().X + 3, varChartPoint.GetStartpoint().Y + 3);
                                connector.SetSource(Neighbour);
                                connector.SetDestination(varChartPoint);
                                //varConnector = connector;
                                chart.AddConnectorPoint(connector);
                                canvas.AddDrawingObject(connector);
                                
                                connector.Select();
                                canvas.DeselectAllObject();
                            }

                            point = new ChartPoint(new Point(chartx - 3, yChart), chart);
                            chart.AddXPoint(point);
                            point.Select();
                            canvas.AddDrawingObject(point);
                            Text text = new Text(new Point(chartx - temp / 2, yChart + 6));
                            text.Endpoint = new Point(chartx + temp / 2, yChart + 33);
                            text.ChangeText("Text" + (i + 1));
                            chart.AddXLabel(text);
                            canvas.AddDrawingObject(text);
                            this.varChartPoint.Add(point);
                            this.textX.Add(text);
                            chartx += temp;
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
