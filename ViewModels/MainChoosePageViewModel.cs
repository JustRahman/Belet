using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Belet.Views;
using Belet.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Belet.Command;
using Belet.Helper;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;



namespace Belet.ViewModels
{
    class MainChoosePageViewModel : ViewModelBase
    {


        public string _myScrollViewer;
        public string myScrollViewer
        {
            get
            {
                return _myScrollViewer;
            }
            set
            {
                SetValue(ref _myScrollViewer , value);
            }
        }

        public DelegateCommand btn_click { get; set; }



        public MainChoosePageViewModel()
        {

            myScrollViewer = "MyScrollViewer";
            btn_click = new DelegateCommand(btn_click_cmd);




        }

        private void btn_click_cmd()
        {
            
        }
    }
}
