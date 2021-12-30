using Cn.Hardnuts.Entity;
using Cn.Hardnuts.ICommService.Comm;
using Microsoft.Extensions.Logging;
using SHM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SHM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IMainWindow
    {
        private bool _isCircleWav = false;
        private bool _isCircleMp4 = false;
        private ILogger _logger;

        private DispatcherTimer timer = new DispatcherTimer();
        private int times = 0;

        public MainWindow(ILogger logger)
        {
            InitializeComponent();

            txt_appName.Text = GlobalConst.LoginInfo?.AppName;
            txt_hisName.Text = GlobalConst.LoginInfo?.HisName;
            _logger = logger;
            this.ShowCloseBtn(false);
            MediaInit();

            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += delegate
            {
                times += 2;
                if (times > GlobalConst.LoginInfo?.ExitInterVal)
                {
                    ShowCloseBtn(false);
                }
            };
            timer.Start();
        }

        public void InitTimer()
        {
            times = 0;
        }

        private void MediaInit()
        {
            mediaElementWav.LoadedBehavior = MediaState.Manual;
            // 添加元素加载完成事件 -- 自动开始播放
            mediaElementWav.Loaded += new RoutedEventHandler(mediaWav_Loaded);
            // 添加媒体播放结束事件 -- 重新播放
            mediaElementWav.MediaEnded += new RoutedEventHandler(mediaWav_MediaEnded);
            // 添加元素卸载完成事件 -- 停止播放
            mediaElementWav.Unloaded += new RoutedEventHandler(mediaWav_Unloaded);


            mediaElementMp4.LoadedBehavior = MediaState.Manual;
            mediaElementMp4.Loaded += new RoutedEventHandler(mediaMp4_Loaded);
            mediaElementMp4.MediaEnded += new RoutedEventHandler(mediaMp4_MediaEnded);
            mediaElementMp4.Unloaded += new RoutedEventHandler(mediaMp4_Unloaded);
        }

        private void mediaWav_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement)!.Play();
        }
        private void mediaWav_MediaEnded(object sender, RoutedEventArgs e)
        {
            // MediaElement需要先停止播放才能再开始播放，
            // 否则会停在最后一帧不动
            if (_isCircleWav)
            {
                (sender as MediaElement)!.Stop();
                (sender as MediaElement)!.Play();
            }
        }
        private void mediaWav_Unloaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement)!.Stop();
        }

        private void mediaMp4_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement)!.Play();
        }
        private void mediaMp4_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (_isCircleMp4)
            {
                (sender as MediaElement)!.Stop();
                (sender as MediaElement)!.Play();
            }
        }
        private void mediaMp4_Unloaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement)!.Stop();
        }


        public void Cus1Text(string msg)
        {
            throw new NotImplementedException();
        }

        public void Cus2Text(string msg)
        {
            throw new NotImplementedException();
        }

        public void Error(string msg)
        {
            _logger.LogError(msg);
        }

        public void Info(string msg)
        {
            _logger.LogInformation(msg);
        }

        public void PlayMp4(string filePath, bool isCircle)
        {
            _isCircleMp4=isCircle;  
            mediaElementMp4.Source = new Uri(filePath);
            mediaElementMp4.Position = TimeSpan.Zero;
            mediaElementMp4.Play();
        }

        public void PlayWav(string filePath, bool isCircle)
        {
            _isCircleWav = isCircle;
            mediaElementWav.Source = new Uri(filePath);
            mediaElementWav.Position = TimeSpan.Zero;
            mediaElementWav.Play();
        }

        /// <summary>
        /// 当关闭按钮隐藏时，显示主界面
        /// </summary>
        /// <param name="bVisible"></param>
        public void ShowCloseBtn(bool bVisible)
        {
            if (bVisible)
                btn_close.Visibility = Visibility.Visible;
            else
            {
                btn_close.Visibility = Visibility.Collapsed;
                MainWindowViewModel mvvm = (MainWindowViewModel)this.DataContext;
                mvvm.OnShowIndex(this);
            }
        }

        public void TipText(string msg)
        {
            throw new NotImplementedException();
        }

        public void WinClose()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;

        }

        public void WinMax()
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        }

        public void WinMin()
        {
            throw new NotImplementedException();
        }
    }
}
