using BattleshipCore;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleshipApp.ViewModels
{
    public class EndViewModel : ViewModelBase
    {
        private string message;
        private Game game;
        public ICommand QuitApp { get; set; }

        public string Message { get => message;
            set
            {
                message = value;
                this.RaisePropertyChanged("Message");
            }
        }

        public EndViewModel(Game _gameEngine)
        {
            QuitApp = new RelayCommand(EndGame);
            game = _gameEngine;
            Message = game.EndGameMessage;
        }

        private void EndGame()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
