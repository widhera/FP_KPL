﻿namespace DrawingToolkit
{
    public interface IMenuItem
    {
        string Text { get; set; }
        void AddMenuItem(IMenuItem menuItem);
    }
}
