using System;

namespace LobaSoft.IOS.UIComponents
{
    public interface IDisposableView
    {
        void AttachEventHandlers();

        void DetachEventHandlers();

        void CleanSubViews();

        void AddSubViews();
    }
}

