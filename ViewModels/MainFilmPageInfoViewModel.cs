using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Belet.Views;
using Belet.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Belet.Model.Media;
using System.Collections.ObjectModel;
using Belet.Command;
using Belet.Helper;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Globalization;
using DevExpress.Xpo;
using System.Threading;
using System.IO;
using System.Media;
using System.Net.Http;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Belet.ViewModels
{
    class MainFilmPageInfoViewModel : ViewModelBase
    {

      


        private MainChoosePageModel _pageModel;
        public MainChoosePageModel pageModel
        {
            get
            {
                return _pageModel;
            }
            set
            {
                SetValue(ref _pageModel, value);
            }
        }

        private Window _wnd;
        public Window wnd
        {
            get
            {
                return _wnd;
            }
            set
            {
                SetValue(ref _wnd, value);
            }
        }

        private readonly PaletteHelper paletteHelper2 = new PaletteHelper();

        public MyDelegateCommand InitializeCommand { get; set; }

       
        public MainFilmPageInfoViewModel()
        {
            
            InitializeCommand = new MyDelegateCommand(w => InitializeCommand_cmd(w));
            pageModel = new MainChoosePageModel();
            pageModel.picforbtnninfo = AppDomain.CurrentDomain.BaseDirectory +  StaticsForTheme.picforbtnninfo;
            pageModel.txtforbtninfo = StaticsForTheme.txtforbtninfo;
            pageModel.txtdescription = StaticsForTheme.txtdescription;
            pageModel.tblmediayear = StaticsForTheme.year;
            pageModel.tblmediaacceptableyear = StaticsForTheme.mediaacceptableyear + "+";
            pageModel.tblmediamediaduration =  StaticsForTheme.mediaduration;
            pageModel.tblmediasecondrating =  StaticsForTheme.secondrating;
            pageModel.tblfirstrating =  StaticsForTheme.firstrating;
            pageModel.tblRbMediaType = StaticsForTheme.TblRbMediaType;

            //foreach (string  item in StaticsForTheme.mediacountry)
            //{
            //    builder = "Country: " + item;
            ////}
            foreach (string item in StaticsForTheme.mediagener)
            {
                pageModel.tblmediagener += item;
            }
            //pageModel.tblmediacountry = builder;

            //pageModel.tblmediagener = "Geners:" + StaticsForTheme.mediagener.ToString();
            //pageModel.tblmediaactors =  "Actors:"+StaticsForTheme.mediaactors.ToString();
            //pageModel.tblmediadirector = "Director:"+StaticsForTheme.mediadirector.ToString();
            //pageModel.tblmediacountry = "Country:"+StaticsForTheme.mediacountry.ToString();
            //pageModel.tblmedialanguage = "Language:" + StaticsForTheme.medialanguage.ToString();

        }
        private void InitializeCommand_cmd(object o)
        {
            object[] wind = o as object[];
            wnd = (Window)wind[0];
            wnd.Background = new SolidColorBrush(Colors.White);
        }
    }


}
