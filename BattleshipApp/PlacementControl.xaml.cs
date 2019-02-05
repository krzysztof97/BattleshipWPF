using BattleshipApp.ViewModels;
using BattleshipCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleshipApp
{
    /// <summary>
    /// Interaction logic for Placement.xaml
    /// </summary>
    public partial class PlacementControl : UserControl
    {
        public PlacementControl()
        {
            InitializeComponent();
            //PlacementGrid.MouseDown += new MouseButtonEventHandler(PlacementGridClick);
        }
        private void PlacementGridClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.ToString() != "Left")
            {
                return;
            }
            var point = Mouse.GetPosition(PlacementGrid);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;
            
            foreach (var rowDefinition in PlacementGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }
            
            foreach (var columnDefinition in PlacementGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            Console.WriteLine(row);
            Console.WriteLine(col);
        }
        

    }
}
