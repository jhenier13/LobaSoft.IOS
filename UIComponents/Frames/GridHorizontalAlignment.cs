using System;

namespace UIComponents.Frames
{
    public enum GridHorizontalAlignment
    {
        Stretch,
        Right,
        Left,
        Center
    }

    public static class GridHorizontalAlignmentExtensions
    {
        public static float CalculateXPosition(this GridHorizontalAlignment alignment, float boundaryFrameWidth, 
                                               float subViewWidth, SubViewThickness subViewMargin)
        {
            switch (alignment)
            {
                case GridHorizontalAlignment.Left:
                    return subViewMargin.Left;
                case GridHorizontalAlignment.Right:
                    return boundaryFrameWidth - subViewWidth - subViewMargin.Right;
                case GridHorizontalAlignment.Center:
                    return (boundaryFrameWidth - subViewWidth) / 2;
                case GridHorizontalAlignment.Stretch:
                    return subViewMargin.Left;
            }

            throw new ArgumentException("The alignment can't be processed");
        }

        public static float CalculateWidth(this GridHorizontalAlignment alignment, float boundaryFrameWidth, float subViewWidth,
                                           bool autoWidth, SubViewThickness subViewMargin)
        {
            switch (alignment)
            {
                case GridHorizontalAlignment.Left:
                case GridHorizontalAlignment.Right:
                case GridHorizontalAlignment.Center:
                    return autoWidth ? 0 : subViewWidth;
                case GridHorizontalAlignment.Stretch:
                    return autoWidth ? (boundaryFrameWidth - subViewMargin.Left - subViewMargin.Right) : subViewWidth;
            }

            throw new ArgumentException("The alignment can't be processed");
        }
    }
}

