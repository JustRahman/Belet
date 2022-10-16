using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Belet.Model
{
    class StaticsForTheme
    {
        public static bool IsBtnChecked { get; set; }       
        public static string picforbtnninfo { get; set; }  
        public static string txtforbtninfo { get; set; }
        public static ObservableCollection<string> mediacountry { get; set; }
        public static ObservableCollection<string> medialanguage { get; set; }
        public static ObservableCollection<string> mediaactors { get; set; }
        public static string mediaacceptableyear { get; set; }
        public static ObservableCollection<string> mediadirector { get; set; }
        public static ObservableCollection<string> mediagener { get; set; }
        
        public static string TblRbMediaType { get; set; }
        public static string txtdescription { get; set; }
        public static int counter { get; set; }
        public static int year { get; set; }
        public static int firstrating { get; set; }
        public static int secondrating { get; set; }
        public static int seasonquantity { get; set; }
        public static int mediaduration { get; set; }

        public StaticsForTheme()
        {
            
            StaticsForTheme.counter = 0;
            mediacountry = new ObservableCollection<string>();
            mediadirector = new ObservableCollection<string>();
            medialanguage = new ObservableCollection<string>();
            mediagener = new ObservableCollection<string>();
        }
        
    }
    
}
