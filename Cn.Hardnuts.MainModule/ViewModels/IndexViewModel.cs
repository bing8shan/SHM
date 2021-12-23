using Cn.Hardnuts.ICommService.Comm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cn.Hardnuts.MainModule.ViewModels
{
    public class IndexViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMainWindow _mainWindow;
        public IndexViewModel(IRegionManager regionManager, IMainWindow mainWindow)
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

        public ICommand CreateCardCommand
        {
            get => new DelegateCommand<object>(OnCreateCard);
        }

        public void OnCreateCard(object parms)
        {
            _mainWindow.Info("签约建档");
          
            _regionManager.RequestNavigate("MainContentRegion", "CreateCardView");//this.TargetViewUserControl1

            _mainWindow.ShowCloseBtn(true);
        
        }

    }
}
