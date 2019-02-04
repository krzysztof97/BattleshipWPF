using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleshipApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private PlacementControl placementControl;
        private ObservableCollection<Control> mainContainer;

        public ObservableCollection<Control> MainContainer
        {
            get => mainContainer;
            set
            {
                mainContainer = value;
                this.RaisePropertyChanged("MainContainer");
            }
        }

        public MainViewModel()
        {
            Messenger.Default.Register<string>(this, this.HandleMessage);
            MainContainer = new ObservableCollection<Control>() {  };
            ShowPlacement();
        }

        public void ShowPlacement()
        {
            placementControl = new PlacementControl();
            MainContainer.Clear();
            MainContainer.Add(placementControl);
        }

        private void StartGame()
        {
            MainContainer.Clear();
            // TODO: ³adowanie widoku planszy z graniem
        }

        private void HandleMessage(string message)
        {
            switch (message)
            {
                case "StartGame":
                    this.StartGame();
                 break;
                default:
                    break;
            }
            Console.WriteLine(message);
        }

    }
}