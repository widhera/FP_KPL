using DrawingToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class Form1 : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;
        private IToolbar toolbar;
        private IMenubar menubar;
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
            this.toolbox.AddTool(new AddPointTool());
            this.toolbox.AddTool(new SelectPointTool());
            this.toolbox.AddTool(new AddXVariable());
            this.toolbox.AddTool(new AddYVariable());
            this.toolbox.AddTool(new RemoveChartPointTool());
            this.toolbox.AddTool(new SelectTool());
            this.toolbox.AddTool(new AddTextTool());
            this.toolbox.AddTool(new TextTool());
            this.toolbox.AddTool(new RemoveTool());
            this.toolbox.AddTool(new ColorRedTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            ////Rectangle tool
            //this.toolbox.AddTool(new RectangleTool());
            //this.toolbox.ToolSelected += Toolbox_ToolSelected;
            #endregion

            #region Toolbar
            // Initializing toolbar
            Debug.WriteLine("Loading toolbar...");
            this.toolbar = new DefaultToolbar();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            
            #endregion

            #region Menubar
            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuitem exampleMenuItem1 = new DefaultMenuitem("File");
            this.menubar.AddMenuItem(exampleMenuItem1);
            DefaultMenuitem exampleMenuItem11 = new DefaultMenuitem("New");
            exampleMenuItem1.AddMenuItem(exampleMenuItem11);

            DefaultMenuitem exampleMenuItem2 = new DefaultMenuitem("Edit");
            this.menubar.AddMenuItem(exampleMenuItem2);
            DefaultMenuitem exampleMenuItem21 = new DefaultMenuitem("Cut");
            exampleMenuItem2.AddMenuItem(exampleMenuItem21);
            DefaultMenuitem exampleMenuItem22 = new DefaultMenuitem("Copy");
            exampleMenuItem2.AddMenuItem(exampleMenuItem22);

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
