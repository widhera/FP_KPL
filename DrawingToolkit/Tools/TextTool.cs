using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class TextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        public string passingtext;
        private DrawingObject selectedObject;
        private int xInitial;
        private int yInitial;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public TextTool()
        {
            this.Name = "Text tool";
            this.ToolTipText = "Text tool";
            //this.Image = IconSet.cursor;
            this.Text = "Text Tool";
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                selectedObject = canvas.GetObjectAt(e.X, e.Y);
                
                if (selectedObject != null)
                {
                    Debug.WriteLine("MAsuk");
                    passingtext = selectedObject.GetText();
                    using (Form2 form2 = new Form2(passingtext, selectedObject, canvas))
                    {
                        if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            form2.ShowDialog();
                        }
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
