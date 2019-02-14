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
        public List<Ship> OpponentShipList;
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
            OpponentShipList = _gameEngine.OpponentArmada.ToList<Ship>();
            PlayerGrid = new ObservableCollection<Rectangle>();

            HitShipCommand = new RelayCommand<MouseButtonEventArgs>(HitShip);

            ShowShips(ShipList, PlayerGrid);
        }

        private void ShowShips(List<Ship> list, ObservableCollection<Rectangle> grid)
        {
            foreach(Ship ship in list)
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
                
                grid.Add(shipShape);
                Console.WriteLine(ship.Name);
            }

        }

        private void HitShip(MouseButtonEventArgs e)
        {
            Messenger.Default.Send<string>("");
            if (!(e.Source is Grid))
            {
                return;
            }

            Grid grid = (Grid)e.Source;
            int colIndex, rowIndex;
            GridHelpers.CalculateClickedCell(e, out colIndex, out rowIndex);


            // strzał użytkownika
            if (gameEngine.HitShip(colIndex, rowIndex))
            {
                Rectangle hitShape = new Rectangle();
                hitShape.SetValue(Grid.ColumnProperty, colIndex);
                hitShape.SetValue(Grid.RowProperty, rowIndex);
                hitShape.Margin = new Thickness(5);

                if (gameEngine.LastUserHitMissle.IsHit == HitValueEnum.Hitted) // sprawdzenie czy statek trafiony
                {
                    hitShape.Fill = new SolidColorBrush(Colors.DarkRed);
                    if (gameEngine.UserHittedShipDestr.Ship.Live == 0)
                    {
                        Messenger.Default.Send<string>(gameEngine.UserHittedShipDestr.Message);
                    }
                }
                else
                {
                    hitShape.Fill = new SolidColorBrush(Colors.Gray);
                }

                grid.Children.Add(hitShape);
            }

            if (!gameEngine.OpponentAlive())
            {
                EndGame();
            }

            // strzał przeciwnika
            bool opponentHitReplay;
            do
            {
                opponentHitReplay = false;

                if (gameEngine.OpponentHitShip())
                {
                    Rectangle opHitShape = new Rectangle();
                    opHitShape.SetValue(Grid.ColumnProperty, gameEngine.LastOpponentHitMissle.XPos);
                    opHitShape.SetValue(Grid.RowProperty, gameEngine.LastOpponentHitMissle.YPos);
                    opHitShape.Margin = new Thickness(5);

                    if (gameEngine.LastOpponentHitMissle.IsHit == HitValueEnum.Hitted) // sprawdzenie czy statek trafiony
                    {
                        opponentHitReplay = true;
                        opHitShape.Fill = new SolidColorBrush(Colors.DarkRed);
                        if (gameEngine.OpponentHittedShipDestr.Ship.Live == 0)
                        {
                            Messenger.Default.Send<string>(gameEngine.OpponentHittedShipDestr.Message);
                        }
                    }
                    else
                    {
                        opHitShape.Fill = new SolidColorBrush(Colors.Gray);
                    }

                    playerGrid.Add(opHitShape);
                }

            } while (opponentHitReplay);

            if (!gameEngine.UserAlive())
            {
                EndGame();
            }

        }

        private void EndGame()
        {
            Messenger.Default.Send<string>("Battle:EndGame");
        }

    }
}
