using BattleshipApp.Helpers;
using BattleshipCore;
using BattleshipCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class BattleViewModel : ViewModelBase
    {
        private Game gameEngine;
        public List<Ship> ShipList;
        private ObservableCollection<Rectangle> playerGrid;
        public ICommand HitShipCommand { get; set; }

        public ObservableCollection<Rectangle> PlayerGrid {
            get => playerGrid;
            set
            {
                playerGrid = value;
                this.RaisePropertyChanged("PlayerGrid");
            }
        }

        public BattleViewModel(Game _gameEngine)
        {
            gameEngine = _gameEngine;
            ShipList = _gameEngine.Armada.ToList<Ship>();
            PlayerGrid = new ObservableCollection<Rectangle>();

            HitShipCommand = new RelayCommand<MouseButtonEventArgs>(HitShip);

            ShowPlayerShips();
        }

        private void ShowPlayerShips()
        {
            foreach(Ship ship in ShipList)
            {
                Rectangle shipShape = new Rectangle();
                shipShape.Fill = new SolidColorBrush(Colors.Green);
                shipShape.SetValue(Grid.ColumnProperty, ship.XPos);
                shipShape.SetValue(Grid.RowProperty, ship.YPos);
                shipShape.Margin = new Thickness(5);

                if (ship.Orientation == OrientationEnum.Vertical)
                {
                    shipShape.SetValue(Grid.RowSpanProperty, ship.Size);
                }
                else
                {
                    shipShape.SetValue(Grid.ColumnSpanProperty, ship.Size);
                }
                
                PlayerGrid.Add(shipShape);
                Console.WriteLine(ship.Name);
            }

        }

        private void HitShip(MouseButtonEventArgs e)
        {
            if (!(e.Source is Grid))
            {
                return;
            }

            Grid grid = (Grid)e.Source;
            int colIndex, rowIndex;
            GridHelpers.CalculateClickedCell(e, out colIndex, out rowIndex);

            /* //SPRAWDZENIE CZY BYŁA JUŻ PRÓBA UDERZENIA W TO MIEJSCE
            if()
            {
                return;
            }
            */

            Rectangle hitShape = new Rectangle();
            hitShape.SetValue(Grid.ColumnProperty, colIndex);
            hitShape.SetValue(Grid.RowProperty, rowIndex);
            hitShape.Margin = new Thickness(5);

            if(gameEngine.HitShip(colIndex, rowIndex)) // sprawdzenei czy statek trafiony
            {
                hitShape.Fill = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                hitShape.Fill = new SolidColorBrush(Colors.Gray);
            }
            
            grid.Children.Add(hitShape);
            
        }

    }
}
