using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belet.ViewModels;
using DevExpress.Mvvm;

namespace Belet.Model
{
    class MainChoosePageModel:ViewModelBase
    {
        private string _IsBigOrNormal;
        public string IsBigOrNormal
        {
            get
            {
                return _IsBigOrNormal;
            }
            set
            {
                SetValue(ref _IsBigOrNormal, value);
            }
        }


        private string _picforbtnninfo;
        public string picforbtnninfo
        {
            get
            {
                return _picforbtnninfo;
            }
            set
            {
                SetValue(ref _picforbtnninfo, value);
            }
        }

        private string _mediaduration;
        public string mediaduration
        {
            get
            {
                return _mediaduration;
            }
            set
            {
                SetValue(ref _mediaduration, value);
            }
        }

        private string _txtforbtninfo;
        public string txtforbtninfo
        {
            get
            {
                return _txtforbtninfo;
            }
            set
            {
                SetValue(ref _txtforbtninfo, value);
            }
        }

        private string _tblRbMediaType;
        public string tblRbMediaType
        {
            get
            {
                return _tblRbMediaType;
            }
            set
            {
                SetValue(ref _tblRbMediaType, value);
            }
        }

        private string _txtdescription;
        public string txtdescription
        {
            get
            {
                return _txtdescription;
            }
            set
            {
                SetValue(ref _txtdescription, value);
            }
        }

        private string _tblmediacountry;
        public string tblmediacountry
        {
            get
            {
                return _tblmediacountry;
            }
            set
            {
                SetValue(ref _tblmediacountry, value);
            }
        }

    

        private string _tblmedialanguage;
        public string tblmedialanguage
        {
            get
            {
                return _tblmedialanguage;
            }
            set
            {
                SetValue(ref _tblmedialanguage, value);
            }
        }

            private string _tblmediaactors;
        public string tblmediaactors
        {
            get
            {
                return _tblmediaactors;
            }
            set
            {
                SetValue(ref _tblmediaactors, value);
            }
        }

            private string _tblmediadirector;
        public string tblmediadirector
        {
            get
            {
                return _tblmediadirector;
            }
            set
            {
                SetValue(ref _tblmediadirector, value);
            }
        }

            private int _tblmediayear;
        public int tblmediayear
        {
            get
            {
                return _tblmediayear;
            }
            set
            {
                SetValue(ref _tblmediayear, value);
            }
        }


        private int _tblfirstrating;
        public int tblfirstrating
        {
            get
            {
                return _tblfirstrating;
            }
            set
            {
                SetValue(ref _tblfirstrating, value);
            }
        }
      
        private string _tblfirstratingbcgr;
        public string tblfirstratingbcgr
        {
            get
            {
                return _tblfirstratingbcgr;
            }
            set
            {
                SetValue(ref _tblfirstratingbcgr, value);
            }
        }


        private string _tblsecondratingbcgr;
        public string tblsecodndtratingbcgr
        {
            get
            {
                return _tblsecondratingbcgr;
            }
            set
            {
                SetValue(ref _tblsecondratingbcgr, value);
            }
        }


        private int _tblmediasecondrating;
        public int tblmediasecondrating
        {
            get
            {
                return _tblmediasecondrating;
            }
            set
            {
                SetValue(ref _tblmediasecondrating, value);
            }
        }

        private int _tblmediaseasonquality;
        public int tblmediaseasonquality
        {
            get
            {
                return _tblmediaseasonquality;
            }
            set
            {
                SetValue(ref _tblmediaseasonquality, value);
            }
        }

        private int _tblmediamediaduration;
        public int tblmediamediaduration
        {
            get
            {
                return _tblmediamediaduration;
            }
            set
            {
                SetValue(ref _tblmediamediaduration, value);
            }
        }

        private string _tblmediaacceptableyear;
        public string tblmediaacceptableyear
        {
            get
            {
                return _tblmediaacceptableyear;
            }
            set
            {
                SetValue(ref _tblmediaacceptableyear, value);
            }
        }

        private string _tblmediagener;
        public string tblmediagener
        {
            get
            {
                return _tblmediagener;
            }
            set
            {
                SetValue(ref _tblmediagener, value);
            }
        }

    }
}
