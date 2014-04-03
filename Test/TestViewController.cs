using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using UIComponents.Frames;

namespace Test
{
    public partial class TestViewController : UINavigationController
    {
        public TestViewController() : base("TestViewController", null)
        {
            this.NavigationBarHidden = true;
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        private void AddUIControls()
        {
            GridView grid = new GridView();
            grid.AddRow(0.5F, MeasureType.Percentage);
            grid.AddRow(0.5F, MeasureType.Percentage);
            grid.Frame = new RectangleF(0, IphoneEnviroment.StatusBarHeight, this.View.Frame.Width, this.View.Frame.Height - IphoneEnviroment.StatusBarHeight);

            UIButton button1 = new UIButton(UIButtonType.System);
            button1.SetTitle("BUTTON NORMAL", UIControlState.Normal);
            button1.SetTitle("button selected", UIControlState.Selected);
            button1.SetTitle("BUtton Highlight", UIControlState.Highlighted);
            button1.SetTitle("BUTTON", UIControlState.Application);
            button1.SetTitleColor(UIColor.Red, UIControlState.Selected);
            //button1.Selected = true;
            //button1.Highlighted = true;
            //button1.BackgroundColor = UIColor.Blue;
            UIButton button2 = new UIButton(UIButtonType.System);
            //button2.BackgroundColor = UIColor.Red;
            grid.AddSubView(button1, 0, 0);
            grid.AddSubView(button2, 1, 0);

            this.Add(grid);
        }
    }
}

