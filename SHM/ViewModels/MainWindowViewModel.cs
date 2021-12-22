using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SHM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SHM.ViewModels
{
    public class MainWindowViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private ILogger _logger;
        public MainWindowViewModel(IRegionManager regionManager, ILogger logger)
        {
            this._logger = logger;
            this._regionManager = regionManager;
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

        public ICommand ShowIndexCommand
        {
            get => new DelegateCommand<object>(OnShowIndex);
        }

        public void OnShowIndex(object parms)
        {
            MainWindow? w = (parms as MainWindow);
            Button? btn_close = w!.btn_close;
            
             btn_close.Visibility = Visibility.Hidden;
            _logger.LogInformation("回到主窗口");

            _regionManager.RequestNavigate("MainContentRegion", "IndexView");

        }


    }
}
