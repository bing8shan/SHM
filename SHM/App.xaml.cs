using Microsoft.Extensions.Logging;
using NLog.Config;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SHM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        Microsoft.Extensions.Logging.ILogger? _logger;

        protected override Window CreateShell()
        {
            //UI线程未捕获异常处理事件
            this.DispatcherUnhandledException += OnDispatcherUnhandledException;
            //Task线程内未捕获异常处理事件
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            //多线程异常
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {

            //Cn.Hardnuts.CommonUtils.Views.
            //if (Container.Resolve<Cn.Hardnuts.Main.Views.LoginView>().ShowDialog() == false)
            //{
            //    Application.Current?.Shutdown();
            //}
            //else
            //    base.InitializeShell(shell);

            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            _logger = factory.CreateLogger("NLog");
            //注入到Prism DI容器中
            containerRegistry.RegisterInstance(_logger);


        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            //moduleCatalog.AddModule<Cn.Hardnuts.MainModule.MainModule>();
            // moduleCatalog.AddModule<BaseInfoModule>();
        }



        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            //+ System.AppDomain.CurrentDomain.BaseDirectory
            
            base.OnStartup(e);
            _logger?.LogInformation("系统启动");

        }

        protected override void OnExit(ExitEventArgs e)
        {
           
            base.OnExit(e);
            _logger?.LogInformation("系统停止");
            //Log.Info("End");
        }

        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //通常全局异常捕捉的都是致命信息
            _logger?.LogCritical($"{ e.Exception.StackTrace },{ e.Exception.Message }");
        }

        private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            _logger?.LogCritical($"{ e.Exception.StackTrace },{ e.Exception.Message }");
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
             Exception? ex = e.ExceptionObject as Exception;
             _logger?.LogCritical($"{ ex?.StackTrace },{ ex?.Message }");
            

            //记录dump文件
            //MiniDump.TryDump($"dumps\\Wemail_{ DateTime.Now.ToString("HH-mm-ss-ms") }.dmp");
        }


    }
}
