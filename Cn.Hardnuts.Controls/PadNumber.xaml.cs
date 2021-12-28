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

namespace Cn.Hardnuts.Controls
{
    /// <summary>
    /// PadNumber.xaml 的交互逻辑
    /// </summary>
    public partial class PadNumber : UserControl
    {
        public static readonly RoutedEvent ClickOkEvent = EventManager.RegisterRoutedEvent(
      "ClickOk", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PadNumber));

        public static readonly DependencyProperty ContentTextProperty;
        public static readonly DependencyProperty TitleProperty;

        static PadNumber()
        {
            ContentTextProperty = DependencyProperty.Register("ContentText", typeof(String), typeof(PadNumber),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));
            TitleProperty = DependencyProperty.Register("Title", typeof(String), typeof(PadNumber),
                   new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));

        }

        private string content = "";
        private string _title = "";
        public PadNumber()
        {
            InitializeComponent();
            content = "";
            _title = "";
        }

        //事件路由添加移除
        public event RoutedEventHandler ClickOk
        {
            //将路由事件添加路由事件处理程序
            add { AddHandler(ClickOkEvent, value); }
            //从路由事件处理程序中移除路由事件
            remove { RemoveHandler(ClickOkEvent, value); }
        }

        private static void OnDataChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PadNumber ddi = (PadNumber)sender;
            if (e.Property == ContentTextProperty)
            {
                ddi.ContentText = (string)e.NewValue;              
            }else if (e.Property == TitleProperty)
            {
                ddi.Title = (string)e.NewValue;
                
            }

        }

        public string ContentText
        {
            get { return content; }
            set { content = value; txt_text.Text = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; txt_title.Text = _title; }
        }



        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            content +=  "0";
            txt_text.Text = content;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            content += "1";
            txt_text.Text = content;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            content += "2";
            txt_text.Text = content;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            content += "3";
            txt_text.Text = content;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            content +=  "4";
            txt_text.Text = content;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            content +=  "5";
            txt_text.Text = content;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            content += "6";
            txt_text.Text = content;
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            content +=  "7";
            txt_text.Text = content;
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            content += "8";
            txt_text.Text = content;
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            content += "9";
            txt_text.Text = content;
        }
        private void Button_Click__(object sender, RoutedEventArgs e)
        {
            content +=  "_";
            txt_text.Text = content;
        }
        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            if (content.Length > 0)
            {
                content=content.Substring(0, content.Length - 1);
                txt_text.Text = content;
            }
        }

        private void Button_Click_ok(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ClickOkEvent);
            RaiseEvent(newEventArgs);
        }


    }
}
