using Cn.Hardnuts.ICommService.Comm;
using Cn.Hardnuts.MainModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cn.Hardnuts.MainModule.ViewModels
{
    public  class CreateCardViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMainWindow _mainWindow;
        public CreateCardViewModel(IRegionManager regionManager, IMainWindow mainWindow)
        {
            this._regionManager = regionManager;
            this._mainWindow = mainWindow;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // NavUri = navigationContext.Uri.ToString();
        }

        public ICommand SfzSignCommand
        {
            get => new DelegateCommand<object>(OnSfzSign);
        }

        public void OnSfzSign(object parms)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(path, "./media/PutSBCard.wav");
            _mainWindow.PlayWav(file, false);
            //var createCardView= parms as CreateCardView;
            //MediaElement ME = createCardView!.mediaElement1;

            //ME.Position = TimeSpan.Zero;
            //ME.Play();
            //string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //string file = Path.Combine(path, "./media/PutSBCard.wav");
            //ME.Source = new Uri(file) ;
            //ME.Position = TimeSpan.Zero;
            //ME.Play();
        }


    }
}
