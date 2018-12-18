using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.Shapes
{
    public class Connector : DrawingObject
    {
        private const double EPSILON = 3.0;
        private DrawingObject source;
        private DrawingObject destination;
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Pen pen;
        public Connector()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 2.5f;
        }
        public Connector(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }
        public Connector(Point startpoint, Point endpoint) :
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
            return this.Startpoint;
        }

        public override void SetSource(DrawingObject src)
        {
            this.source = src;
        }

        public override void SetDestination(DrawingObject dst)
        {
            this.destination = dst;
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
            return this.source;
        }

        public override DrawingObject GetDestination()
        {
            return this.destination;
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
            this.Startpoint = e;
        }

        public override void ChangeEndpoint(Point e)
        {
            this.Endpoint = e;
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

        public override void ChangeText(string s)
        {
            throw new NotImplementedException();
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override Point GetEndpoint()
        {
            throw new NotImplementedException();
        }

        public override void AddXPoint(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override void AddXLabel(DrawingObject label)
        {
            throw new NotImplementedException();
        }

        public override void AddYPoint(DrawingObject point)
        {
            throw new NotImplementedException();
        }

        public override void AddYLabel(DrawingObject label)
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetPointXtAll()
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetPointYAll()
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetLabelXAll()
        {
            throw new NotImplementedException();
        }

        public override List<DrawingObject> GetLabelYAll()
        {
            throw new NotImplementedException();
        }

        public override void ChangePointChart(DrawingObject old, DrawingObject newest)
        {
            throw new NotImplementedException();
        }
    }
}
