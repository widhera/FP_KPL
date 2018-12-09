﻿using DrawingToolkit.States;
using System;
using System.Diagnostics;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Guid ID { get; set; }
        public Graphics Graphics { get; set; }

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }
        private DrawingState state;
        private Graphics graphics;

        public DrawingObject()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance());
        }

        public abstract bool Intersect(int xTest, int yTest);
        public abstract void Translate(int x, int y, int xAmount, int yAmount);

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }
        public abstract void AddGraphPoint(Point location);
        public virtual void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void Select()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is selected.");
            this.state.Select(this);
        }

        public void Deselect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is deselected.");
            this.state.Deselect(this);
        }
    }
}
