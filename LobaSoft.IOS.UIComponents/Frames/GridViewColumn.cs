using System;

namespace LobaSoft.IOS.UIComponents.Frames
{
    public class GridViewColumn
    {
        public MeasureType MeasureType { get; set; }
        //The width based in the MeasureType
        public float Width { get; set; }
        //The real width, in pixels, after being calculated
        public float RealWidth { get; set; }

        public GridViewColumn()
        {
            this.MeasureType = MeasureType.Percentage;
            this.Width = 0F;
            this.RealWidth = 0F;
        }
    }
}

