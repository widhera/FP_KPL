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
    public class SelectPointTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private DrawingObject PointArea;
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


        public SelectPointTool()
        {
            this.Name = "Select Point tool";
            this.ToolTipText = "Select Point tool";
            //this.Image = IconSet.cursor;
            this.Text = "Select Point";
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
                }
                
            }

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {

                if (selectedObject != null)
                {
                    if (PointArea.Intersect(e.X,e.Y))
                    {
                        if(PointArea.GetPointAreaIntersect(selectedObject,e.X, e.Y))
                        {
                            int xAmount = 0;
                            int yAmount = e.Y - yInitial;
                            xInitial = e.X;
                            yInitial = e.Y;
                            selectedObject.Translate(xInitial, e.Y, xAmount, yAmount);
                            DrawingObject kiri = PointArea.GetConnectorKiri(selectedObject);
                            DrawingObject kanan = PointArea.GetConnectorKanan(selectedObject);
                            if(kiri!=null)
                                kiri.ChangeEndpoint(new Point(selectedObject.GetStartpoint().X + 3, selectedObject.GetStartpoint().Y + 3));
                            if (kanan != null)
                                kanan.ChangeStartpoint(new Point(selectedObject.GetStartpoint().X + 3, selectedObject.GetStartpoint().Y + 3));
                        }
                       
                    }
                    
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
