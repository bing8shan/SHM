using Microsoft.Extensions.Logging;
using NLog.Config;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows;
using SHM.Views;
using Cn.Hardnuts.ICommService.Comm;
using System.Runtime.InteropServices;
using MyDllLib;
using MyUtilLib;
using Cn.Hardnuts.Common.Utils;

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

            //MessageBox.Show("CreateShell");

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
            //MessageBox.Show("InitializeShell");

            //调用.net4打印
            // PrintHelper ph = new PrintHelper();
            //ph.Print(@"C:\l1\Release\mz.frx", @"C:\l1\Release\content.txt", "true","");
            // MessageBox.Show(System.Text.Encoding.Default.ToString());

            //身份证调通
            //CardInfo cardInfo = new CardInfo();
            //int ret = ReadCardUtil.ReadIdCard(ref cardInfo);
            //if (ret == 0)
            //{
            //    MessageBox.Show(cardInfo.other);

            //    string? ss= cardInfo.other;
            //    if (ss != null)
            //        ss = HttpHelper.Post("http://localhost:19080/utf8", ss);
            //    MessageBox.Show(ss);
            //}
            //else
            //{
            //    MessageBox.Show("错误");
            //}

            //二代社保卡可以了
            //string s = Dcrf32Obj.getSiCardNO("USB", 9600);
            //MessageBox.Show(s);
            //string? ss;
            //ss = HttpHelper.Post("http://localhost:19080/utf8", s);
            //MessageBox.Show(ss);

            //CardInfo cardInfo = new CardInfo();
            //int ret = ReadCardUtil.ReadCardBas(ref cardInfo);
            //if (ret == 0)
            //{
            //    MessageBox.Show(cardInfo.other);
            //}
            //else
            //{
            //    MessageBox.Show("错误");
            //}
            //CardInfo cardInfo = new CardInfo();
            //readCardBas(1, "", ref cardInfo);

            //身份证序列号
            //string ss = ReadCardUtil.ReadCertCardSnr();
            //MessageBox.Show(ss);

            //就诊卡
            //string ss = ReadCardUtil.ReadJzCardSnr();
            //MessageBox.Show(ss);

            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           // MessageBox.Show("RegisterTypes");
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
