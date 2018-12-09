using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawingToolkit.Shapes
{
    public class  Chart : DrawingObject
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Pen pen;
        private List <Point> GraphPoint;
        //Point point1 = new Point(50, 50);
        //Point point2 = new Point(50, 100);
        //Point point3 = new Point(100, 100);
        //private Point[] HorizontalVertikal;

        public Chart()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            this.GraphPoint = new List<Point>();
        }
        public Chart(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }
        public Chart(Point startpoint, Point endpoint) :
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
                DrawChartElement();
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            
            if (this.Graphics != null)
            {
                DrawChartElement();
            }
        }
        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                DrawChartElement();
            }
        }
        public void DrawChartElement()
        {
            Rectangle temp = this.GetAreaIntersectChart();
            Point[] curvePoint = this.GetCurvePoint();
            this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.Graphics.DrawRectangle(pen, temp);
            this.Graphics.DrawLines(pen, curvePoint);
            if(this.GraphPoint!= null)
            {
                
                this.DrawPoint();
            }

        }
      

        private void DrawPoint()
        {
            foreach(Point e in GraphPoint)
            {
                this.Graphics.DrawEllipse(pen, e.X, e.Y, 5, 5);
            }
        }

        public Point[] GetCurvePoint()
        {
            Point Start = this.Startpoint;
            Point End = this.Endpoint;
            Point point1 = new Point(Start.X, Start.Y);
            Point point2 = new Point(Start.X, End.Y);
            Point point3 = new Point(End.X, End.Y);
            Point[] curvePoint =
            {
                point1,
                point2,
                point3
            };
            return curvePoint;
        }

        public override void AddGraphPoint(Point e)
        {
            Debug.WriteLine("Masukk");
            this.GraphPoint.Add(e);
        }

        

        public Rectangle GetAreaIntersectChart()
        {
            Point start = this.Startpoint;
            Point end = this.Endpoint;
            if (start.X > end.X)
            {
                var temp = start.X;
                start.X = end.X;
                end.X = temp;
            }
            if (start.Y > end.Y)
            {
                var temp = start.Y;
                start.Y = end.Y;
                end.Y = temp;
            }
            Rectangle objek = new Rectangle((start.X-30), (start.Y-30), (end.X+30) - (start.X-30), (end.Y+30) - (start.Y-30));
            return objek;
        }

        public override bool Intersect(int xTest, int yTest)
        {

            Point start = this.Startpoint;
            Point end = this.Endpoint;
            // Point test = e.Location;

            if ((xTest >= start.X && xTest <= start.X + (end.X - start.X)) && (yTest >= start.Y && yTest <= start.Y + (end.Y - start.Y)))
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
            for (int i = 0; i < GraphPoint.Count; i++)
            {
                Point temp = new Point(this.GraphPoint[i].X + xAmount, this.GraphPoint[i].Y+ yAmount);
                this.GraphPoint[i] = temp;


            }
        }
    }
}
