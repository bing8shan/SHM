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
    /// PadChar.xaml 的交互逻辑
    /// </summary>
    public partial class PadChar : UserControl, ICommandSource
    {
        public static readonly RoutedEvent ClickOkEvent = EventManager.RegisterRoutedEvent(
      "ClickOk", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PadChar));

        public static readonly DependencyProperty ContentTextProperty;
        public static readonly DependencyProperty TitleProperty;

        static PadChar()
        {
            ContentTextProperty = DependencyProperty.Register("ContentText", typeof(String), typeof(PadChar),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));
            TitleProperty = DependencyProperty.Register("Title", typeof(String), typeof(PadChar),
                   new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));

        }

        #region - 用于绑定ViewModel部分 -

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
         DependencyProperty.Register("Command", typeof(ICommand), typeof(PadChar), new UIPropertyMetadata(null));


        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter. This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty CommandParameterProperty =
         DependencyProperty.Register("CommandParameter", typeof(object), typeof(PadChar), new UIPropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandTarget. This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty CommandTargetProperty =
         DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(PadChar), new UIPropertyMetadata(null));


        /*
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            var command = Command;
            var parameter = CommandParameter;
            var target = CommandTarget;

            var routedCmd = command as RoutedCommand;
            if (routedCmd != null && routedCmd.CanExecute(parameter, target))
            {
                routedCmd.Execute(parameter, target);
            }
            else if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
        */

        #endregion


        private string content = "";
        private string _title = "";
        public PadChar()
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
            }
            else if (e.Property == TitleProperty)
            {
                ddi.Title = (string)e.NewValue;

            }

        }

        public string ContentText
        {
            get { return content; }
            set { content = value; txt_text.Text = content; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; txt_title.Text = _title; }
        }



        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            content += "0";
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
            content += "4";
            txt_text.Text = content;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            content += "5";
            txt_text.Text = content;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            content += "6";
            txt_text.Text = content;
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            content += "7";
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
            content += "_";
            txt_text.Text = content;
        }

        private void Button_Click_minus(object sender, RoutedEventArgs e)
        {
            content += "-";
            txt_text.Text = content;
        }

        private void Button_Click_dot(object sender, RoutedEventArgs e)
        {
            content += ".";
            txt_text.Text = content;
        }
        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            if (content.Length > 0)
            {
                content = content.Substring(0, content.Length - 1);
                txt_text.Text = content;
            }
        }

        private void Button_Click_A(object sender, RoutedEventArgs e)
        {
            content += "A";
            txt_text.Text = content;
        }

        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            content += "B";
            txt_text.Text = content;
        }

        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            content += "C";
            txt_text.Text = content;
        }

        private void Button_Click_D(object sender, RoutedEventArgs e)
        {
            content += "D";
            txt_text.Text = content;
        }

        private void Button_Click_E(object sender, RoutedEventArgs e)
        {
            content += "E";
            txt_text.Text = content;
        }

        private void Button_Click_F(object sender, RoutedEventArgs e)
        {
            content += "F";
            txt_text.Text = content;
        }

        private void Button_Click_G(object sender, RoutedEventArgs e)
        {
            content += "G";
            txt_text.Text = content;
        }

        private void Button_Click_H(object sender, RoutedEventArgs e)
        {
            content += "H";
            txt_text.Text = content;
        }

        private void Button_Click_I(object sender, RoutedEventArgs e)
        {
            content += "I";
            txt_text.Text = content;
        }

        private void Button_Click_J(object sender, RoutedEventArgs e)
        {
            content += "J";
            txt_text.Text = content;
        }

        private void Button_Click_K(object sender, RoutedEventArgs e)
        {
            content += "K";
            txt_text.Text = content;
        }

        private void Button_Click_L(object sender, RoutedEventArgs e)
        {
            content += "L";
            txt_text.Text = content;
        }

        private void Button_Click_M(object sender, RoutedEventArgs e)
        {
            content += "M";
            txt_text.Text = content;
        }

        private void Button_Click_N(object sender, RoutedEventArgs e)
        {
            content += "N";
            txt_text.Text = content;
        }

        private void Button_Click_O(object sender, RoutedEventArgs e)
        {
            content += "O";
            txt_text.Text = content;
        }

        private void Button_Click_P(object sender, RoutedEventArgs e)
        {
            content += "P";
            txt_text.Text = content;
        }

        private void Button_Click_Q(object sender, RoutedEventArgs e)
        {
            content += "Q";
            txt_text.Text = content;
        }

        private void Button_Click_R(object sender, RoutedEventArgs e)
        {
            content += "R";
            txt_text.Text = content;
        }

        private void Button_Click_S(object sender, RoutedEventArgs e)
        {
            content += "S";
            txt_text.Text = content;
        }

        private void Button_Click_T(object sender, RoutedEventArgs e)
        {
            content += "T";
            txt_text.Text = content;
        }

        private void Button_Click_U(object sender, RoutedEventArgs e)
        {
            content += "U";
            txt_text.Text = content;
        }

        private void Button_Click_V(object sender, RoutedEventArgs e)
        {
            content += "V";
            txt_text.Text = content;
        }

        private void Button_Click_W(object sender, RoutedEventArgs e)
        {
            content += "W";
            txt_text.Text = content;
        }

        private void Button_Click_X(object sender, RoutedEventArgs e)
        {
            content += "X";
            txt_text.Text = content;
        }

        private void Button_Click_Y(object sender, RoutedEventArgs e)
        {
            content += "Y";
            txt_text.Text = content;
        }

        private void Button_Click_Z(object sender, RoutedEventArgs e)
        {
            content += "Z";
            txt_text.Text = content;
        }

        private void Button_Click_ok(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ClickOkEvent);
            RaiseEvent(newEventArgs);

            var command = Command;
            var parameter = CommandParameter;
            var target = CommandTarget;

            var routedCmd = command as RoutedCommand;
            if (routedCmd != null && routedCmd.CanExecute(parameter, target))
            {
                routedCmd.Execute(parameter, target);
            }
            else if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
}
