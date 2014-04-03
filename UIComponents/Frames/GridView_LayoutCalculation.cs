using System;
using System.Drawing;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace UIComponents.Frames
{
    public partial class GridView : UIView
    {
        private RectangleF CalculateMeasure(GridSubViewMeasure measure)
        {
            PointF originPoint = this.CalculateUpperLeftEdge(measure);
            SizeF boundaryFrame = this.CalculateBoundaryFrame(measure);

            float relativeWidth = measure.HorizontalAlignment.CalculateWidth(boundaryFrame.Width, measure.Width, measure.AutoWidth, measure.Margin);
            float relativeXPosition = measure.HorizontalAlignment.CalculateXPosition(boundaryFrame.Width, relativeWidth, measure.Margin);

            float relativeHeight = measure.VerticalAlignment.CalculateHeight(boundaryFrame.Height, measure.Height, measure.AutoHeight, measure.Margin);
            float relativeYPosition = measure.VerticalAlignment.CalculateYPosition(boundaryFrame.Height, relativeHeight, measure.Margin);

            PointF subViewLocation = new PointF(originPoint.X + relativeXPosition, originPoint.Y + relativeYPosition);
            SizeF subViewSize = new SizeF(relativeWidth, relativeHeight);

            RectangleF subViewRectangle = new RectangleF(subViewLocation, subViewSize);
            return subViewRectangle;
        }

        /// <summary>
        /// Calculates the relative point in the Grid for the available space for this measure
        /// </summary>
        /// <returns>The upper left edge.</returns>
        /// <param name="measure">Measure.</param>
        private PointF CalculateUpperLeftEdge(GridSubViewMeasure measure)
        {
            float x = 0, y = 0;

            for (int i = 0; i < measure.Row && i < __rows.Count; i++)
                y = y + __rows[i].RealHeight;

            for (int j = 0; j < measure.Column && j < __columns.Count; j++)
                x = x + __columns[j].RealWidth;

            PointF upperLeftEdge = new PointF(x, y);

            return upperLeftEdge;
        }

        /// <summary>
        /// Calculates the available space in the Grid for this measure
        /// </summary>
        /// <returns>The boundary frame.</returns>
        /// <param name="measure">Measure.</param>
        private SizeF CalculateBoundaryFrame(GridSubViewMeasure measure)
        {
            float width = 0, height = 0;
            int lastRow = measure.Row + measure.RowSpan;
            int lastColumn = measure.Column + measure.ColumnSpan;

            for (int i = measure.Row; i < lastRow && i < __rows.Count; i++)
                height = height + __rows[i].RealHeight;

            for (int j = measure.Column; j < lastColumn && j < __columns.Count; j++)
                width = width + __columns[j].RealWidth;

            SizeF boundaryFrame = new SizeF(width, height);
            return boundaryFrame;
        }

        private void RecalculateRows()
        {
            if (__rows == null)
                return;

            float totalHeight = this.Frame.Height;
            List<GridViewRow> totalRows = __rows.FindAll((row) => row.MeasureType == MeasureType.Total);

            foreach (GridViewRow gridRow in totalRows)
            {
                if (totalHeight - gridRow.Height > 0)
                {
                    totalHeight = totalHeight - gridRow.Height;
                    gridRow.RealHeight = gridRow.Height;
                }
                else
                {
                    gridRow.RealHeight = totalHeight;
                    totalHeight = 0;
                }
            }

            List<GridViewRow> percentageRows = __rows.FindAll((row) => row.MeasureType == MeasureType.Percentage);

            //If the TotalHeight in this step is 0, all the percentage rows are also 0
            foreach (GridViewRow gridRow in percentageRows)
                gridRow.RealHeight = totalHeight * gridRow.Height;

            List<GridViewRow> autoRows = __rows.FindAll((row) => row.MeasureType == MeasureType.Auto);

            //Auto MeasureType is still not implemented, so we throw an exception
            if (autoRows.Count > 0)
                throw new InvalidOperationException("GridViewRows with Auto Measure are not allowed");
        }

        private void RecalculateColumns()
        {
            if (__columns == null)
                return;

            float totalWidth = this.Frame.Width;
            List<GridViewColumn> totalColumns = __columns.FindAll((column) => column.MeasureType == MeasureType.Total);

            foreach (var gridColumn in totalColumns)
            {
                if (totalWidth - gridColumn.Width > 0)
                {
                    totalWidth = totalWidth - gridColumn.Width;
                    gridColumn.RealWidth = gridColumn.Width;
                }
                else
                {
                    gridColumn.RealWidth = totalWidth;
                    totalWidth = 0;
                }
            }

            List<GridViewColumn> percentageColumns = __columns.FindAll((column) => column.MeasureType == MeasureType.Percentage);

            //IF the TotalWidth in this step is 0, all the percentage columns are also 0
            foreach (var gridColumn in percentageColumns)
                gridColumn.RealWidth = totalWidth * gridColumn.Width;

            List<GridViewColumn> autoColumns = __columns.FindAll((column) => column.MeasureType == MeasureType.Auto);

            //Auto MeasureType is still not implemented, so we throw an exception
            if (autoColumns.Count > 0)
                throw new InvalidOperationException("GridViewColumns with Auto Measure are not allowed");
        }
    }
}

