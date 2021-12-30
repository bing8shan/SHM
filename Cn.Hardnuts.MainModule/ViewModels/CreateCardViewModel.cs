using Cn.Hardnuts.ICommService.Comm;
using Cn.Hardnuts.MainModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Cn.Hardnuts.MainModule.ViewModels
{
    public  class CreateCardViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMainWindow _mainWindow;
        private DispatcherTimer timer = new DispatcherTimer();
        public CreateCardViewModel(IRegionManager regionManager, IMainWindow mainWindow)
        {
            this._regionManager = regionManager;
            this._mainWindow = mainWindow;
            this.StepTitle = "选择办卡方式";
        }

        public string? _stepTitle;
        public string? StepTitle {
            get { return _stepTitle; } 
            set {
                    SetProperty<string?>(ref _stepTitle, value);
                } 
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // NavUri = navigationContext.Uri.ToString();
        }

        public ICommand SfzSignCommand
        {
            get => new DelegateCommand<object>(OnSfzSign);
        }

        public void OnSfzSign(object parms)
        {
            CreateCardView? createCardView=parms as CreateCardView;
            if (createCardView != null)
            {
                this.StepTitle= "读取身份证信息";
                createCardView.Clear(1);
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                string file = Path.Combine(path, "./media/PutIDCard.wav");
                _mainWindow.PlayWav(file, false);

                //创建线程对身份证信息
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += delegate
                {
                   
                    timer.Stop();
                    this.StepTitle = "身份证信息";
                    createCardView.Clear(2);

                    createCardView.txt_name.Text = "张三";
                    createCardView.txt_idCard.Text = "410581201109280012";

                };
                timer.Start();

                //Debug.WriteLine("读取身份证信息");
            }
            //string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //string file = Path.Combine(path, "./media/PutSBCard.wav");
            //_mainWindow.PlayWav(file, false);
            //var createCardView= parms as CreateCardView;
            //MediaElement ME = createCardView!.mediaElement1;

            //ME.Position = TimeSpan.Zero;
            //ME.Play();
            //string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //string file = Path.Combine(path, "./media/PutSBCard.wav");
            //ME.Source = new Uri(file) ;
            //ME.Position = TimeSpan.Zero;
            //ME.Play();
        }

        public ICommand CheckIdInfoCommand
        {
            get => new DelegateCommand<object>(OnCheckIdInfo);
        }

        public void OnCheckIdInfo(object parms)
        {
            CreateCardView? createCardView = parms as CreateCardView;
            if (createCardView != null)
            {
                this.StepTitle = "检查身份证信息";
                createCardView.Clear(3);
                createCardView.padInfo.Title = "请输入电话号码";
                createCardView.padInfo.ContentText = "";
               // createCardView.padInfo

                //创建线程检查身份证
                //timer.Interval = TimeSpan.FromSeconds(10);
                //timer.Tick += delegate
                //{

                //    timer.Stop();
                //    this.StepTitle = "身份证信息";
                //    createCardView.Clear(4);



                //};
                //timer.Start();

                //Debug.WriteLine("读取身份证信息");
            }
           
        }

        public ICommand ClickOkCommand
        {
            get => new DelegateCommand<object>(OnClickOk);
        }
        public void OnClickOk(object parms)
        {
            CreateCardView? createCardView = parms as CreateCardView;
            if (createCardView != null)
            {
                if (string.IsNullOrEmpty(createCardView.padInfo.ContentText) || createCardView.padInfo.ContentText.Length < 8)
                {
                    return;
                }

                //MessageBox.Show(createCardView.padInfo.ContentText);
                this.StepTitle = "正在建卡";
                createCardView.Clear(4);

                

                //创建线程对身份证信息
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += delegate
                {
                    //调用建卡服务

                    timer.Stop();
                    this.StepTitle = "打印凭条";
                    createCardView.Clear(5);

                    //createCardView.txt_name.Text = "张三";
                    //createCardView.txt_idCard.Text = "410581201109280012";

                };
                timer.Start();


            }

        }


    }
}
