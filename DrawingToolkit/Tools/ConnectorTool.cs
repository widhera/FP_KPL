using DrawingToolkit.Shapes;
using DrawingToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    class ConnectorTool : ToolStripButton
    {
        private ICanvas canvas;
        private Circle circle;
        Circle sourceObject;
        Circle destinationObject;
    }
}
