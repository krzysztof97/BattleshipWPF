using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleshipApp.Helpers
{
    public static class GridHelpers
    {
        public static void CalculateClickedCell(MouseButtonEventArgs e, out int colIndex, out int rowIndex)
        {
            colIndex = 0; rowIndex = 0;
            Grid grid = (Grid)e.Source;
            Point relativeClickPosition = e.GetPosition(grid);

            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var column in grid.ColumnDefinitions)
            {
                accumulatedWidth += column.ActualWidth;
                if (accumulatedWidth < relativeClickPosition.X)
                    colIndex++;
            }

            foreach (var row in grid.RowDefinitions)
            {
                accumulatedHeight += row.ActualHeight;
                if (accumulatedHeight < relativeClickPosition.Y)
                    rowIndex++;
            }
        }
    }
}
