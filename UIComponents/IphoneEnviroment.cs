using System;
using MonoTouch.UIKit;

namespace UIComponents
{
    public static class IphoneEnviroment
    {
        public static float StatusBarHeight
        {
            get{ return UIApplication.SharedApplication.StatusBarFrame.Height; }
        }
    }
}

