using System;
using DrawingToolkit.Shapes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class TableChart : Form
    {
        private DrawingObject chart;
        private ICanvas canvas;
        public TableChart(DrawingObject obj, ICanvas canvas)
        {
            InitializeComponent();
            this.chart = obj;
            this.canvas = canvas;
            this.label4.Text = "Max point value is "+(Math.Sqrt(Math.Pow((this.chart.GetStartpoint().Y - this.chart.GetEndpoint().Y),2))).ToString();
        }
        DataTable dt = new DataTable();

        void CreateTable()
        {
            List <DrawingObject> pointChart = chart.GetPointChartAll();
            List<DrawingObject> xValue = chart.GetLabelXAll();
            dt.Columns.Add("No");
            dt.Columns.Add("Value");

            int i = 0;
            foreach (DrawingObject point in pointChart)
            {
                Double data = Math.Sqrt(Math.Pow((point.GetStartpoint().Y - this.chart.GetEndpoint().Y),2));
                dt.Rows.Add(xValue[i].GetText(), data);
                i++;
            }

            dataGridView1.DataSource = dt;

        }
        
        DataTable dtYvalue = new DataTable();
        void CreateTableYvalue()
        {
            List<DrawingObject> yValue = chart.GetLabelYAll();
            dtYvalue.Columns.Add("Y Value");
            dtYvalue.Columns.Add("Value");

            int i = 1;
            foreach (DrawingObject point in yValue)
            {
                dtYvalue.Rows.Add(i, point.GetText());
                i++;
            }

            dataGridView3.DataSource = dtYvalue;

        }


        private void TableChart_Load(object sender, EventArgs e)
        {
            CreateTable();
            CreateTableYvalue();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DrawingObject> pointChart = chart.GetPointChartAll();
            List<DrawingObject> xValue = chart.GetLabelXAll();
            for (int i=0;i< pointChart.Count; i++)
            {
                Debug.WriteLine((-1 * Int32.Parse(dt.Rows[i][1].ToString()) + chart.GetEndpoint().Y));
                Debug.WriteLine(pointChart[i].GetStartpoint().Y);
                if (pointChart[i].GetStartpoint().Y != (-1 * Int32.Parse(dt.Rows[i][1].ToString()) + chart.GetEndpoint().Y) && (Int32.Parse(dt.Rows[i][1].ToString())) >=0 && (Int32.Parse(dt.Rows[i][1].ToString())) <= (Math.Sqrt(Math.Pow((this.chart.GetStartpoint().Y - this.chart.GetEndpoint().Y), 2))))
                {
                    Point centerpoint = pointChart[i].GetStartpoint();
                    int xAmount = 0;
                    int yAmount = (-1*Int32.Parse(dt.Rows[i][1].ToString()) + chart.GetEndpoint().Y) - centerpoint.Y;
                    int xInitial = centerpoint.X;
                    int yInitial = centerpoint.Y;
                    pointChart[i].Translate(xInitial, yInitial, xAmount, yAmount);
                    DrawingObject kiri = chart.GetConnectorKiri(pointChart[i]);
                    DrawingObject kanan = chart.GetConnectorKanan(pointChart[i]);
                    if (kiri != null)
                        kiri.ChangeEndpoint(new Point(pointChart[i].GetStartpoint().X + 3, pointChart[i].GetStartpoint().Y + 3));
                    if (kanan != null)
                        kanan.ChangeStartpoint(new Point(pointChart[i].GetStartpoint().X + 3, pointChart[i].GetStartpoint().Y + 3));
                }
                
                if(xValue[i].GetText() != dt.Rows[i][0].ToString())
                {
                    List<DrawingObject> CanvasObject = canvas.GetCanvasObject();
                    foreach (DrawingObject obj in CanvasObject)
                    {
                        if (obj == xValue[i])
                        {
                            xValue[i].ChangeText(dt.Rows[i][0].ToString());
                            break;
                        }
                    }
                }

            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<DrawingObject> yValue = chart.GetLabelYAll();
            for (int i = 0; i < yValue.Count; i++)
            {
                if (yValue[i].GetText() != dtYvalue.Rows[i][1].ToString())
                {
                    List<DrawingObject> CanvasObject = canvas.GetCanvasObject();
                    foreach (DrawingObject obj in CanvasObject)
                    {
                        if (obj == yValue[i])
                        {
                            yValue[i].ChangeText(dtYvalue.Rows[i][1].ToString());
                            break;
                        }
                    }
                }

            }
        }
    }
}
