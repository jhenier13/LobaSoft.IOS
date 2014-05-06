using System;

namespace LobaSoft.IOS.UIComponents.Events
{
    public delegate void MoveRowEventHandler(object sender,MoveRowEventArgs e);
    public class MoveRowEventArgs:EventArgs
    {
        public int SourceIndex{ get; set; }

        public int DestinationIndex { get; set; }


    }
}

