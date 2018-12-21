using DrawingToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class Form1 : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Toolbox

            //tempat2 nya tool
            //Initialize toolbox
            Debug.WriteLine("Loading toolbox...");

            //inisialisasi toolbox
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools

            //tool tool yang di keluarkan
            ////Initialize tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new StatefullLineTool());
            this.toolbox.AddTool(new SquareTool());
            this.toolbox.AddTool(new CircleTool());
            this.toolbox.AddTool(new ChartTool());
            this.toolbox.AddTool(new SelectPointTool());
            this.toolbox.AddTool(new AddXVariable());
            this.toolbox.AddTool(new AddYVariable());
            this.toolbox.AddTool(new SelectTool());
            this.toolbox.AddTool(new AddTextTool());
            this.toolbox.AddTool(new TextTool());
            this.toolbox.AddTool(new RemoveTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

           
            #endregion



            #region Canvas
            Debug.WriteLine("Loading canvas...");
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);
            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
