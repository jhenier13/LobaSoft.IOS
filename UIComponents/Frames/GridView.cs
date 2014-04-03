using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;

namespace UIComponents.Frames
{
    public partial class GridView : UIView
    {
        private const char PERCENTAGE_SYMBOL = '*';
        private const char INPUT_SEPARATOR = ';';
        private bool __usingDefaultRow = true;
        private bool __usingDefaultColumn = true;
        private List<GridViewRow> __rows;
        private List<GridViewColumn> __columns;
        private Dictionary<UIView, GridSubViewMeasure> __measures;

        public override RectangleF Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                base.Frame = value;
                this.RecalculateRows();
                this.RecalculateColumns();
            }
        }

        public GridView()
        {
            __rows = new List<GridViewRow>();
            __columns = new List<GridViewColumn>();
            __measures = new Dictionary<UIView, GridSubViewMeasure>();

            GridViewColumn defaultColumn = new GridViewColumn(){ MeasureType = MeasureType.Percentage, Width = 1F };
            GridViewRow defaultRow = new GridViewRow(){ MeasureType = MeasureType.Percentage, Height = 1F };
            __rows.Add(defaultRow);
            __columns.Add(defaultColumn);
        }

        public void UpdateChildrenLayout()
        {
            foreach (var child in __measures)
                this.UpdateInnerChild(child.Key);
        }

        public void UpdateChildLayout(UIView child)
        {
            if (!__measures.ContainsKey(child))
                throw new ArgumentException("The SubView is not in the grid");

            this.UpdateInnerChild(child);
        }

        public void AddColumn(float width, MeasureType measureType)
        {
            if (__usingDefaultColumn)
            {
                __usingDefaultColumn = false;
                __columns.Clear();
            }

            GridViewColumn newColumn = new GridViewColumn(){ Width = width, MeasureType = measureType };
            __columns.Add(newColumn);
            this.RecalculateColumns();
        }

        public void AddRow(float height, MeasureType measureType)
        {
            if (__usingDefaultRow)
            {
                __usingDefaultRow = false;
                __rows.Clear();
            }

            GridViewRow newRow = new GridViewRow(){ Height = height, MeasureType = measureType };
            __rows.Add(newRow);
            this.RecalculateRows();
        }

        public void AddChild(UIView subView, int row = 0, int column = 0, int rowSpan = 1, int columnSpan = 1, 
                               bool autoHeight = true, bool autoWidth = true, GridHorizontalAlignment horizontalAlingment = GridHorizontalAlignment.Stretch, 
                               GridVerticalAlignment verticalAlingment = GridVerticalAlignment.Stretch, 
                               SubViewThickness margin = default(SubViewThickness))
        {
            GridSubViewMeasure subViewMeasure = new GridSubViewMeasure()
            {Row = row, Column = column, RowSpan = rowSpan, ColumnSpan = columnSpan,
                AutoWidth = autoWidth, AutoHeight = autoHeight, 
                HorizontalAlignment = horizontalAlingment, VerticalAlignment = verticalAlingment,
                Margin = margin, Width = subView.Frame.Width, Height = subView.Frame.Height
            };

            __measures.Add(subView, subViewMeasure);
            RectangleF subViewFrame = this.CalculateMeasure(subViewMeasure);
            subView.Frame = subViewFrame;
            this.Add(subView);
        }

        public void AddChild(UIView subView, int row, int column, SubViewThickness margin)
        {
            this.AddChild(subView, row, column, 1, 1, true, true, GridHorizontalAlignment.Stretch, GridVerticalAlignment.Stretch, margin);
        }

        /// <summary>
        /// This method allows to create multiple rows and columns.
        /// </summary>
        /// <param name="rows">Rows separated by semi colon, use a float for Total measured rows (100.5), and a float followed by a asterisc 
        /// for Percentage measured rows (0.5*)</param>
        /// <param name="columns">Columns separated by semi colon, use a float for Total measured columns (100.5), and a float followed by a asterisc 
        /// for Percentage measured columns (0.5*)</param>
        public void AddRowsAndColumns(string rows, string columns)
        {
            List<GridViewRow> inputRows = this.ParseRowMeasures(rows);
            List<GridViewColumn> inputColumns = this.ParseColumnMeasures(columns);

            if (__usingDefaultRow && inputRows.Count != 0)
            {
                __usingDefaultRow = false;
                __rows.Clear();
            }

            __rows.AddRange(inputRows);

            if (__usingDefaultColumn && inputColumns.Count != 0)
            {
                __usingDefaultColumn = false;
                __columns.Clear();
            }

            __columns.AddRange(inputColumns);

            this.RecalculateRows();
            this.RecalculateColumns();
        }

        private List<GridViewRow> ParseRowMeasures(string rows)
        {
            List<GridViewRow> inputRows = new List<GridViewRow>();

            if (rows == null)
                return inputRows;

            rows = rows.Trim();

            if (rows.Length == 0)
                return inputRows;

            string[] inputRowsStr = rows.Split(new []{ INPUT_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputRowsStr.Length; i++)
            {
                string singleInputRow = inputRowsStr[i];
                singleInputRow = singleInputRow.Trim();

                int percentageIndex = singleInputRow.IndexOf(PERCENTAGE_SYMBOL);
                MeasureType inputRowMeasure = MeasureType.Total;
                string inputRowHeightStr = singleInputRow;

                if (percentageIndex != -1)
                {
                    inputRowMeasure = MeasureType.Percentage;
                    inputRowHeightStr = singleInputRow.Substring(0, percentageIndex);
                }

                float inputRowHeight;
                bool parseSucceded = float.TryParse(inputRowHeightStr, out inputRowHeight);

                if (!parseSucceded)
                    throw new ArgumentException(string.Format("Row value: {0} is not valid", inputRowHeightStr));

                if (inputRowHeight < 0)
                    throw new ArgumentException(string.Format("Row value: {0} can't be negative", inputRowHeightStr));

                GridViewRow newRow = new GridViewRow(){ Height = inputRowHeight, MeasureType = inputRowMeasure };
                inputRows.Add(newRow);
            }

            return inputRows;
        }

        private List<GridViewColumn> ParseColumnMeasures(string columns)
        {
            List<GridViewColumn> inputColumns = new List<GridViewColumn>();

            if (columns == null)
                return inputColumns;

            columns = columns.Trim();

            if (columns.Length == 0)
                return inputColumns;

            string[] inputColumnsStr = columns.Split(new []{ INPUT_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputColumnsStr.Length; i++)
            {
                string singleInputColumn = inputColumnsStr[i];
                singleInputColumn = singleInputColumn.Trim();

                int percentageIndex = singleInputColumn.IndexOf(PERCENTAGE_SYMBOL);
                MeasureType inputColumnMeasure = MeasureType.Total;
                string inputColumnWidthStr = singleInputColumn;

                if (percentageIndex != -1)
                {
                    inputColumnMeasure = MeasureType.Percentage;
                    inputColumnWidthStr = singleInputColumn.Substring(0, percentageIndex);
                }

                float inputColumnWidth;
                bool parseSucceded = float.TryParse(inputColumnWidthStr, out inputColumnWidth);

                if (!parseSucceded)
                    throw new ArgumentException(string.Format("Row value: {0} is not valid", inputColumnWidthStr));

                if (inputColumnWidth < 0)
                    throw new ArgumentException(string.Format("Row value: {0} can't be negative", inputColumnWidthStr));

                GridViewColumn newColumn = new GridViewColumn(){ Width = inputColumnWidth, MeasureType = inputColumnMeasure };
                inputColumns.Add(newColumn);
            }

            return inputColumns;
        }

        private void UpdateInnerChild(UIView child)
        {
            RectangleF childFrame = this.CalculateMeasure(__measures[child]);
            child.Frame = childFrame;
        }
    }
}

