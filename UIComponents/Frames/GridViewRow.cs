using System;

namespace UIComponents.Frames
{
    public class GridViewRow
    {
        public MeasureType MeasureType { get; set; }
        //The Height based in the MeasureType
        public float Height { get; set; }
        //The real height, in pixels, after being calculated
        public float RealHeight { get; set; }

        public GridViewRow()
        {
            this.MeasureType = MeasureType.Percentage;
            this.Height = 0F;
            this.RealHeight = 0F;
        }
    }
}

