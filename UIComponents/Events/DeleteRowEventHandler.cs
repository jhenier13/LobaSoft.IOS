using System;

namespace UIComponents.Events
{
    public delegate void DeleteRowEventHandler(object sender,DeleteRowEventArgs e);
    public class DeleteRowEventArgs:EventArgs
    {
        public int DeleteIndex { get; set; }
    }
}

