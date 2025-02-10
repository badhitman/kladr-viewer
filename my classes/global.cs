using System;
using System.Text;

namespace KLADR_viewer_v4
{
    public enum SearchArea { All, City, Street };
    static class Global
    {

        public static string preficsBildProgramm = "   (ver." + System.Windows.Forms.Application.ProductVersion.ToString() + " beta)";
        public static event EventHandler RaiseCustomEvent;
        /// <summary>
        /// Папка расположения баз данных программы
        /// </summary>
        public static string DirectoryProgramRoot = $"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}\\KLADR-Viewer";
        /// <summary>
        /// Глобальный движок кеширования
        /// </summary>
        public static CachingEngine CashENG;
        private static int cashTimeLimit = 150;

        public static int CashTimeLimit
        {
            get { return cashTimeLimit; }
            set { cashTimeLimit = value < 0 ? 999999999 : value; }
        }

        static private my_classes.Language.Languages? _currentLNG;
        static public my_classes.Language.Languages CurrentLNG
        {
            get
            {
                return _currentLNG is null 
                    ? my_classes.Language.Languages.English 
                    : _currentLNG.Value;
            }

            set
            {
                _currentLNG = value;
                RaiseCustomEvent?.Invoke(null, null);
            }
        }

        public static byte[] GetBytesFromString(string s)
        {
            return new ASCIIEncoding().GetBytes(s);
        }
    }
}
