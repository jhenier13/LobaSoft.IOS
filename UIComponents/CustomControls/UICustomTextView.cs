using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace UIComponents.CustomControls
{
    public delegate void TextValueChanged(object sender,TextChangeEventArgs e);
    public class UICustomTextView : UITextView
    {
        private bool __isLoaded = false;
        private UILabel __placeholder;

        public event TextValueChanged TextChanged;

        public override RectangleF Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                base.Frame = value;

                if (!__isLoaded)
                    return;

                this.UpdateLayout();
            }
        }

        public string Placeholder
        {
            get{ return __placeholder.Text; }
            set
            {
                __placeholder.Text = value;
                __placeholder.SizeToFit();
            }
        }

        public UICustomTextView()
        {
            this.CreateUIControls();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.AddUIControls();
            this.UpdateLayout();
            __isLoaded = true;
        }

        public override void InsertText(string text)
        {
            base.InsertText(text);
            this.OnTextChanged(new TextChangeEventArgs(){ Type = ChangeType.Insert });
        }

        public override void DeleteBackward()
        {
            base.DeleteBackward();
            this.OnTextChanged(new TextChangeEventArgs(){ Type = ChangeType.Delete });
        }

        private void CreateUIControls()
        {
            __placeholder = new UILabel();
            __placeholder.UserInteractionEnabled = false;
            __placeholder.TextAlignment = UITextAlignment.Center;
            __placeholder.TextColor = UIColor.Gray;
        }

        private void AddUIControls()
        {
            this.Add(__placeholder);
        }

        private void UpdateLayout()
        {
            __placeholder.Frame = new RectangleF(0, 0, this.Frame.Width, 25);
        }

        private void EvaluatePlaceholder()
        {
            if (string.IsNullOrEmpty(this.Text))
                __placeholder.Hidden = false;
            else
                __placeholder.Hidden = true;
        }

        private void OnTextChanged(TextChangeEventArgs e)
        {
            this.EvaluatePlaceholder();
            var handler = this.TextChanged;

            if (handler != null)
                handler(this, e);
        }
    }

    public class TextChangeEventArgs : EventArgs
    {
        public ChangeType Type { get; set; }
    }

    public enum ChangeType
    {
        Insert,
        Delete
    }
}

