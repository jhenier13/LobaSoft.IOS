using System;

namespace UIComponents.Frames
{
    public sealed class GridSubViewMeasure
    {
        /// <summary>
        /// Gets or sets the original Width (with what was added in the Grid) of the SubView
        /// </summary>
        /// <value>The width.</value>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the original Height (with what was added in the Grid) of the SubView.
        /// </summary>
        /// <value>The height.</value>
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets the Height of the SubView in the Grid, after all the respective calculations.
        /// </summary>
        /// <value>The actual height.</value>
        public float ActualHeight { get; set; }

        /// <summary>
        /// Gets or sets the Width of the SubView in the Grid, after all the respective calculations.
        /// </summary>
        /// <value>The width of the aactual.</value>
        public float ActualWidth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Grid can calculate and control the width of the SubView
        /// </summary>
        /// <value><c>true</c> if Grid can control the width; otherwise, <c>false</c>.</value>
        public bool AutoWidth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Grid can calculate and control the height of the SubView
        /// </summary>
        /// <value><c>true</c> if Grid can control the height; otherwise, <c>false</c>.</value>
        public bool AutoHeight { get; set; }

        /// <summary>
        /// Gets or sets the row that the SubView has to be in the Grid
        /// </summary>
        /// <value>The row.</value>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the column that the SubView has to be in the Grid
        /// </summary>
        /// <value>The column.</value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the row span of the SubView.
        /// </summary>
        /// <value>The row span.</value>
        public int RowSpan { get; set; }

        /// <summary>
        /// Gets or sets the column span of the SubView.
        /// </summary>
        /// <value>The column span.</value>
        public int ColumnSpan { get; set; }

        /// <summary>
        /// Gets or sets the horizontal alignment of the SubView.
        /// </summary>
        /// <value>The horizontal alignment.</value>
        public GridHorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the vertical alignment of the SubView.
        /// </summary>
        /// <value>The vertical alignment.</value>
        public GridVerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the margin of the SubView.
        /// </summary>
        /// <value>The margin.</value>
        public SubViewThickness Margin { get; set; }

        public GridSubViewMeasure()
        {
            this.Width = 0F;
            this.Height = 0F;
            this.ActualWidth = 0F;
            this.ActualHeight = 0F;
            this.AutoWidth = true;
            this.AutoHeight = true;
            this.Row = 0;
            this.Column = 0;
            this.ColumnSpan = 1;
            this.RowSpan = 1;
            this.HorizontalAlignment = GridHorizontalAlignment.Stretch;
            this.VerticalAlignment = GridVerticalAlignment.Stretch;
            this.Margin = new SubViewThickness(0);
        }
    }
}

