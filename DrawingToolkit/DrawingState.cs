using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class DrawingState
    {
        public DrawingState State
        {
            get
            {
                return this.State;
            }
        }
        private DrawingState state;
        public abstract void Draw(DrawingObject obj);
        public virtual void Deselect(DrawingObject obj)
        {

        }
        public virtual void Select(DrawingObject obj)
        {

        }
    }
}
