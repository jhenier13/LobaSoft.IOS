using System;
using MonoTouch.UIKit;

namespace LobaSoft.IOS.UIComponents
{
    public static class IphoneEnviroment
    {
        public static float StatusBarHeight
        {
            get{ return UIApplication.SharedApplication.StatusBarFrame.Height; }
        }
    }
}

