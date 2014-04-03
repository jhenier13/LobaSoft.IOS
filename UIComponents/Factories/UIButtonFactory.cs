using System;
using MonoTouch.UIKit;

namespace UIComponents.Factories
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

