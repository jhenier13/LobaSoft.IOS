using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;

namespace UIComponents.Frames
{
    public partial class GridView : UIView
    {
        public void SetRow(UIView subView, int row)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].Row = row;
            this.UpdateInnerChild(subView);
        }

        public void SetColumn(UIView subView, int column)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].Column = column;
            this.UpdateInnerChild(subView);
        }

        public void SetRowSpan(UIView subView, int rowSpan)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].RowSpan = rowSpan;
            this.UpdateInnerChild(subView);
        }

        public void SetColumnSpan(UIView subView, int columnSpan)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].ColumnSpan = columnSpan;
            this.UpdateInnerChild(subView);
        }

        /// <summary>
        /// Sets the size for the SubView that is going to be used in case the AutoWidth or AutoHeight is disabled
        /// </summary>
        /// <param name="subView">Sub view.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public void SetSize(UIView subView, float width, float height)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            GridSubViewMeasure subViewMeasure = __measures[subView];
            subViewMeasure.Width = width;
            subViewMeasure.Height = height;

            if (!subViewMeasure.AutoHeight || !subViewMeasure.AutoWidth)
                this.UpdateInnerChild(subView);
        }

        public void SetAutoWidth(UIView subView, bool autoWidth)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].AutoWidth = autoWidth;
            this.UpdateInnerChild(subView);
        }

        public void SetAutoHeight(UIView subView, bool autoHeight)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].AutoHeight = autoHeight;
            this.UpdateInnerChild(subView);
        }

        public void SetHorizontalAlignment(UIView subView, GridHorizontalAlignment horizontalAlingment)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].HorizontalAlignment = horizontalAlingment;
            this.UpdateInnerChild(subView);
        }

        public void SetVerticalAlignment(UIView subView, GridVerticalAlignment verticalAlignment)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].VerticalAlignment = verticalAlignment;
            this.UpdateInnerChild(subView);
        }

        public void SetMargin(UIView subView, SubViewThickness margin)
        {
            if (!__measures.ContainsKey(subView))
                throw new ArgumentException("The SubView is not in the Grid");

            __measures[subView].Margin = margin;
            this.UpdateInnerChild(subView);
        }
    }
}

