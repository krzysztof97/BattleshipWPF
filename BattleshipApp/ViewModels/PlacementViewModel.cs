﻿using BattleshipApp.Helpers;
using BattleshipCore;
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
        private Game gameEngine;
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
        public int AircraftCarrierLeft => gameEngine.ShipsLeft[typeof(AircraftCarrier)];
        public int BattleShipLeft => gameEngine.ShipsLeft[typeof(BattleShip)];
        public int CruiserLeft => gameEngine.ShipsLeft[typeof(Cruiser)];
        public int DestroyerLeft => gameEngine.ShipsLeft[typeof(Destroyer)];

        public ICommand StartBattleButtonCommand { get; set; }
        public ICommand PlaceShipCommand { get; set; }
        public ICommand AircraftCarrierCommand { get; set; }
        public ICommand BattleShipCommand { get; set; }
        public ICommand CruiserCommand { get; set; }
        public ICommand DestroyerCommand { get; set; }
        public IEnumerable<OrientationEnum> OrientationEnums => Enum.GetValues(typeof(OrientationEnum)).Cast<OrientationEnum>();
        public PlacementViewModel(Game _gameEngine)
        {
            gameEngine = _gameEngine;
            shipType = null;
            StartBattleButtonCommand = new RelayCommand(StartBattle);
            PlaceShipCommand = new RelayCommand<MouseButtonEventArgs>(PlaceShip);
            RegisterShipObjectCommands();
        }

        private void RegisterShipObjectCommands()
        {
            AircraftCarrierCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                if(selectedShip != null)
                {
                    selectedShip.Fill = Brushes.Green;
                    selectedShip = null;
                }

                if (gameEngine.ShipsLeft[typeof(AircraftCarrier)] == 0)
                {
                    return;
                }

                shipType = typeof(AircraftCarrier);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            BattleShipCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                if (selectedShip != null)
                {
                    selectedShip.Fill = Brushes.Green;
                    selectedShip = null;
                }

                if (gameEngine.ShipsLeft[typeof(BattleShip)] == 0)
                {
                    return;
                }
                shipType = typeof(BattleShip);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            CruiserCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                if (selectedShip != null)
                    selectedShip.Fill = Brushes.Green; if (selectedShip != null)
                {
                    selectedShip.Fill = Brushes.Green;
                    selectedShip = null;
                }

                if (gameEngine.ShipsLeft[typeof(Cruiser)] == 0)
                {
                    return;
                }
                shipType = typeof(Cruiser);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
            DestroyerCommand = new RelayCommand<MouseButtonEventArgs>((e) => {
                if (selectedShip != null)
                    selectedShip.Fill = Brushes.Green; if (selectedShip != null)
                {
                    selectedShip.Fill = Brushes.Green;
                    selectedShip = null;
                }

                if (gameEngine.ShipsLeft[typeof(Destroyer)] == 0)
                {
                    return;
                }
                shipType = typeof(Destroyer);
                selectedShip = (Rectangle)e.Source;
                selectedShip.Fill = Brushes.LightGreen;
            });
        }

        public void StartBattle()
        {
            //TODO: sprawdzenie czy siatka uzupełniona
            if(!gameEngine.ShipDeployReady)
            {
                MessageBox.Show("Nie umieszczono wszystkich statków");
                return;
            }


            Messenger.Default.Send<string>("Placement:GoNext");
        }

        public void PlaceShip(MouseButtonEventArgs e)
        {
            if(shipType == null || selectedShip == null)
            {
                return;
            }

            if( !(e.Source is Grid) )
            {
                return;
            }

            Grid grid = (Grid)e.Source;
            int colIndex, rowIndex;
            GridHelpers.CalculateClickedCell(e, out colIndex, out rowIndex);

            Ship ship = (Ship)Activator.CreateInstance(shipType, orientation);
            ship.XPos = colIndex;
            ship.YPos = rowIndex;
            
            if(!gameEngine.ShipDeploy(ship))
            {
                return;
            }

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

            this.RaisePropertyChanged("AircraftCarrierLeft");
            this.RaisePropertyChanged("BattleShipLeft");
            this.RaisePropertyChanged("CruiserLeft");
            this.RaisePropertyChanged("DestroyerLeft");

            if(gameEngine.ShipsLeft[ship.GetType()] == 0)
            {
                selectedShip.Fill = Brushes.Gray;
            } else
            {
                selectedShip.Fill = Brushes.Green;
            }
            selectedShip = null;
            shipType = null;
            
        }
    }
}
