using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.Shapes
{
    public class StatefullLine : DrawingObject
    {
        private const double EPSILON = 3.0;
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Pen pen;
        public StatefullLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }
        public StatefullLine(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }
        public StatefullLine(Point startpoint, Point endpoint) :
           this(startpoint)
        {
            this.Endpoint = endpoint;
        }
        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
        public override void RenderOnEditingView()
        {
            //RenderOnStaticView();
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }
        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
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
            throw new NotImplementedException();
        }

        public override bool GetPointAreaIntersect(DrawingObject point, int xTest, int yTest)
        {
            throw new NotImplementedException();
        }

        public override Point GetStartpoint()
        {
            throw new NotImplementedException();
        }

        public override void SetSource(DrawingObject src)
        {
            throw new NotImplementedException();
        }

        public override void SetDestination(DrawingObject dst)
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

        public override void ChangeColorShape(Pen p)
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetPointChartAll()
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetPointConnectorAll()
        {
            throw new NotImplementedException();
        }

        public override void RemoveConnector(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override void RemovePoint(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetNeighbourKiri(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetNeighbourKanan(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override int GetIndexPoint(DrawingObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
