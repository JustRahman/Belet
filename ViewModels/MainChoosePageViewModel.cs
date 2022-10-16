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

namespace Belet.ViewModels
{
    class MainChoosePageViewModel : ViewModelBase
    {

       


        private ObservableCollection<NecessaryMedia> _necessaryMedias;
        public ObservableCollection<NecessaryMedia> necessaryMedias
        {
            get
            {
                return _necessaryMedias;
            }
            set
            {
                SetValue(ref _necessaryMedias , value);
            }
        }

        private ScrollViewer _scrollViewer;
        public ScrollViewer scrollViewer
        {
            get
            {
                return _scrollViewer;
            }
            set
            {
                SetValue(ref _scrollViewer, value);
            }
        }

        private Grid _firstgrid;
        public Grid firstgrid
        {
            get
            {
                return _firstgrid;
            }
            set
            {
                SetValue(ref _firstgrid, value);
            }
        }

        private WrapPanel _wrapPanel;
        public WrapPanel wrapPanel
        {
            get
            {
                return _wrapPanel;
            }
            set
            {
                SetValue(ref _wrapPanel, value);
            }
        }

        

        private StackPanel _stackPanel;
        public StackPanel stackPanel
        {
            get
            {
                return _stackPanel;
            }
            set
            {
                SetValue(ref _stackPanel, value);
            }
        }


        List<List<MainChoosePageModel>> _mainChoosePageModels;
        List<List<MainChoosePageModel>> mainChoosePageModels
        {
            get
            {
                return _mainChoosePageModels;
            }
            set
            {
                SetValue(ref _mainChoosePageModels, value);
            }
        }

        List<MainChoosePageModel> _mainChoosePageModel;
        List<MainChoosePageModel> mainChoosePageModel
        {
            get
            {
                return _mainChoosePageModel;
            }
            set
            {
                SetValue(ref _mainChoosePageModel, value);
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
                SetValue(ref _wnd,value);
            }
        }

        public INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }

        bool wndstate = false;
 

        private ObservableCollection<string> _geners;

        public ObservableCollection<string> Geners
        {
            get
            {
                return _geners;
            }
            set
            {
                SetValue(ref _geners,value);
            }
        }


        private ObservableCollection<string> _katagory;

        public ObservableCollection<string> Kategory
        {
            get
            {
                return _katagory;
            }
            set
            {
                SetValue(ref _katagory, value);
            }
        }

        private ObservableCollection<string> _countries;

        public ObservableCollection<string> Countries
        {
            get
            {
                return _countries;
            }
            set
            {
                SetValue(ref _countries, value);
            }
        }


        private readonly PaletteHelper paletteHelper = new PaletteHelper();


        static HttpClient httpClient;



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
    
        public MyDelegateCommand BtnInfoForAll { get; set; }
        public DelegateCommand OnViewLoadedCommand { get; set; }
        public DelegateCommand sizechangebtn { get; set; }

        public MyDelegateCommand InitializeCommand { get; set; }
        public DelegateCommand back { get; set; }



        public MainChoosePageViewModel()
        {
            mainChoosePageModel = new List<MainChoosePageModel>();
            pageModel = new MainChoosePageModel();
            Geners = new ObservableCollection<string>();
            Kategory = new ObservableCollection<string>();
            Countries = new ObservableCollection<string>();
       
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:1337/api/");

            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);
            paletteHelper.SetTheme(theme);
            
            
            sizechangebtn = new DelegateCommand(()=> sizechangebtn_cmd());
            InitializeCommand = new MyDelegateCommand(w => InitializeCommand_cmd(w));
            back = new DelegateCommand(()=> back_cmd());
           
          
        }

        private void back_cmd()
        {
            NavigationService.GoBack();
        }

        private void sizechangebtn_cmd()
        {
            if (wndstate == false)
            {
                wnd.WindowState = WindowState.Maximized;
                wndstate = true;


                pageModel.IsBigOrNormal = "Normal Mode";
            }
            else
            {
                wnd.WindowState = WindowState.Normal;
                wndstate = false;
                pageModel.IsBigOrNormal = "Bid Mode";

            }
        }
        bool checker = false;
        bool helper ;
        int counter = 1;
        private async void InitializeCommand_cmd(object o)
        {
            Countries.Add("all");
            Geners.Add("all");
            Kategory.Add("all");


            HttpResponseMessage response = await httpClient.GetAsync("company-infos?populate=*");
            string str = response.Content.ReadAsStringAsync().Result;
            Media mediaObject = JsonConvert.DeserializeObject<Media>(str);
            necessaryMedias = new ObservableCollection<NecessaryMedia>();
            

            if (StaticsForTheme.counter == 0)
            {
                foreach (MediaDatum item in mediaObject.Data)
                {
                    NecessaryMedia media = new NecessaryMedia();
                    media.GenerName = new ObservableCollection<string>();
                    media.TblRbMediaActors = new ObservableCollection<string>();
                    media.TblRbLanguages = new ObservableCollection<string>();
                    media.TblRbCountries = new ObservableCollection<string>();

                    scrollViewer = new ScrollViewer();
                    wrapPanel = new WrapPanel();
                    firstgrid = new Grid();
                    stackPanel = new StackPanel();

                    object[] wind = o as object[];
                    wnd = (Window)wind[0];
                    firstgrid = (Grid)wind[1];
                    scrollViewer = (ScrollViewer)wind[2];
                    wrapPanel = (WrapPanel)wind[3];
                    StaticsForTheme.counter++;
                    
                    media.MediaId = item.Id;
                    media.MediaName = item.Attributes.MediaName;
                    media.MediaDescription = item.Attributes.MediaDescription;
                    media.MediaPicture1 = item.Attributes.MediaPicture1;
                    media.MediaPicture2 = item.Attributes.MediaPicture2;
                    media.Firstrating = item.Attributes.Firstrating;
                    media.Secondrating = item.Attributes.Secondrating;
                    media.Acceptableyear = item.Attributes.Acceptableyear;
                    media.Duration = item.Attributes.Duration;
             

                    if (item.Attributes.TblRbMediaType.Data.Id == 3)
                    {
                        foreach (MediaDatum item1 in mediaObject.Data)
                        {
                            string[] item1split = item1.Attributes.MediaName.Split(' ');
                            string[] itemsplit = item.Attributes.MediaName.Split(' ');
                            if (item1split[0] == itemsplit[0])
                            {
                                MainChoosePageModel mainChoose = new MainChoosePageModel();
                                mainChoose.txtforbtninfo = item1.Attributes.MediaName;
                                mainChoose.mediaduration = Convert.ToString(item1.Attributes.Duration);
                                mainChoosePageModel.Add(mainChoose);
                                //if (item1.Attributes.MediaName.Contains($"{counter}Сезон"))
                                //{
                                //    MainChoosePageModel mainChoose = new MainChoosePageModel();
                                //    mainChoose.txtforbtninfo = item.Attributes.MediaName;
                                //    mainChoose.mediaduration = Convert.ToString(item.Attributes.Duration);
                                //    choosePageModels.Add(mainChoose);

                                //}
                                //else if (item1.Attributes.MediaName.Contains($"{counter++}Сезон"))
                                //{
                                //    counter++;
                                //}
                            }
                        }
                        
                       
                    }

                    foreach (var item2 in item.Attributes.TblRbGeners.Data)
                    {


                        media.GenerName.Add(item2.Attributes.GenerName);
                        if (!Geners.Contains(item2.Attributes.GenerName))
                            Geners.Add(item2.Attributes.GenerName);
                    }
                    foreach (var item3 in item.Attributes.TblRbMediaActors.Data)
                    {
                        media.TblRbMediaActors.Add(item3.Attributes.ActorName);
                    }
                    foreach (var item4 in item.Attributes.TblRbCountries.Data)
                    {
                        media.TblRbLanguages.Add(item4.Attributes.LanguageName.ToString());
                        media.TblRbCountries.Add(item4.Attributes.CountryName.ToString());
                        if (!Countries.Contains(item4.Attributes.CountryName.ToString()))
                            Countries.Add(item4.Attributes.CountryName.ToString());

                    }
                    media.TblRbMediaDirector = item.Attributes.TblRbMediaDirector.Data.Attributes.DirectorName.ToString();
                    media.TblRbMediaType = item.Attributes.TblRbMediaType.Data.Attributes.MediaTypeName.ToString();
                    media.TblRbYear = item.Attributes.TblRbYear.Data.Attributes.Year.ToString();
                    if (!Kategory.Contains(item.Attributes.TblRbMediaType.Data.Attributes.MediaTypeName.ToString()))
                        Kategory.Add(item.Attributes.TblRbMediaType.Data.Attributes.MediaTypeName.ToString());

                    foreach (NecessaryMedia existitem in necessaryMedias)
                    {
                        if (existitem.MediaDescription == media.MediaDescription)
                            checker = true;
                    }

                    if(checker == false)
                    {
                        necessaryMedias.Add(media);

                        Button button = new Button();
                        Image image = new Image();



                        image.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + item.Attributes.MediaPicture1, UriKind.Absolute));
                        button.Width = 130;
                        button.Height = 180;
                        button.Name = "default" + $"{item.Id}";
                        button.Background = new SolidColorBrush(Colors.Transparent);
                        button.Margin = new Thickness(10, 0, 0, 0);
                        button.BorderThickness = new Thickness(0);
                        button.Content = image;

                        button.Click += Button_Click;






                        wrapPanel.Children.Add(button);

                        
                    }

                    checker = false;
                   

                }


            }
            
             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaticsForTheme staticsForTheme = new StaticsForTheme();helper = false;
            string content = (sender as Button).Name.ToString();
            foreach (NecessaryMedia item in necessaryMedias)
            {
                if (content.Contains(item.MediaId.ToString()))
                {
                    
                    StaticsForTheme.picforbtnninfo = item.MediaPicture2;
                    //StaticsForTheme.txtforbtninfo = item.MediaName;
                    StaticsForTheme.txtdescription = item.MediaDescription;
                    StaticsForTheme.year = Convert.ToInt32(item.TblRbYear);
                    StaticsForTheme.mediaacceptableyear = item.Acceptableyear.ToString();
                    StaticsForTheme.mediaduration = Convert.ToInt32(item.Duration);
                    StaticsForTheme.secondrating = Convert.ToInt32(item.Secondrating);
                    StaticsForTheme.firstrating = Convert.ToInt32(item.Firstrating);
                    StaticsForTheme.TblRbMediaType = item.TblRbMediaType;
                    foreach (string item1 in item.TblRbCountries)
                    {

                        StaticsForTheme.mediacountry.Add(item1);

                    }



                    foreach (string item1 in item.GenerName)
                    {
                        StaticsForTheme.mediagener.Add(item1);
                    }

                    //StaticsForTheme.medialanguage = item.TblRbLanguages.ToString();
                    //StaticsForTheme.mediadirector = item.TblRbMediaDirector.ToString();
                    //StaticsForTheme.mediaactors = item.TblRbMediaActors.ToString();
                    //StaticsForTheme.mediagener = item.GenerName.ToString();


                }
            }
            //NavigationService.Navigate("INfo", null, this);
            Views.MainFilmInfoPage mainFilmInfoPage = new Views.MainFilmInfoPage();
            mainFilmInfoPage.Show();



        }

        
    }

    
}
