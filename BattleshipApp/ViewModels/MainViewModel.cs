using BattleshipCore;
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
        private WelcomeControl welcomeControl; 
        private BattleControl battleControl; 
        private EndControl endControl; 
        private ObservableCollection<Control> mainContainer;
        private Game gameEngine;

        private string footer;

        public ObservableCollection<Control> MainContainer
        {
            get => mainContainer;
            set
            {
                mainContainer = value;
                this.RaisePropertyChanged("MainContainer");
            }
        }

        public string Footer { get => footer;
            set
            {
                footer = value;
                this.RaisePropertyChanged("Footer");
            }
        }

        public MainViewModel(Game _gameEngine)
        {
            gameEngine = _gameEngine;
            Messenger.Default.Register<string>(this, this.HandleMessage);
            MainContainer = new ObservableCollection<Control>() {  };
            ShowWelcome();
        }

        public void ShowWelcome()
        {
            welcomeControl = new WelcomeControl();
            MainContainer.Clear();
            MainContainer.Add(welcomeControl);
        }

        public void ShowPlacement()
        {
            placementControl = new PlacementControl();
            MainContainer.Clear();
            MainContainer.Add(placementControl);
        }

        private void StartBattle()
        {
            battleControl = new BattleControl();
            MainContainer.Clear();
            MainContainer.Add(battleControl);
        }

        private void EndGame()
        {
            Footer = "";
            endControl = new EndControl();
            MainContainer.Clear();
            MainContainer.Add(endControl);
        }

        private void HandleMessage(string message)
        {
            switch (message)
            {
                case "Placement:GoNext":
                    this.StartBattle();
                 break;
                case "Welcome:GoNext":
                    this.ShowPlacement();
                    break;
                case "Battle:EndGame":
                    this.EndGame();
                    break;
                default:
                    Footer = message;
                    break;
            }
            Console.WriteLine(message);
        }

    }
}