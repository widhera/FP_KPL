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
        private ChartPoint varChartPoint;
        private Connector varConnector;
        private DrawingObject PointArea;
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
            PointArea = chart;
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (chart != null)
            {
                if (e.Button == MouseButtons.Left && canvas != null)
                {
                    varChartPoint = new ChartPoint(e.Location,chart);
                    
                    if (PointArea.Intersect(e.X, e.Y))
                    {
                        if (PointArea.GetPointAreaIntersect(varChartPoint, e.X, e.Y))
                        {
                            chart.AddGraphPoint(varChartPoint);
                            canvas.AddDrawingObject(varChartPoint);
                            if(chart.GetPointCount() > 1)
                            {
                                DrawingObject Neighbour = chart.GetNeighbourKiri(varChartPoint);
                                Connector connector = new Connector(new Point(Neighbour.GetStartpoint().X+3, Neighbour.GetStartpoint().Y + 3));
                                connector.Endpoint =  new System.Drawing.Point(varChartPoint.GetStartpoint().X+3, varChartPoint.GetStartpoint().Y+3);
                                connector.SetSource(Neighbour);
                                connector.SetDestination(varChartPoint);
                                varConnector = connector;
                                chart.AddConnectorPoint(connector);
                                canvas.AddDrawingObject(connector);
                            }
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
                if (varChartPoint != null)
                {
                    varChartPoint.Select();
                    //canvas.DeselectAllObject();
                    if(varConnector != null)
                        varConnector.Select();
                    canvas.DeselectAllObject();
                }
            }
        }
    }
}
