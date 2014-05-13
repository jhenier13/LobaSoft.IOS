using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace LobaSoft.IOS.UIComponents
{
    public static class IphoneEnviroment
    {
        public static float StatusBarHeight
        {
            get
            { 
                RectangleF originalStatusBarFrame = UIApplication.SharedApplication.StatusBarFrame;
                UIWindow appWindow = UIApplication.SharedApplication.Windows[0];
                UIView mainView = appWindow.RootViewController.View;
                RectangleF properFrame = mainView.ConvertRectFromView(originalStatusBarFrame, appWindow);

                return properFrame.Height; 
            }
        }
    }
}

