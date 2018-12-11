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
    public class RemoveChartPointTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private DrawingObject PointArea;
        private int xInitial;
        private int yInitial;
        private Pen pen;
        DrawingObject NeighbourKiri;
        DrawingObject NeighbourKanan;
        DrawingObject varConnector;

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


        public RemoveChartPointTool()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 2.5f;
            this.Name = "Remove Point tool";
            this.ToolTipText = "Remove Point tool";
            //this.Image = IconSet.cursor;
            this.Text = "Remove Point";
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

            this.xInitial = e.X;
            this.yInitial = e.Y;
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObject();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject != null)
                {
                    PointArea = selectedObject.GetPointArea();

                    int index = PointArea.GetIndexPoint(selectedObject);
                    int count = PointArea.GetPointCount();


                    if (index > 0)
                    {
                        NeighbourKiri = PointArea.GetNeighbourKiri(selectedObject);
                    }
                    if(index != count - 1)
                    {
                        NeighbourKanan = PointArea.GetNeighbourKanan(selectedObject);
                    }
                    
                    DrawingObject kanan = PointArea.GetConnectorKanan(selectedObject);
                    DrawingObject kiri = PointArea.GetConnectorKiri(selectedObject);
                    
                    if(kiri != null)
                    {
                        PointArea.RemoveConnector(kiri);
                        canvas.RemoveObject(kiri);
                    }
                    if (kanan != null)
                    {
                        PointArea.RemoveConnector(kanan);
                        canvas.RemoveObject(kanan);
                    }
                    if(index >0 && index < count -1)
                    {
                        Connector connector = new Connector(new Point(NeighbourKiri.GetStartpoint().X + 3, NeighbourKiri.GetStartpoint().Y + 3));
                        connector.Endpoint = new System.Drawing.Point(NeighbourKanan.GetStartpoint().X + 3, NeighbourKanan.GetStartpoint().Y + 3);
                        connector.SetSource(NeighbourKiri);
                        connector.SetDestination(NeighbourKanan);
                        varConnector = connector;
                        PointArea.AddConnectorPoint(connector);
                        canvas.AddDrawingObject(connector);
                    }
                    PointArea.RemovePoint(selectedObject);
                    canvas.RemoveObject(selectedObject);

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
                if (varConnector != null)
                {
                    varConnector.Select();
                    canvas.DeselectAllObject();
                }
            }
        }
    }
}
