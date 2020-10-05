using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Community.CsharpSqlite.SQLiteClient;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace KLADR_viewer_v4.management
{
    public class workDataBase
    {
        #region variables
        private SqliteConnection mySQLITEConnection;
        private SqliteCommand mySQLITECommand;
        private SqliteDataReader mySQLITEReader;
        private SqliteDataAdapter mySQLITEDataAdapter;
        private DataSet mySQLITEDataSet;
        private DbTransaction mySQLITETransaction;

        DictionaryConnections regionsDataBases = new DictionaryConnections();
        Dictionary<string, SqliteCommand> regionsDBComands = new Dictionary<string, SqliteCommand>();

        public Dictionary<string, KLADR> KladrElements;
        public delegate void updateStatusLabelStartFormDelegate(string newStatus, FormStart invokeForm);
        #endregion

        public workDataBase()
        {
            mySQLITEConnection = new SqliteConnection();
            mySQLITECommand = ((SqliteCommand)mySQLITEConnection.CreateCommand());
            KladrElements = new Dictionary<string, KLADR>();
        }

        public bool selectNode(KLADR kladr)
        {
            System.Diagnostics.Stopwatch cashTimeStamp = new System.Diagnostics.Stopwatch();
            
            string codeObject = kladr.code;
            string codeRegion = codeObject.Substring(0, 2);
            string codeRayon = codeObject.Substring(2, 3);
            string codeCity = codeObject.Substring(5, 3);
            string codeSmallCity = codeObject.Substring(8, 3);
            string codeStreet = codeObject.Length < 17 ? "" : codeObject.Substring(11, 4);
            string codeHome = codeObject.Length < 19 ? "" : codeObject.Substring(15, 4);
            KladrElements.Clear();

            List<Dictionary<string, string>> fromCash = global.CashENG.getFromCashAsBin(codeObject);

            if (fromCash != null)
            {
                foreach (Dictionary<string, string> s in fromCash)
                    KladrElements.Add(s["code"], new KLADR(s["name"], s["socr"], s["post_index"], s["code"], s["gninmb"], s["uno"], s["ocatd"], null, null, s["typeObj"]));
                return true;
            }

            cashTimeStamp.Start();
            ArrayList queryTextList = new ArrayList();
            if (Regex.IsMatch(codeObject, @"^..000000000..$")) // регионы
            {
                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'city' as typeObj FROM KLADR WHERE " + // город в регионе
                    " code LIKE '__000___000__' AND code NOT LIKE '_____000_____' ORDER BY name");

                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'smallcity' as typeObj FROM KLADR WHERE " + // нас. пункт в регионе
                    " code LIKE '__000000_____' AND code NOT LIKE '________000__' ORDER BY name");

                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'area' as typeObj FROM KLADR WHERE " + // районы в регионах
                    " code LIKE '_____000000__' AND code NOT LIKE '__000________' ORDER BY name");

                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'street' as typeObj FROM KLADR WHERE " + // street
                    " (code LIKE '__000000000______') ORDER BY name");
            }
            else if (Regex.IsMatch(codeObject, @"^.{5}000000..$") && !Regex.IsMatch(codeObject, @"^..000000000..$")) //районы
            {
                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'city' as typeObj FROM KLADR WHERE " + // города в районах
                    " code LIKE '__" + codeRayon + "___000__' AND code NOT LIKE '_____000_____'  ORDER BY name");

                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'smallcity' as typeObj FROM KLADR WHERE " + // нас. пункты в районах
                " code LIKE '__" + codeRayon + "000_____' AND code NOT LIKE '________000__' ORDER BY name");
            }
            else if (Regex.IsMatch(codeObject, @"^.{8}000..$") && !Regex.IsMatch(codeObject, @"^.{5}000.{5}$")) // города
            {
                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'smallcity' as typeObj FROM KLADR WHERE " + // нас. пункты в городах
                " code LIKE '__" + codeRayon + codeCity + "_____' AND code NOT LIKE '________000__' ORDER BY name");

                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'street' as typeObj FROM KLADR WHERE " + // улицы в городах
                " code LIKE '__" + codeRayon + codeCity + "_________' ORDER BY name");
            }
            else if (codeObject.Length == 13) // нас пункты
            {
                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'street' as typeObj FROM KLADR WHERE " + // улицы в городах
                " code LIKE '__" + codeRayon + codeCity + codeSmallCity + "______' ORDER BY name");
            }
            else if (codeObject.Length == 17) // улицы
            {
                queryTextList.Add("SELECT name, socr, code, post_index, gninmb, uno, ocatd, 'home' as typeObj FROM KLADR WHERE " + // улицы в городах
                " code LIKE '__" + codeRayon + codeCity + codeSmallCity + codeStreet + "____' ORDER BY name");
            }

            List<Dictionary<string, string>> courceForCashing2 = new List<Dictionary<string, string>>();
            foreach (string queryText in queryTextList)
            {
                regionsDBComands[codeRegion].CommandText = queryText;
                mySQLITEReader = regionsDBComands[codeRegion].ExecuteReader();
                while (mySQLITEReader.Read())
                {
                    KladrElements.Add(mySQLITEReader["code"].ToString(), new KLADR(mySQLITEReader));
                    courceForCashing2.Add(new Dictionary<string, string>() { 
                    { "name", mySQLITEReader["name"].ToString() }
                    ,{ "socr", mySQLITEReader["socr"].ToString() }
                    ,{ "code", mySQLITEReader["code"].ToString() }
                    ,{ "post_index", mySQLITEReader["post_index"].ToString() }
                    ,{ "gninmb", mySQLITEReader["gninmb"].ToString() }
                    ,{ "uno", mySQLITEReader["uno"].ToString() }
                    ,{ "ocatd", mySQLITEReader["ocatd"].ToString() }
                    ,{ "typeObj", mySQLITEReader["typeObj"].ToString() }
                    });
                }
                mySQLITEReader.Close();
            }
            cashTimeStamp.Stop();
            if (cashTimeStamp.ElapsedMilliseconds > global.CashTimeLimit)
            {
                global.CashENG.addNode(kladr.code, courceForCashing2);
            }
            regionsDataBases[codeRegion].Close();
            regionsDataBases[codeRegion].Open();
            regionsDBComands[codeRegion] = ((SqliteCommand)regionsDataBases[codeRegion].CreateCommand());
            return true;
        }

        public bool selectDataBase(string folderName, FormStart invokeForm)
        {
            try
            {
                KladrElements.Clear();
                regionsDataBases.CloseAllConnections();
                regionsDataBases.Clear();
                regionsDBComands.Clear();
                //regionsDBTransactions.Clear();
                if (mySQLITEConnection.State != ConnectionState.Closed)
                    mySQLITEConnection.Close();
                string dirDataBase = global.DirectoryProgrammRoot + "\\" + folderName + "\\";
                if (global.CashENG != null)
                    global.CashENG.Dispose();
                global.CashENG = new CachinEgngine(global.DirectoryProgrammRoot + "\\" + folderName + "\\");
                foreach (string file in Directory.GetFiles(global.DirectoryProgrammRoot + "\\" + folderName, "*.sqlite"))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(file, @"\\\d\d\.sqlite$"))
                        continue;
                    string codeFile = Path.GetFileNameWithoutExtension(file);
                    regionsDataBases.Add(codeFile, new SqliteConnection(string.Format("Version=3,uri=file:{0},Cache Size=20000", file)));
                    regionsDataBases[codeFile].Open();
                    regionsDBComands.Add(codeFile, ((SqliteCommand)regionsDataBases[codeFile].CreateCommand()));
                    //regionsDBTransactions.Add(codeFile, regionsDataBases[codeFile].BeginTransaction());
                    regionsDBComands[codeFile].CommandText = "SELECT name, socr, code, post_index, gninmb, uno, ocatd, status, '' as typeObj, '' as korp FROM kladr WHERE code LIKE '__000000000__'";
                    mySQLITEReader = regionsDBComands[codeFile].ExecuteReader();
                    mySQLITEReader.Read();
                    lock (invokeForm)
                    {
                        invokeForm.toolStripStatusLabelStart.Text = my_classes.language.other._connected_to_data_base_of_open+": '" + mySQLITEReader["name"].ToString() + " " + mySQLITEReader["socr"].ToString() + "'";
                    }
                    //invokeForm.Invoke(new updateStatusLabelStartFormDelegate(delegate(string message, FormStart invokeForm2) { invokeForm2.toolStripStatusLabelStart.Text = message; }), new object[] { "connected to the base region: '" + mySQLITEReader["name"].ToString() + " " + mySQLITEReader["socr"].ToString() + "'", invokeForm });
                    KladrElements.Add(mySQLITEReader["code"].ToString().Substring(0, 2), new KLADR(mySQLITEReader));
                    mySQLITEReader.Close();
                    GC.Collect();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public void search(string how, string where, SearchArea SA)
        {
            string where2 = SA == SearchArea.City ? "_____________" : "_________________";

            how = how.Trim();
            string CommandText;
            if (how.Substring(0, 1) == "{" && how.Substring(how.Length - 1, 1) == "}")
            {
                how = how.Substring(1, how.Length - 2);
                CommandText = "SELECT name, socr, code, post_index, gninmb, uno, ocatd, status, '' as typeObj FROM KLADR WHERE (" + (SA == SearchArea.All ? "1=1" : "code LIKE :querySqarch2") + ") AND (name LIKE :querySqarch OR code LIKE :querySqarch OR post_index LIKE :querySqarch OR gninmb LIKE :querySqarch OR uno LIKE :querySqarch OR ocatd LIKE :querySqarch)";
            }
            else
            {
                how = "%" + how.ToLower() + "%";
                CommandText = "SELECT name, socr, code, post_index, gninmb, uno, ocatd, status, '' as typeObj FROM KLADR WHERE (" + (SA == SearchArea.All ? "1=1" : "code LIKE :querySqarch2") + ") AND (lower(name) LIKE :querySqarch OR lower(code) LIKE :querySqarch OR lower(post_index) LIKE :querySqarch OR lower(gninmb) LIKE :querySqarch OR lower(uno) LIKE :querySqarch OR lower(ocatd) LIKE :querySqarch)";
            }

            

            KladrElements.Clear();
            regionsDBComands[where].Parameters.Clear();
            regionsDBComands[where].Parameters.Add(new SqliteParameter("querySqarch", DbType.String));
            regionsDBComands[where].Parameters.Add(new SqliteParameter("querySqarch2", DbType.String));
            regionsDBComands[where].CommandText = CommandText;
            regionsDBComands[where].Parameters["querySqarch"].Value = how;
            regionsDBComands[where].Parameters["querySqarch2"].Value = where2;

            //regionsDBComands[where].CommandText = string.Format(CommandText.Replace(":querySqarch", "{0}"), "'" + how.Replace("'","\'") + "'");

            mySQLITEReader = regionsDBComands[where].ExecuteReader();
            while (mySQLITEReader.Read())
            {
                string code = mySQLITEReader["code"].ToString();
                if (!KladrElements.ContainsKey(code))
                    KladrElements.Add(code, new KLADR(mySQLITEReader));
                else
                    KladrElements.Add(code + "_2", new KLADR(mySQLITEReader));
            }
            mySQLITEReader.Close();
        }
    }
}
