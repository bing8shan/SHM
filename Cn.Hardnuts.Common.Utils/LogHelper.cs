using Cn.Hardnuts.ICommService.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cn.Hardnuts.Common.Utils
{
    public  class LogHelper
    {
        public static void Error(string msg)
        {
            IMainWindow am = (IMainWindow)Application.Current.MainWindow;
            am.Error(msg);

        }
        public static void Info(string msg)
        {
            IMainWindow am = (IMainWindow)Application.Current.MainWindow;
            am.Info(msg);
        }
    }
}
