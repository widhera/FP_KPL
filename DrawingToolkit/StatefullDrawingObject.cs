﻿using DrawingToolkit.States;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class StatefullDrawingObject 
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }
        private DrawingState state;
        
        public abstract void RenderOnStaticView();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnPreview();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public StatefullDrawingObject()
        {
            this.ChangeState(PreviewState.GetInstance()); //default initial state
        }

        public override void Draw()
        {
            this.state.Draw(this);
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
