using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLADR_viewer_v4
{
    public enum SearchArea { All, City, Street };
    static class global
    {
        
        public static string preficsBildProgramm = "   (ver." + System.Windows.Forms.Application.ProductVersion.ToString() + " beta)";
        public static event EventHandler RaiseCustomEvent;
        /// <summary>
        /// Папка расположения баз данных программы
        /// </summary>
        public static string DirectoryProgrammRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer";
        /// <summary>
        /// Глобальный движок кеширования
        /// </summary>
        public static CachinEgngine CashENG;
        private static int cashTimeLimit = 150;

        public static int CashTimeLimit
        {
            get { return global.cashTimeLimit; }
            set { global.cashTimeLimit = (value < 0 ? 999999999 : value); }
        }

        static private KLADR_viewer_v4.my_classes.language.languages _currentLNG;
        static public KLADR_viewer_v4.my_classes.language.languages currentLNG
        {
            get
            {
                return (_currentLNG == null ? KLADR_viewer_v4.my_classes.language.languages.English : _currentLNG);
            }

            set
            {
                _currentLNG = value;
                if (global.RaiseCustomEvent != null)
                    global.RaiseCustomEvent(null, null);
            }
        }

        public static byte[] GetBytesFromString(string s)
        {
            return new ASCIIEncoding().GetBytes(s);
        }
    }
}
