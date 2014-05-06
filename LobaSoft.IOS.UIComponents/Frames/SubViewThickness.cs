using System;

namespace LobaSoft.IOS.UIComponents.Frames
{
    public struct SubViewThickness
    {
        public float Left { get; set; }

        public float Right { get; set; }

        public float Top { get; set; }

        public float Bottom { get; set; }


        public SubViewThickness(float margin) : this()
        {
            this.Left = margin;
            this.Right = margin;
            this.Top = margin;
            this.Bottom = margin;
        }

        public SubViewThickness(float horizontalMargin, float verticalMargin) : this()
        {
            this.Left = horizontalMargin;
            this.Right = horizontalMargin;
            this.Top = verticalMargin;
            this.Bottom = verticalMargin;
        }

        public SubViewThickness(float left, float top, float right, float bottom) : this()
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
}

