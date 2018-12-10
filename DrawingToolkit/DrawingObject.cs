﻿using DrawingToolkit.States;
using System;
using System.Diagnostics;
using System.Drawing;
using DrawingToolkit.Shapes;
using System.Collections.Generic;

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
        public abstract DrawingObject SelectObjectAt(int x, int y);

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }
        public abstract void AddGraphPoint(DrawingObject chartpoint);
        public abstract DrawingObject GetPointArea();
        public abstract bool GetPointAreaIntersect(DrawingObject point,int xTest, int yTest);
        public abstract Point GetStartpoint();
        public abstract void SetSource(DrawingObject src);
        public abstract void SetDestination(DrawingObject dst);
        public abstract DrawingObject GetNeighbour(DrawingObject point);
        public abstract int GetPointCount();
        public abstract void AddConnectorPoint(DrawingObject connector);
        public abstract DrawingObject GetSource();
        public abstract DrawingObject GetDestination();
        public abstract DrawingObject GetConnectorKiri(DrawingObject point);
        public abstract DrawingObject GetConnectorKanan(DrawingObject point);
        public abstract void ChangeStartpoint(Point e);
        public abstract void ChangeEndpoint(Point e);


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
