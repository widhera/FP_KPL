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
    public class RemoveTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private DrawingObject PointArea;
        private int xInitial;
        private int yInitial;
        private Pen pen;

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


        public RemoveTool()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 2.5f;
            this.Name = "Remove tool";
            this.ToolTipText = "Remove tool";
            //this.Image = IconSet.cursor;
            this.Text = "Remove Shape";
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
                selectedObject = canvas.GetObjectAt(e.X, e.Y);
                if (selectedObject != null)
                {
                    if (selectedObject.GetType().Name == "Chart")
                    {
                        int listRange = selectedObject.GetPointChartAll().Count + selectedObject.GetPointConnectorAll().Count + selectedObject.GetPointXtAll().Count + selectedObject.GetPointYAll().Count + selectedObject.GetLabelXAll().Count + selectedObject.GetLabelYAll().Count;
                        List<DrawingObject> ChartElementRemove = new List<DrawingObject>(listRange);
                        ChartElementRemove.AddRange(selectedObject.GetPointChartAll());
                        ChartElementRemove.AddRange(selectedObject.GetPointConnectorAll());
                        ChartElementRemove.AddRange(selectedObject.GetPointXtAll());
                        ChartElementRemove.AddRange(selectedObject.GetPointYAll());
                        ChartElementRemove.AddRange(selectedObject.GetLabelXAll());
                        ChartElementRemove.AddRange(selectedObject.GetLabelYAll());
                        ChartElementRemove.ForEach(canvas.RemoveObject);
                    }
                    
                    canvas.RemoveObject(selectedObject);
                }

            }

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
