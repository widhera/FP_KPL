using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.Shapes
{

    public class ChartPoint : DrawingObject
    {
        private Point Startpoint { get; set; }
        public DrawingObject PointArea { get; set; }
        private Pen pen;
        private Graphics graphics;

        public ChartPoint()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }
        public ChartPoint(Point startpoint,DrawingObject chart) :
           this()
        {
            this.Startpoint = startpoint;
            this.PointArea = chart;
        }
        
        public void DrawPoint(Graphics g,Pen pen)
        {
           
                this.graphics = g;
                graphics.DrawEllipse(pen, this.Startpoint.X, this.Startpoint.Y, 6, 6);
           
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawEllipse(pen, this.Startpoint.X, this.Startpoint.Y, 6, 6);
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawEllipse(pen, this.Startpoint.X, this.Startpoint.Y, 6, 6);
            }
        }
        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawEllipse(pen, this.Startpoint.X, this.Startpoint.Y, 6, 6);
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            Point start = this.Startpoint;
            // Point test = e.Location;
            Debug.WriteLine("Omasuyk");
            if ((xTest >= start.X && xTest <= start.X+6) && (yTest >= start.Y && yTest <= start.Y + 6))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
        }

        
        public override DrawingObject SelectObjectAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void AddGraphPoint(DrawingObject chartpoint)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetPointArea()
        {
            return this.PointArea;
        }

        public override bool GetPointAreaIntersect(DrawingObject point, int xTest, int yTest)
        {
            throw new NotImplementedException();
        }

        public override Point GetStartpoint()
        {
            return this.Startpoint;
        }

        public override void SetSource(DrawingObject src)
        {
            throw new NotImplementedException();
        }

        public override void SetDestination(DrawingObject dst)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetNeighbour(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override int GetPointCount()
        {
            throw new NotImplementedException();
        }

        public override void AddConnectorPoint(DrawingObject connector)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetSource()
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetDestination()
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetConnectorKiri(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetConnectorKanan(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override void ChangeStartpoint(Point e)
        {
            throw new NotImplementedException();
        }

        public override void ChangeEndpoint(Point e)
        {
            throw new NotImplementedException();
        }
    }
}
