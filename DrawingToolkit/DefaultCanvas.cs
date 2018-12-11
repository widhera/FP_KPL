using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DrawingToolkit.Shapes;

namespace DrawingToolkit
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool activeTool;
        private List<DrawingObject> drawingObjects; //menampung jumlah object yang digambar

        public DefaultCanvas()
        {
            Init();
        }

        private void Init()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;

        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            
                if (this.activeTool != null)
                {
                    this.activeTool.ToolMouseDown(sender, e);
                    this.Repaint();
                }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            


            //// Create points that define polygon.
            //Point point1 = new Point(50, 50);
            //Point point2 = new Point(50, 100);
            //Point point3 = new Point(100, 100);
            ////Point point4 = new Point(250, 50);
            ////Point point5 = new Point(300, 100);
            ////Point point6 = new Point(350, 200);
            ////Point point7 = new Point(250, 250);
            //Point[] curvePoints =
            //         {
            //    point1,
            //    point2,
            //    point3

            // };

            // Draw polygon to screen.
            //e.Graphics.DrawLines(blackPen, curvePoints);
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Graphics = e.Graphics;
                obj.Draw();
            }

        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
            
        }

        public DrawingObject GetObjectAt(int x, int y)
        {
            if (this.activeTool.GetType().Name == "SelectPointTool" || this.activeTool.GetType().Name == "RemoveChartPointTool")
            {
                foreach (DrawingObject obj in drawingObjects)
                {
                    if (obj.GetType().Name == "ChartPoint")
                    {
                        if (obj.Intersect(x, y))
                        {
                            return obj;
                        }
                    }  
                }
            }
            else
            {
                foreach (DrawingObject obj in drawingObjects)
                {
                    if (obj.Intersect(x, y))
                    {
                        return obj;
                    }
                }
            }
            return null;
        }

        public DrawingObject SelectObjectAt(int x, int y)
        {
            DrawingObject obj = GetObjectAt(x, y);
            if (obj != null)
            {
                obj.Select();
            }
            return obj;
        }

        public DrawingObject GetChart(int x, int y)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                if(obj.GetType().Name == "Chart")
                {
                    if (obj.Intersect(x, y))
                    {
                        return obj;
                    }
                }
                
            }
            return null;
        }

        public List<DrawingObject>GetCanvasObject()
        {
            return drawingObjects;
        }
        public void DeselectAllObject()
        {
            foreach(DrawingObject drawObj in drawingObjects)
            {
                drawObj.Deselect();
            }
        }

        public void RemoveObject(DrawingObject obj)
        {
            this.drawingObjects.Remove(obj);
        }
    }
}
