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
    public class WelcomeViewModel : ViewModelBase
    {
        public ICommand StartBattleButtonCommand { get; set; }

        public WelcomeViewModel()
        {
            StartBattleButtonCommand = new RelayCommand(StartGame);
        }

        public void StartGame()
        {
            Messenger.Default.Send<string>("Welcome:GoNext");
        }
    }
}
