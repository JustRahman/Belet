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
    class TelekomBeletTazelikViewModel : ViewModelBase
    {
        bool wndstate = false;
        public DelegateCommand Logginbtn { get; set; }
        public DelegateCommand toggleTheme { get; set; }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

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

        private TelekomBeletTazelikModel _telekombeletmodel;
        public TelekomBeletTazelikModel telekombeletmodel
        {
            get
            {
                return _telekombeletmodel;
            }
            set
            {
                SetValue(ref _telekombeletmodel, value);
            }

        }

        private string _firstcolore;
        public string firstcolor
        {
            get
            {
                return _firstcolore;
            }
            set
            {
                SetValue(ref _firstcolore, value);
            }

        }

        public MyDelegateCommand InitializeCommand { get; set; }
        public MyDelegateCommand close_application { get; set; }
        public MyDelegateCommand size { get; set; }

        public MyDelegateCommand sizechangebtn { get; set; }
        public MyDelegateCommand cmdLogin { get; set; }
        public DelegateCommand MashaBearbutton { get; set; }

        public DelegateCommand BeletTelekom { get; set; }

        public DelegateCommand BeletTuner { get; set; }
        public DelegateCommand BeletASTU { get; set; }
        public DelegateCommand linkButton { get; set; }
        public DelegateCommand BeletTunerTV { get; set; }
        public DelegateCommand AraKesme { get; set; }
        public DelegateCommand Ginileyin { get; set; }



        public DelegateCommand FilmFrame { get; set; }
        public DelegateCommand VideoFrame { get; set; }

        public DelegateCommand BeletAcc { get; set; }
        public DelegateCommand KarTazelik { get; set; } 

        public MyDelegateCommand emailopen { get; set; }
        public MyDelegateCommand telegram { get; set; }
        public DelegateCommand goldawmerkezi { get; set; }
        public DelegateCommand maplocation { get; set; }
        public DelegateCommand myhabathyzmatlar { get; set; }

        public DelegateCommand BizBarada { get; set; }

        public DelegateCommand turkmentelekom { get; set; }

        public DelegateCommand beletspeed { get; set; }
        public DelegateCommand confidbtn { get; set; }


        public TelekomBeletTazelikViewModel()
        {
            telekombeletmodel = new TelekomBeletTazelikModel();
            InitializeCommand = new MyDelegateCommand(w => InitializeCommand_cmd(w));

            firstcolor = "pink";
            myhabathyzmatlar = new DelegateCommand(myhabathyzmatlar_cmd);
            MashaBearbutton = new DelegateCommand(() => MashaBearbutton_cmd());
            BeletTuner = new DelegateCommand(() => BeletTuner_cmd());
            BeletTelekom = new DelegateCommand(() => BeletTelekom_cmd());
            BeletASTU = new DelegateCommand(() => BeletASTU_cmd());
            BeletTunerTV = new DelegateCommand(() => BeletTunerTV_cmd());
            linkButton = new DelegateCommand(LinkNavigate);
            AraKesme = new DelegateCommand(() => AraKesme_cmd());


            FilmFrame = new DelegateCommand(() => FilmFrame_cmd());
            VideoFrame = new DelegateCommand(VideoFrame_cmd);
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

            Ginileyin = new DelegateCommand(() => Ginileyin_cmd());
            close_application = new MyDelegateCommand(pep => close_application_cmd(pep));
            sizechangebtn = new MyDelegateCommand(klop => sizechangebtn_cmd(klop));
            cmdLogin = new MyDelegateCommand(zid => cmdLogin_cmd(zid));
            size = new MyDelegateCommand(zid => size_cmd(zid));
            toggleTheme = new DelegateCommand(toggleTheme_cmd); 

            telekombeletmodel.IsBigOrNormal = "Big Mode";
            telekombeletmodel.brush5 = "Black";
            telekombeletmodel.brush1 = System.AppDomain.CurrentDomain.BaseDirectory + @"Images\BeletLogo.png"; 
            IsDarkTheme = StaticsForTheme.IsBtnChecked;

        }
        private void myhabathyzmatlar_cmd()
        {
            Process.Start("https://belet.com.tm/business");
        }
        private void VideoFrame_cmd()
        {
            Views.VideoBelet videoBelet = new Views.VideoBelet();
            wnd.Close();
            videoBelet.ShowDialog();
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



        private void LinkNavigate()
        {
            System.Diagnostics.Process.Start("http://www.google.com");
            //throw new NotImplementedException();
        }


        private void toggleTheme_cmd()
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light); 
                StaticsForTheme.IsBtnChecked = IsDarkTheme;
                telekombeletmodel.brush5 = "Black";

            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark); 
                StaticsForTheme.IsBtnChecked = IsDarkTheme;
                telekombeletmodel.brush5 = "White";

            }
            paletteHelper.SetTheme(theme);
        }

        private void sizechangebtn_cmd(object klop)
        {
            if (wndstate == false)
            {
                wnd.WindowState = WindowState.Maximized;
                wndstate = true;


                telekombeletmodel.IsBigOrNormal = "Normal Mode";
            }
            else
            {
                wnd.WindowState = WindowState.Normal;
                wndstate = false;
                telekombeletmodel.IsBigOrNormal = "Bid Mode";

            }

        }
        private void cmdLogin_cmd(object zid)
        {
            wnd.WindowState = WindowState.Minimized;
        }

        private void FilmFrame_cmd()
        {
            Views.BeletFilm belet = new Views.BeletFilm();
            wnd.Close();
            belet.ShowDialog();
        }


        private void size_cmd(object zid)
        {
            if (zid != null)
            {
                object[] wind = zid as object[];
                wnd = (Window)wind[0];
                if (wnd.Width < 650)
                {
                    firstcolor = "Black";
                }
            }

        }


        private void close_application_cmd(object pep)
        {
            wnd.Close();
        }

        private void Ginileyin_cmd()
        {
            Views.GinileyinBelet belet = new Views.GinileyinBelet();
            wnd.Close();
            belet.ShowDialog();
        }

        private void AraKesme_cmd()
        {
            Views.ArakesmeBelet belet = new Views.ArakesmeBelet();
            wnd.Close();
            belet.ShowDialog();
        }

        private void BeletTunerTV_cmd()
        {
            Views.TelekomBelet belet = new Views.TelekomBelet();
            wnd.Close();
            belet.ShowDialog();
        }

        private void BeletASTU_cmd()
        {
            Views.ASTUBelet belet = new Views.ASTUBelet();
            wnd.Close();
            belet.ShowDialog();
        }

        private void BeletTelekom_cmd()
        {
            Views.TelekomBelet belet = new Views.TelekomBelet();
            wnd.Close();
            belet.ShowDialog();
        }

        private void BeletTuner_cmd()
        {
            Views.TVBelet belet = new Views.TVBelet();
            wnd.Close();
            belet.ShowDialog();
        }


        private void MashaBearbutton_cmd()
        {
            Views.VideoBelet belet = new Views.VideoBelet();
            wnd.Close();
            belet.ShowDialog();
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
