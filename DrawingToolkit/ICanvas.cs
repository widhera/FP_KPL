using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawingToolkit.Shapes;

namespace DrawingToolkit
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool); // untuk mengaktifkan tool yang dipilih
        void Repaint(); //fungsi untuk menggambar pada canvas
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
        void RemoveObject(DrawingObject obj);

        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        DrawingObject GetChart(int x, int y);
        List<DrawingObject> GetCanvasObject();
        void DeselectAllObject();
        void DeselectObjectAt(DrawingObject obj);
        void ChangeObject(DrawingObject old, DrawingObject newest);
    }
}
