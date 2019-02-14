/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BattleshipApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using BattleshipCore;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace BattleshipApp.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<Game>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PlacementViewModel>();
            SimpleIoc.Default.Register<BattleViewModel>();
            SimpleIoc.Default.Register<WelcomeViewModel>();
            SimpleIoc.Default.Register<EndViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PlacementViewModel Placement
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlacementViewModel>();
            }
        }

        public BattleViewModel Battle
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BattleViewModel>();
            }
        }

        public WelcomeViewModel Welcome
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WelcomeViewModel>();
            }
        }

        public EndViewModel End
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EndViewModel>();
            }
        }

    }
}