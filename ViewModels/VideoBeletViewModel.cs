using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Belet.Model;
using Belet.Views;
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



    class VideoBeletViewModel : ViewModelBase
    {
        public DelegateCommand toggleTheme { get; set; }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();


        bool wndstate = false;
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


        private VideoBeletModel _videoBeletModel;
        public VideoBeletModel videoBeletModel
        {
            get
            {
                return _videoBeletModel;
            }
            set
            {
                SetValue(ref _videoBeletModel, value);
            }

        }

        public MyDelegateCommand InitializeCommand { get; set; }
        public MyDelegateCommand close_application { get; set; }

        public MyDelegateCommand sizechangebtn { get; set; }
        public MyDelegateCommand cmdLogin { get; set; }
        public DelegateCommand choosepageBack { get; set; }

        public DelegateCommand BeletAcc { get; set; }
        public DelegateCommand KarTazelik { get; set; }
        public DelegateCommand myhabatbelet { get; set; }
        public MyDelegateCommand emailopen { get; set; }
        public MyDelegateCommand telegram { get; set; }
        public DelegateCommand goldawmerkezi { get; set; }
        public DelegateCommand maplocation { get; set; }
        public DelegateCommand myhabathyzmatlar { get; set; }

        public DelegateCommand BizBarada { get; set; }

        public DelegateCommand turkmentelekom { get; set; }

        public DelegateCommand beletspeed { get; set; }
        public DelegateCommand confidbtn { get; set; }


        public VideoBeletViewModel()
        { 
            videoBeletModel = new VideoBeletModel();
            KarTazelik = new DelegateCommand(() => KarTazelik_cmd());
            BeletAcc = new DelegateCommand(BeletAcc_cmd);
            maplocation = new DelegateCommand(() => maplocation_cmd()); 
            goldawmerkezi = new DelegateCommand(() => goldawmerkezi_cmd());
            telegram = new MyDelegateCommand(e => telegram_cmd(e));
            emailopen = new MyDelegateCommand(f => emailopen_cmd(f));
            BizBarada = new DelegateCommand(() => BizBarada_cmd());

            turkmentelekom = new DelegateCommand(() => turkmentelekom_cmd());
            beletspeed = new DelegateCommand(() => beletspeed_cmd());
            confidbtn = new DelegateCommand(() => confidbtn_cmd());
            toggleTheme = new DelegateCommand(toggleTheme_cmd);
            myhabathyzmatlar = new DelegateCommand(myhabathyzmatlar_cmd);
            videoBeletModel = new VideoBeletModel();
            InitializeCommand = new MyDelegateCommand(w => InitializeCommand_cmd(w));
            choosepageBack = new DelegateCommand(() => choosepageBack_cmd());
            close_application = new MyDelegateCommand(pep => close_application_cmd(pep));
            sizechangebtn = new MyDelegateCommand(klop => sizechangebtn_cmd(klop));
            cmdLogin = new MyDelegateCommand(zid => cmdLogin_cmd(zid));
            videoBeletModel.videophone = System.AppDomain.CurrentDomain.BaseDirectory + @"Images\TurkmenPortal.png";
            videoBeletModel.geometry1 = System.AppDomain.CurrentDomain.BaseDirectory + @"Images\BeletLogo.png";
            videoBeletModel.brush1 = "Black";
            videoBeletModel.brush2 = "#ebe8e8";
            videoBeletModel.IsBigOrNormal = "Big Mode";

            IsDarkTheme = StaticsForTheme.IsBtnChecked;
        }

        private void myhabathyzmatlar_cmd()
        {
            Process.Start("https://belet.com.tm/business");
        }

        private void BeletAcc_cmd()
        {
            Process.Start("https://belet.com.tm/contacts");
        }

        private void KarTazelik_cmd()
        {
            Views.TazelikBelet tazelikBelet = new Views.TazelikBelet();
            wnd.Close();
            tazelikBelet.ShowDialog();
        }

        private void androidtv_cmd()
        {
            Process.Start("https://belet.com.tm/assets/apk/beletfilm_tv_2.2.apk");
        }

        private void appstore_cmd()
        {
            Process.Start("https://apps.apple.com/us/app/belet-film/id1551618663");
        }

        private void playmarket_cmd()
        {
            Process.Start("https://play.google.com/store/apps/details?id=tm.belet.films&hl=ru&gl=US");
        }

        private void confidbtn_cmd()
        {
            Process.Start("https://belet.com.tm/legal/privacy");
        }

        private void beletspeed_cmd()
        {
            Process.Start("https://speed.belet.com.tm/");
        }

        private void turkmentelekom_cmd()
        {
            Process.Start("https://telecom.tm/ru/");
        }

        private void BizBarada_cmd()
        {
            Views.BeletBarada beletBarada = new Views.BeletBarada();
            wnd.Close();
            beletBarada.ShowDialog();
        }

        private void emailopen_cmd(object f)
        {
            Process.Start("mailto:info@belet.me");
        }

        private void telegram_cmd(object e)
        {
            Process.Start("https://t.me/belet_video_forum");
        }

        private void goldawmerkezi_cmd()
        {
            Process.Start("https://help.belet.com.tm/");
        }

        private void maplocation_cmd()
        {
            Process.Start("https://www.google.ru/maps/place/37%C2%B057'40.7%22N+58%C2%B024'56.9%22E/@37.9610511,58.4154673,355m/data=!3m1!1e3!4m6!3m5!1s0x0:0x0!7e2!8m2!3d37.9613103!4d58.4157966");
        }

        private void callbtn_cmd(object o)
        {
            Process.Start("https://belet.com.tm/tel:+993-12-75-02-08");
        }


        private void choosepageBack_cmd()
        {
            Views.ChoosePage belet = new Views.ChoosePage();
            wnd.Close();
            belet.ShowDialog();
        }

        private void cmdLogin_cmd(object zid)
        {
            wnd.WindowState = WindowState.Minimized;
        }


        private void sizechangebtn_cmd(object klop)
        {
            if (wndstate == false)
            {
                wnd.WindowState = WindowState.Maximized;
                wndstate = true;
               videoBeletModel.IsBigOrNormal = "Normal Mode";
            }
            else
            {
                wnd.WindowState = WindowState.Normal;
                wndstate = false; 
                videoBeletModel.IsBigOrNormal = "Big Mode";

            }

        }

        private void close_application_cmd(object pep)
        {
            wnd.Close();
        }
        private void toggleTheme_cmd()
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                videoBeletModel.brush1 = "Black";
            videoBeletModel.brush2 = "#ebe8e8";
                StaticsForTheme.IsBtnChecked = IsDarkTheme;



            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                videoBeletModel.brush1 = "White";
                videoBeletModel.brush2 = "#808080";
                StaticsForTheme.IsBtnChecked = IsDarkTheme;


            }
            paletteHelper.SetTheme(theme);
        }

        private void InitializeCommand_cmd(object o)
        {
            object[] wind = o as object[];
            wnd = (Window)wind[0];
            //  wnd.Close();
            //   throw new NotImplementedException();
        }
    }
}
