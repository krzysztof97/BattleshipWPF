using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleshipApp.ViewModels
{
    public class PlacementViewModel : ViewModelBase
    {
        public ICommand StartButtonCommand { get; set; }
        public PlacementViewModel()
        {
            StartButtonCommand = new RelayCommand(StartGame);
        }

        public void StartGame()
        {
            //TODO: sprawdzenie czy siatka uzupełniona


            Messenger.Default.Send<string>("StartGame");
        }

    }
}
