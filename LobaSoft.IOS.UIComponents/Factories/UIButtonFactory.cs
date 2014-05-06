using System;
using MonoTouch.UIKit;

namespace LobaSoft.IOS.UIComponents.Factories
{
    public static class UIButtonFactory
    {
        public static UIButton CreateImageButton(string icon)
        {
            UIButton newButton = new UIButton(UIButtonType.Custom);
            UIImage buttonIcon = UIImage.FromFile(icon);

            newButton.SetBackgroundImage(buttonIcon, UIControlState.Normal);
            return newButton;
        }
    }
}

