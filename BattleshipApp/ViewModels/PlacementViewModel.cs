using BattleshipCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BattleshipApp.ViewModels
{
    public class PlacementViewModel : ViewModelBase
    {
        private Type shipType;
        private OrientationEnum orientation;
        public OrientationEnum Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                this.RaisePropertyChanged("Orientation");
            }
        }
        public ICommand StartButtonCommand { get; set; }
        public ICommand PlaceShipCommand { get; set; }
        public ICommand AircraftCarrierCommand { get; set; }
        public IEnumerable<OrientationEnum> OrientationEnums => Enum.GetValues(typeof(OrientationEnum)).Cast<OrientationEnum>();
        public PlacementViewModel()
        {
            StartButtonCommand = new RelayCommand(StartGame);
            PlaceShipCommand = new RelayCommand<MouseButtonEventArgs>(PlaceShip);
            AircraftCarrierCommand = new RelayCommand(() => 
                {
                    shipType = typeof(AircraftCarrier);
                }
            );
        }

        public void StartGame()
        {
            //TODO: sprawdzenie czy siatka uzupełniona


            Messenger.Default.Send<string>("StartGame");
        }

        public void PlaceShip(MouseButtonEventArgs e)
        {
            Grid grid = (Grid)e.Source;
            int colIndex, rowIndex;
            CalculateClickedCell(e, out colIndex, out rowIndex);

            Rectangle ship = new Rectangle();

            ship.Fill = new SolidColorBrush(Colors.Green);
            ship.SetValue(Grid.ColumnProperty, colIndex);
            ship.SetValue(Grid.RowProperty, rowIndex);

            grid.Children.Add(ship);


            MessageBox.Show($"col: {colIndex}  row: {rowIndex}");
        }

        private void CalculateClickedCell(MouseButtonEventArgs e, out int colIndex, out int rowIndex)
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
