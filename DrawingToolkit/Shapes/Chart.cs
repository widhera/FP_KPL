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
        private List<DrawingObject> xPoint;
        private List<DrawingObject> xLabel;
        private List<DrawingObject> yPoint;
        private List<DrawingObject> yLabel;
        private List<DrawingObject> GraphPoint;
        private List<DrawingObject> ConnectorPoint;

        public Chart()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            this.GraphPoint = new List<DrawingObject>();
            this.ConnectorPoint = new List<DrawingObject>();
            this.xPoint = new List<DrawingObject>();
            this.xLabel = new List<DrawingObject>();
            this.yPoint = new List<DrawingObject>();
            this.yLabel = new List<DrawingObject>();
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
            pen.Width = 2.0f;
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            if (this.Graphics != null)
            {
                DrawChartElement();
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 2.0f;
            
            if (this.Graphics != null)
            {
                DrawChartElement();
            }
        }
        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 2.0f;
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
        }
      

        private void DrawPoint()
        {
            foreach(ChartPoint chartpoint in GraphPoint)
            {
                chartpoint.DrawPoint(this.Graphics,pen);
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

        public override void AddGraphPoint(DrawingObject chartPoint)
        {
            this.GraphPoint.Add(chartPoint);
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
            Rectangle objek = new Rectangle((start.X-70), (start.Y-70), (end.X+50) - (start.X-50), (end.Y+60) - (start.Y-60));
            return objek;
        }

        public override bool Intersect(int xTest, int yTest)
        {

            Point start = this.Startpoint;
            Point end = this.Endpoint;

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
            foreach(ChartPoint chart in GraphPoint)
            {
                chart.Translate(x,y,xAmount, yAmount);
            }
            foreach (Connector connector in ConnectorPoint)
            {
                connector.Translate(x, y, xAmount, yAmount);
            }
            foreach (DrawingObject point in xPoint)
            {
                point.Translate(x, y, xAmount, yAmount);
            }
            foreach (DrawingObject point in yPoint)
            {
                point.Translate(x, y, xAmount, yAmount);
            }
            foreach (DrawingObject label in xLabel)
            {
                label.Translate(x, y, xAmount, yAmount);
            }
            foreach (DrawingObject label in yLabel)
            {
                label.Translate(x, y, xAmount, yAmount);
            }
        }
        public DrawingObject GetObjectAt(int x, int y)
        {
            foreach (DrawingObject obj in GraphPoint)
            {
                if (obj.Intersect(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        

        public override DrawingObject SelectObjectAt(int x, int y)
        {
            DrawingObject obj = GetObjectAt(x, y);
            if (obj != null)
            {
                obj.Select();
            }
            return obj;
        }

        public override DrawingObject GetPointArea()
        {
            throw new NotImplementedException();
        }

        public override bool GetPointAreaIntersect(DrawingObject point,int xTest, int yTest)
        {
            int startY = this.Startpoint.Y;
            int endY = this.Endpoint.Y;
            int startX;
            int endX;

            int indexpoint = GraphPoint.IndexOf(point);

            if (GraphPoint.Count > 0)
            {
                if(indexpoint == -1)
                {
                    startX = GraphPoint[GraphPoint.Count - 1].GetStartpoint().X+3;
                    endX = this.Endpoint.X;
                }
                else
                {
                    if (indexpoint == 0)
                    {
                        if(GraphPoint.Count > 1)
                        {
                            startX = this.Startpoint.X;
                            endX = GraphPoint[indexpoint + 1].GetStartpoint().X+3;
                        }
                        else
                        {
                            startX = this.Startpoint.X;
                            endX = this.Endpoint.X;
                        }
                        
                    }
                    else if (indexpoint == GraphPoint.Count - 1)
                    {
                        startX = GraphPoint[indexpoint - 1].GetStartpoint().X+3;
                        endX = this.Endpoint.X;
                    }

                    else
                    {
                        startX = GraphPoint[indexpoint - 1].GetStartpoint().X+3;
                        endX = GraphPoint[indexpoint + 1].GetStartpoint().X+3;
                    }
                }
                
                
            }

            else
            {
                startX = this.Startpoint.X;
                endX = this.Endpoint.X;
            }
            


            if ((xTest >= startX && xTest <= startX + (endX - startX)) && (yTest >= startY && yTest <= startY + (endY - startY)))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override Point GetStartpoint()
        {
            return this.Startpoint;
        }

        public override Point GetEndpoint()
        {
            return this.Endpoint;
        }

        public override void SetSource(DrawingObject src)
        {
            throw new NotImplementedException();
        }

        public override void SetDestination(DrawingObject dst)
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetNeighbourKiri(DrawingObject point)
        {
            DrawingObject negih = GraphPoint[(GraphPoint.IndexOf(point)) - 1];
            return negih;
        }
        public override DrawingObject GetNeighbourKanan(DrawingObject point)
        {
            DrawingObject negih = GraphPoint[(GraphPoint.IndexOf(point)) + 1];
            return negih;
        }

        public override int GetPointCount()
        {
            return GraphPoint.Count;
        }

        public override int GetIndexPoint(DrawingObject obj)
        {
            return GraphPoint.IndexOf(obj);
        }
        public override void AddConnectorPoint(DrawingObject connector)
        {
            ConnectorPoint.Add(connector);
        }

        public override DrawingObject GetConnectorKiri(DrawingObject point)
        {
            foreach(Connector conn in ConnectorPoint)
            {
                if(point == conn.GetDestination())
                {
                    return conn;
                }
            }
            return null;
        }

        public override DrawingObject GetConnectorKanan(DrawingObject point)
        {
            foreach (Connector conn in ConnectorPoint)
            {
                if (point == conn.GetSource())
                {
                    return conn;
                }
            }
            return null;
        }

        public override DrawingObject GetSource()
        {
            throw new NotImplementedException();
        }

        public override DrawingObject GetDestination()
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
            return GraphPoint;
        }

        public override List<DrawingObject> GetPointConnectorAll()
        {
            return ConnectorPoint;
        }

        public override void RemoveConnector(DrawingObject obj)
        {
            this.ConnectorPoint.Remove(obj);
        }

        public override void RemovePoint(DrawingObject obj)
        {
            this.GraphPoint.Remove(obj);
        }

        public override void ChangeText(string s)
        {
            throw new NotImplementedException();
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void AddXPoint(DrawingObject point)
        {
            this.xPoint.Add(point);
        }

        public override void AddXLabel(DrawingObject label)
        {
            this.xLabel.Add(label);
        }

        public override void AddYPoint(DrawingObject point)
        {
            this.yPoint.Add(point);
        }

        public override void AddYLabel(DrawingObject label)
        {
            this.yLabel.Add(label);
        }

        public override List<DrawingObject> GetPointXtAll()
        {
            return xPoint;
        }

        public override List<DrawingObject> GetPointYAll()
        {
            return yPoint;
        }

        public override List<DrawingObject> GetLabelXAll()
        {
            return xLabel;
        }
        public override List<DrawingObject> GetLabelYAll()
        {
            return yLabel;
        }
    }
}
