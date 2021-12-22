using Cn.Hardnuts.ICommService.Comm;
using Microsoft.Extensions.Logging;
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

namespace SHM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IMainWindow
    {
        private ILogger _logger;
        public MainWindow(ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            this.ShowCloseBtn(false);
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

        public void ShowCloseBtn(bool bVisible)
        {
            if (bVisible)
                btn_close.Visibility = Visibility.Visible;
            else
                btn_close.Visibility=Visibility.Collapsed;
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
