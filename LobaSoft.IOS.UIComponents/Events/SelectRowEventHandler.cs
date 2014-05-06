using System;

namespace LobaSoft.IOS.UIComponents.Events
{
    public delegate void SelectRowEventHandler(object sender,SelectRowEventArgs e);
    public class SelectRowEventArgs : EventArgs
    {
        public int SelectedIndex{ get; set; }
    }
}

