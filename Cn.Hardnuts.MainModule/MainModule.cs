using Cn.Hardnuts.ICommService.Comm;
using Cn.Hardnuts.MainModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;

namespace Cn.Hardnuts.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainContentRegion", "IndexView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IndexView>();
            containerRegistry.RegisterForNavigation<CreateCardView>();
            //containerRegistry.RegisterForNavigation<InvestZyView>();

            //注入主窗口接口
            IMainWindow? _mainWindow;
            _mainWindow = (IMainWindow)Application.Current.MainWindow;
            containerRegistry.RegisterInstance(_mainWindow);
        }
    }
}
