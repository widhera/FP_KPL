using System;
using System.Collections.Generic;
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
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.FillEllipse(myBrush, this.Startpoint.X, this.Startpoint.Y, 6, 6);
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
