using MyDllLib;
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
    /// ReadCardU.xaml 的交互逻辑
    /// </summary>
    public partial class ReadCardU : UserControl, ICommandSource
    {
        public static readonly RoutedEvent ClickOkEvent = EventManager.RegisterRoutedEvent(
    "ClickOk", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ReadCardU));

        public static readonly DependencyProperty CardInfoProperty;
        public static readonly DependencyProperty CusVisibleProperty;

        static ReadCardU()
        {
            CardInfoProperty = DependencyProperty.Register("CardInfo", typeof(String), typeof(ReadCardU),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));
            CusVisibleProperty = DependencyProperty.Register("CusVisible", typeof(String), typeof(ReadCardU),
                   new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));

        }

        #region - 用于绑定ViewModel部分 -

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
         DependencyProperty.Register("Command", typeof(ICommand), typeof(ReadCardU), new UIPropertyMetadata(null));


        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter. This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty CommandParameterProperty =
         DependencyProperty.Register("CommandParameter", typeof(object), typeof(ReadCardU), new UIPropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandTarget. This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty CommandTargetProperty =
         DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(PadNumber), new UIPropertyMetadata(null));

        #endregion


        private CardInfo? _cardInfo=null;
        public CardInfo? CardInfo
        {
            get { return _cardInfo; }
            set { _cardInfo= value; }
        }
        private string? _cusVisible = "";
        public string? CusVisible
        {
            get { return _cusVisible; }
            set { 
                _cusVisible=value;
                if ("sfz" == _cusVisible)
                {
                    btn_sfz.Visibility=Visibility.Collapsed;
                }else if ("sbk" == _cusVisible)
                {
                    btn_sbk.Visibility = Visibility.Collapsed;
                }
                else
                {
                    btn_zlk.Visibility=Visibility.Collapsed;
                }
            }
        }

        public ReadCardU()
        {
            InitializeComponent();
           

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
            ReadCardU ddi = (ReadCardU)sender;
            if (e.Property == CardInfoProperty)
            {
                ddi.CardInfo = (CardInfo)e.NewValue;
            }
            else if (e.Property == CusVisibleProperty)
            {
                ddi.CusVisible = (string)e.NewValue;

            }

        }

        private void btn_sfz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_sbk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_zlk_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
