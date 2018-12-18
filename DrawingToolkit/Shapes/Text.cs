using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace DrawingToolkit.Shapes
{
    public class Text : DrawingObject
    {
        private string text;
        private Font font;
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Pen pen;
        public Text()
        {
            this.text = "Text";
            this.font = new Font("Arial", 12.0f);
            //this.textBox1.Location = new System.Drawing.Point(77, 36);
            //this.textBox1.Name = "textBox1";
            //this.textBox1.Size = new System.Drawing.Size(216, 20);
            //this.textBox1.TabIndex = 1;
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }
        public Text(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }
        public Text(Point startpoint, Point endpoint) :
           this(startpoint)
        {
            this.Endpoint = endpoint;
        }
        private Rectangle DrawFormula()
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
            Rectangle objek = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            return objek;
        }

        public override void RenderOnStaticView()
        {
            Point start = this.Startpoint;
            Point end = this.Endpoint;
            if (this.Graphics != null)
            {

                Rectangle temp = this.DrawFormula();
                var textSize = this.Graphics.MeasureString(this.text, this.font);
                var state = this.Graphics.Save();

                float pos1 = (((end.X - start.X)*2 - (textSize.Width)*2) / 4) + this.Startpoint.X;
                float pos2 = (((end.Y - start.Y)*2 - (textSize.Height)*2) / 4) + this.Startpoint.Y;
                PointF aaa = new PointF(pos1, pos2);

                //this.Graphics.TranslateTransform(temp.Left, temp.Top);
                //this.Graphics.ScaleTransform(temp.Width / textSize.Width, temp.Height / textSize.Height);
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //this.Graphics.DrawRectangle(pen, temp);

                this.Graphics.DrawString(this.text, font, brush, aaa);
                this.Graphics.Restore(state);

            }
        }
        public override void RenderOnEditingView()
        {
            Pen tempPen = this.pen;
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                Rectangle temp = this.DrawFormula();

                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                this.Graphics.DrawRectangle(pen, temp);
            }
            this.pen = tempPen;
        }
        public override void RenderOnPreview()
        {
            Pen tempPen = this.pen;
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                Rectangle temp = this.DrawFormula();

                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, temp);
            }
            this.pen = tempPen;
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
            this.pen = p;
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
            this.text = s;
        }

        public override string GetText()
        {
            return this.text;
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
