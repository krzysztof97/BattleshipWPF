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
        private Rectangle selectedShip;
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
        public ICommand StartBattleButtonCommand { get; set; }
        public ICommand PlaceShipCommand { get; set; }
        public ICommand AircraftCarrierCommand { get; set; }
        public ICommand BattleShipCommand { get; set; }
        public ICommand CruiserCommand { get; set; }
        public ICommand DestroyerCommand { get; set; }
        public IEnumerable<OrientationEnum> OrientationEnums => Enum.GetValues(typeof(OrientationEnum)).Cast<OrientationEnum>();
        public PlacementViewModel()
        {
            shipType = null;
            StartBattleButtonCommand = new RelayCommand(StartBattle);
            PlaceShipCommand = new RelayCommand<MouseButtonEventArgs>(PlaceShip);
            RegisterShipObjectCommands();
        }

        private void RegisterShipObjectCommands()
        {
            AircraftCarrierCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                shipType = typeof(AircraftCarrier);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            BattleShipCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                shipType = typeof(BattleShip);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            CruiserCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                shipType = typeof(Cruiser);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            DestroyerCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                shipType = typeof(Destroyer);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
        }

        public void StartBattle()
        {
            //TODO: sprawdzenie czy siatka uzupełniona


            Messenger.Default.Send<string>("Placement:GoNext");
        }

        public void PlaceShip(MouseButtonEventArgs e)
        {
            if(shipType == null)
            {
                return;
            }

            Grid grid = (Grid)e.Source;
            int colIndex, rowIndex;
            CalculateClickedCell(e, out colIndex, out rowIndex);

            Ship ship = (Ship)Activator.CreateInstance(shipType, orientation);

            Rectangle shipShape = new Rectangle();
            shipShape.Fill = new SolidColorBrush(Colors.Green);
            shipShape.SetValue(Grid.ColumnProperty, colIndex);
            shipShape.SetValue(Grid.RowProperty, rowIndex);
            shipShape.Margin = new Thickness(5);

            if(ship.Orientation == OrientationEnum.Vertical)
            {
                shipShape.SetValue(Grid.RowSpanProperty, ship.Size);
            }
            else
            {
                shipShape.SetValue(Grid.ColumnSpanProperty, ship.Size);
            }

            grid.Children.Add(shipShape);

            shipType = null;
            selectedShip.Fill = Brushes.Green;
            selectedShip = null;
            
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
