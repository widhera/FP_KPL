﻿using DrawingToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class ChartTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Chart varChart;
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
        public ChartTool()
        {
            this.Name = "Stateful Chart tool";
            this.ToolTipText = "Stateful Chart tool";
            this.Text = "Chart State";
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                //DrawingObject clickObject = canvas.GetCanvasObject(e.X,e.Y);
                varChart = new Chart(new System.Drawing.Point(e.X, e.Y));
                varChart.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(varChart);
            }
            if (e.Button == MouseButtons.Right)
            {
                if(varChart.GetPointChartAll().Count == 0 || varChart.GetLabelYAll().Count ==0)
                {
                    string s = "Isi point dan label x menggunakan XValue dan label y dengan YValue";
                    using (Notifikasi form = new Notifikasi(s))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    using (TableChart form = new TableChart(varChart, canvas))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            form.ShowDialog();
                        }
                    }
                }
                
            }

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                if (this.varChart != null)
                {
                    varChart.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            Point temp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                if (this.varChart != null)
                {
                    varChart.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    varChart.Select();
                    canvas.DeselectAllObject();
                }
            }
            
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
