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

namespace Cn.Hardnuts.MainModule.Views
{
    /// <summary>
    /// CreateCard.xaml 的交互逻辑
    /// </summary>
    public partial class CreateCardView : UserControl
    {
        public CreateCardView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //mediaElement1.Position = TimeSpan.Zero;
            //mediaElement1.Play();
            Clear(0);
        }

        /// <summary>
        /// 初始化 清空数据
        /// </summary>
        public void Clear(int step)
        {
            if (step == 0)
            {
                this.btn_step0.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step0.Foreground = Brushes.White;
                this.panel_step0.Visibility = Visibility.Visible;

                this.txt_idCard.Text = "";
                this.txt_name.Text = "";
            }
            else
            {               
                this.btn_step0.Background = Brushes.Transparent;
                this.txt_step0.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step0.Visibility = Visibility.Collapsed;
            }
            if (step == 1)
            {
                this.btn_step1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step1.Foreground = Brushes.White;
                this.panel_step1.Visibility = Visibility.Visible;
            }
            else
            {
                this.btn_step1.Background = Brushes.Transparent;
                this.txt_step1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step1.Visibility = Visibility.Collapsed;
            }

            if (step == 2)
            {
                this.btn_step2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step2.Foreground = Brushes.White;
                this.panel_step2.Visibility = Visibility.Visible;
            }
            else
            {
                this.btn_step2.Background = Brushes.Transparent;
                this.txt_step2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step2.Visibility = Visibility.Collapsed;
            }
            if (step == 3)
            {
                this.btn_step3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step3.Foreground = Brushes.White;
                this.panel_step3.Visibility = Visibility.Visible;
            }
            else
            {
                this.btn_step3.Background = Brushes.Transparent;
                this.txt_step3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step3.Visibility = Visibility.Collapsed;
            }
            if (step == 4)
            {
                this.btn_step4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step4.Foreground = Brushes.White;
                this.panel_step4.Visibility = Visibility.Visible;
            }
            else
            {
                this.btn_step4.Background = Brushes.Transparent;
                this.txt_step4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step4.Visibility = Visibility.Collapsed;
            }
            if (step == 5)
            {
                this.btn_step5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9C27B3"));
                this.txt_step5.Foreground = Brushes.White;
                this.panel_step5.Visibility = Visibility.Visible;
            }
            else
            {
                this.btn_step5.Background = Brushes.Transparent;
                this.txt_step5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#848484"));
                this.panel_step5.Visibility = Visibility.Collapsed;
            }

            

            
        }

        private void padInfo_ClickOk(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(padInfo.ContentText) || padInfo.ContentText.Length < 8){
                return;
            }
            MessageBox.Show(padInfo.ContentText);
        }
    }
}
