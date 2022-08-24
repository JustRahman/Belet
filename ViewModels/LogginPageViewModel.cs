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

namespace Belet.ViewModels
{
    class LogginPageViewModel:ViewModelBase
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

        private LogginPasswordModel _logginpasswordmodel;
        public LogginPasswordModel logginpasswordmodel
        {
            get
            {
                return _logginpasswordmodel;
            }
            set
            {
                SetValue(ref _logginpasswordmodel, value);
            }
        }

        public MyDelegateCommand InitializeCommand { get; set; }
        public DelegateCommand Logginbtn { get; set; }

        public MyDelegateCommand close_application { get; set; } 
        public MyDelegateCommand cmdLogin { get; set; }


        public LogginPageViewModel()
        {
            logginpasswordmodel = new LogginPasswordModel();
            InitializeCommand = new MyDelegateCommand(w => InitializeCommand_cmd(w));
            Logginbtn = new DelegateCommand(()=> Logginbtn_cmd());
            close_application = new MyDelegateCommand(pep => close_application_cmd(pep)); 
            cmdLogin = new MyDelegateCommand(zid => cmdLogin_cmd(zid));

            IsDarkTheme = StaticsForTheme.IsBtnChecked;
            toggleTheme = new DelegateCommand(toggleTheme_cmd);

        }

        private void toggleTheme_cmd()
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light); 
                StaticsForTheme.IsBtnChecked = IsDarkTheme;

            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark); 
                StaticsForTheme.IsBtnChecked = IsDarkTheme;

            }
            paletteHelper.SetTheme(theme);
        }
        private void cmdLogin_cmd(object zid)
        {
            wnd.WindowState = WindowState.Minimized;
        }


        
        

        private void close_application_cmd(object pep)
        {
            wnd.Close();
        }

        private void closeapplication_cmd()
        {
            wnd.Close();
        }

        private void Logginbtn_cmd()
        {
            Views.ChoosePage choosePage = new Views.ChoosePage();
            wnd.Close();
            choosePage.ShowDialog();
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
