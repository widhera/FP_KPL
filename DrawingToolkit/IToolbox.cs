﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolbox
    {
        event ToolSelectedEventHandler ToolSelected; //event ketika di select
        void AddTool(ITool tool); //menambahkan tool toolnya, harus sesuai dengan aturan ITool
        void RemoveTool(ITool tool); //menghapus tool toolnya, harus sesuai dengan aturan ITool
        ITool ActiveTool { get; } //menambahkan tool toolnya, harus sesuai dengan aturan ITool
    }
}
