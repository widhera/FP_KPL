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
    public class ChartPoint : DrawingObject
    {
        public Point Startpoint { get; set; }
        private Pen pen;

        public ChartPoint()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }
        public ChartPoint(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }

        public void DrawPoint(Graphics g,Pen pen)
        {
           
                Debug.WriteLine(this.Startpoint);
                g.DrawEllipse(pen, this.Startpoint.X, this.Startpoint.Y, 5, 5);
           
        }

        public override void RenderOnStaticView()
        {
            
        }
        public override void RenderOnEditingView()
        {
            
        }
        public override void RenderOnPreview()
        {
            
        }

        public override bool Intersect(int xTest, int yTest)
        {
            Point start = this.Startpoint;
            // Point test = e.Location;

            if ((xTest >= start.X-5 && xTest <= start.X + 5) && (yTest >= start.Y-5 && yTest <= start.Y + 5))
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

        public override void AddGraphPoint(Point location)
        {
            throw new NotImplementedException();
        }
    }
}
