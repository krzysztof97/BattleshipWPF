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
        
    }
}
