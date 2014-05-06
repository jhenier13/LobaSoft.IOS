using System;

namespace LobaSoft.IOS.UIComponents.Frames
{
    public enum GridVerticalAlignment
    {
        Stretch,
        Top,
        Bottom,
        Center
    }

    public static class GridVerticalAlignmentExtensions
    {
        public static float CalculateYPosition(this GridVerticalAlignment alignment, float boundaryFrameHeight, 
                                               float subViewHeight, SubViewThickness subViewMargin)
        {
            switch (alignment)
            {
                case GridVerticalAlignment.Top:
                    return subViewMargin.Top;
                case GridVerticalAlignment.Bottom:
                    return boundaryFrameHeight - subViewHeight - subViewMargin.Bottom;
                case GridVerticalAlignment.Center:
                    return (boundaryFrameHeight - subViewHeight) / 2;
                case GridVerticalAlignment.Stretch:
                    return subViewMargin.Top;
            }

            throw new ArgumentException("This alignment can't be processed");
        }

        public static float CalculateHeight(this GridVerticalAlignment alignment, float boundaryFrameHeight, float subViewHeight,
                                            bool autoHeight, SubViewThickness subViewMargin)
        {
            switch (alignment)
            {
                case GridVerticalAlignment.Top:
                case GridVerticalAlignment.Bottom:
                case GridVerticalAlignment.Center:
                    return autoHeight ? 0 : subViewHeight; 
                case GridVerticalAlignment.Stretch:
                    return autoHeight ? (boundaryFrameHeight - subViewMargin.Bottom - subViewMargin.Top) : subViewHeight;
            }

            throw new ArgumentException("This alignment can't be processed");
        }
    }
}

