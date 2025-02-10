using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Community.CsharpSqlite.SQLiteClient;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using KLADR_viewer_v4.my_classes;

namespace KLADR_viewer_v4.management
{
    class databases
    {
        #region variables
        private SqliteConnection mySQLITEConnection;
        private SqliteCommand mySQLITECommand;
        private SqliteDataReader mySQLITEReader;
        private SqliteDataAdapter mySQLITEDataAdapter;
        private DataSet mySQLITEDataSet;
        private DbTransaction mySQLITETransaction;

        private OleDbConnection myDBFConnection;
        private OleDbCommand myDBFCommand;
        private OleDbDataReader myDBFDataReader;

        private delegate void load_DBFtoSQLiteDelegate();
        load_DBFtoSQLiteDelegate load_DBFtoSQLiteDelegateObject;

        private delegate void universalDelegate();

        private Dictionary<string, string> altNames;
        #endregion

        private void log(FormCreateDB invokeForm, string message)
        {
            invokeForm.BeginInvoke(new universalDelegate(delegate()
                {
                    invokeForm.textBoxLog.AppendText("\r\n" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " " + message);
                }));
        }

        private string altNamesParse(string Code)
        {
            if (Code.Length <= 17)
                Code = altNamesParse(Code.Substring(0, Code.Length - 2) + "00");
            if (!altNames.ContainsKey(Code))
                return Code;
            else
            {
                return altNamesParse(Code);
            }
        }

        public void LoadDbfToSqliteStart(string folderDBF, string folderSQLITE, FormCreateDB invokeForm)
        {
            bool stopedAcynhOperation = false;
            altNames = new Dictionary<string, string>();
            FormClosingEventHandler SafeCloseForm = null;
            load_DBFtoSQLiteDelegateObject = new load_DBFtoSQLiteDelegate(
                delegate()
                {
                    if (myDBFConnection == null)
                    {
                        myDBFConnection = new OleDbConnection();
                        myDBFCommand = myDBFConnection.CreateCommand();
                    }
                    else if (myDBFConnection.State != ConnectionState.Closed)
                    {
                        myDBFConnection.Close();
                    }
                    try
                    {
                        invokeForm.BeginInvoke(new universalDelegate(delegate() { invokeForm.textBoxLog.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + " " + Language.Other.Create_connect_to_dbf); }));
                        myDBFConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + folderDBF + "\\;Extended Properties=DBASE IV;Persist Security Info=False;";
                        myDBFConnection.Open();
                        myDBFCommand = myDBFConnection.CreateCommand();
                        log(invokeForm, Language.Other.Test_correct_dbf_text);
                        myDBFCommand.CommandText = "SELECT TOP 1 " +
                            "  `ALTNAMES`.`OLDCODE`, `ALTNAMES`.`NEWCODE`, `ALTNAMES`.`LEVEL`" +
                            ", `FLAT`.`CODE`, `FLAT`.`NP`, `FLAT`.`GNINMB`, `FLAT`.`NAME`, `FLAT`.`INDEX`, `FLAT`.`UNO`" +
                            ", `SOCRBASE`.`LEVEL`, `SOCRBASE`.`SCNAME`, `SOCRBASE`.`SOCRNAME`, `SOCRBASE`.`KOD_T_ST`" +
                            ", `KLADR`.`NAME`, `KLADR`.`SOCR`, `KLADR`.`CODE`, `KLADR`.`INDEX`, `KLADR`.`GNINMB`, `KLADR`.`UNO`, `KLADR`.`OCATD`, `KLADR`.`STATUS`" +
                            ", `STREET`.`NAME`, `STREET`.`SOCR`, `STREET`.`CODE`, `STREET`.`INDEX`, `STREET`.`GNINMB`, `STREET`.`UNO`, `STREET`.`OCATD`" +
                            ", `DOMA`.`NAME`, `DOMA`.`KORP`, `DOMA`.`SOCR`, `DOMA`.`CODE`, `DOMA`.`INDEX`, `DOMA`.`GNINMB`, `DOMA`.`UNO`, `DOMA`.`OCATD`" +
                            " FROM `altnames`, `flat`, `socrbase`, `kladr`, `street`, `doma`";
                        myDBFCommand.ExecuteNonQuery();
                        myDBFConnection.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(Language.Other.Unable_to_connect_to_db + folderDBF + "{" + e.Message + "}", Language.Other.Error_connect_to_db, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (mySQLITEConnection == null)
                    {
                        mySQLITEConnection = new SqliteConnection();
                    }
                    else if (mySQLITEConnection.State != ConnectionState.Closed)
                    {
                        mySQLITEConnection.Close();
                    }
                    folderSQLITE = Global.DirectoryProgramRoot + "\\" + folderSQLITE + "\\";
                    if (!Directory.Exists(folderSQLITE))
                    {
                        Directory.CreateDirectory(folderSQLITE);
                    }

                    log(invokeForm, Language.Other.Create_connect);
                    mySQLITEConnection = new SqliteConnection(string.Format("Version=3,uri=file:{0}", folderSQLITE + "service.sqlite"));
                    mySQLITECommand = ((SqliteCommand)mySQLITEConnection.CreateCommand());
                    mySQLITEConnection.Open();
                    mySQLITECommand.CommandText = "PRAGMA journal_mode = off";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITECommand.CommandText = "PRAGMA temp_store = MEMORY";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITECommand.CommandText = "PRAGMA synchronous = off";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITECommand.CommandText = "PRAGMA cache_size = 16000";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITECommand.CommandText = "PRAGMA count_changes = off";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITETransaction = mySQLITEConnection.BeginTransaction();
                    /*
                    //log(invokeForm, "Create def table to DB SQLite.");
                    mySQLITECommand.CommandText = @"CREATE TABLE  ALTNAMES (OLDCODE TEXT NOT NULL, NEWCODE TEXT NOT NULL, LEVEL TEXT NOT NULL);";
                    mySQLITECommand.ExecuteNonQuery();
                    mySQLITECommand.CommandText = @"CREATE TABLE  FLAT (CODE TEXT NOT NULL, NP TEXT NOT NULL, GNINMB TEXT NOT NULL, NAME TEXT NOT NULL, POST_INDEX TEXT NOT NULL, UNO TEXT NOT NULL);";
                    mySQLITECommand.ExecuteNonQuery();
                     */
                    mySQLITECommand.CommandText = @"CREATE TABLE  SOCRBASE (LEVEL TEXT NOT NULL, SCNAME TEXT NOT NULL, SOCRNAME TEXT NOT NULL, KOD_T_ST TEXT NOT NULL);";
                    mySQLITECommand.ExecuteNonQuery();


                    myDBFConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + folderDBF + "\\;Extended Properties=DBASE IV;Persist Security Info=False;");
                    myDBFConnection.Open();
                    myDBFCommand = myDBFConnection.CreateCommand();
                    //******************************************************************
                    //
                    //log(invokeForm, "Transfer/caching records 'ALTNAMES'.");
                    //myDBFCommand.CommandText = "SELECT `ALTNAMES`.`OLDCODE`, `ALTNAMES`.`NEWCODE`, `ALTNAMES`.`LEVEL` FROM altnames";
                    //myDBFDataReader = myDBFCommand.ExecuteReader();
                    //mySQLITECommand.Parameters.Clear();
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("OLDCODE", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("NEWCODE", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("LEVEL", System.Data.DbType.String));
                    //while (myDBFDataReader.Read())
                    //{
                        //altNames.Add(myDBFDataReader["OLDCODE"].ToString(), myDBFDataReader["NEWCODE"].ToString());
                    //    mySQLITECommand.Parameters["OLDCODE"].Value = myDBFDataReader["OLDCODE"].ToString();
                    //    mySQLITECommand.Parameters["NEWCODE"].Value = myDBFDataReader["NEWCODE"].ToString();
                    //    mySQLITECommand.Parameters["LEVEL"].Value = myDBFDataReader["LEVEL"].ToString();
                    //    mySQLITECommand.CommandText = "INSERT INTO ALTNAMES (OLDCODE, NEWCODE, LEVEL) VALUES(:OLDCODE, :NEWCODE, :LEVEL)";
                    //    if (stopedAcynhOperation)
                    //    {
                    //        mySQLITEConnection.Close();
                    //        return;
                    //    }
                    //    mySQLITECommand.ExecuteNonQuery();
                    //}
                    //myDBFDataReader.Close();
                    //******************************************************************
                    //
                    //log(invokeForm, "Transfer records 'FLAT' DBF->SQLite.");
                    //myDBFCommand.CommandText = "SELECT `FLAT`.`CODE`, `FLAT`.`NP`, `FLAT`.`GNINMB`, `FLAT`.`NAME`, `FLAT`.`INDEX`, `FLAT`.`UNO` FROM FLAT";
                    //myDBFDataReader = myDBFCommand.ExecuteReader();
                    //mySQLITECommand.Parameters.Clear();
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("CODE", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("NP", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("GNINMB", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("NAME", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("INDEX", System.Data.DbType.String));
                    //mySQLITECommand.Parameters.Add(new SqliteParameter("UNO", System.Data.DbType.String));
                    //while (myDBFDataReader.Read())
                    //{
                    //    mySQLITECommand.Parameters["CODE"].Value = myDBFDataReader["CODE"].ToString();
                    //    mySQLITECommand.Parameters["NP"].Value = myDBFDataReader["NP"].ToString();
                    //    mySQLITECommand.Parameters["GNINMB"].Value = myDBFDataReader["GNINMB"].ToString();
                    //    mySQLITECommand.Parameters["NAME"].Value = myDBFDataReader["NAME"].ToString();
                    //    mySQLITECommand.Parameters["INDEX"].Value = myDBFDataReader["INDEX"].ToString();
                    //    mySQLITECommand.Parameters["UNO"].Value = myDBFDataReader["UNO"].ToString();
                    //    mySQLITECommand.CommandText = "INSERT INTO FLAT (CODE, NP, GNINMB, NAME, POST_INDEX, UNO) VALUES(:CODE, :NP, :GNINMB, :NAME, :POST_INDEX, :UNO)";
                    //    if (stopedAcynhOperation)
                    //    {
                    //        mySQLITEConnection.Close();
                    //        return;
                    //    }
                    //    mySQLITECommand.ExecuteNonQuery();
                    //}
                    //myDBFDataReader.Close();
                    //******************************************************************
                    //
                    log(invokeForm, Language.Other.Transfer_records_socrbase);
                    myDBFCommand.CommandText = "SELECT `SOCRBASE`.`LEVEL`, `SOCRBASE`.`SCNAME`, `SOCRBASE`.`SOCRNAME`, `SOCRBASE`.`KOD_T_ST` FROM SOCRBASE";
                    myDBFDataReader = myDBFCommand.ExecuteReader();
                    mySQLITECommand.Parameters.Clear();
                    mySQLITECommand.Parameters.Add(new SqliteParameter("LEVEL", System.Data.DbType.String));
                    mySQLITECommand.Parameters.Add(new SqliteParameter("SCNAME", System.Data.DbType.String));
                    mySQLITECommand.Parameters.Add(new SqliteParameter("SOCRNAME", System.Data.DbType.String));
                    mySQLITECommand.Parameters.Add(new SqliteParameter("KOD_T_ST", System.Data.DbType.String));
                    while (myDBFDataReader.Read())
                    {
                        mySQLITECommand.Parameters["LEVEL"].Value = myDBFDataReader["LEVEL"].ToString();
                        mySQLITECommand.Parameters["SCNAME"].Value = myDBFDataReader["SCNAME"].ToString();
                        mySQLITECommand.Parameters["SOCRNAME"].Value = myDBFDataReader["SOCRNAME"].ToString();
                        mySQLITECommand.Parameters["KOD_T_ST"].Value = myDBFDataReader["KOD_T_ST"].ToString();
                        mySQLITECommand.CommandText = "INSERT INTO SOCRBASE (LEVEL, SCNAME, SOCRNAME, KOD_T_ST) VALUES(:LEVEL, :SCNAME, :SOCRNAME, :KOD_T_ST)";
                        if (stopedAcynhOperation)
                        {
                            mySQLITEConnection.Close();
                            return;
                        }
                        mySQLITECommand.ExecuteNonQuery();
                    }
                    myDBFDataReader.Close();

                    DictionaryConnections regionsDBConnections = new DictionaryConnections();
                    Dictionary<string, SqliteCommand> regionsDBComands = new Dictionary<string, SqliteCommand>();
                    Dictionary<string, DbTransaction> regionsDBTransactions = new Dictionary<string, DbTransaction>();

                    #region Load table KLADR.DBF
                    myDBFCommand.CommandText = "SELECT `KLADR`.`NAME`, `KLADR`.`SOCR`, `KLADR`.`CODE`, `KLADR`.`INDEX`, `KLADR`.`GNINMB`, `KLADR`.`UNO`, `KLADR`.`OCATD`, `KLADR`.`STATUS` FROM KLADR";
                    myDBFDataReader = myDBFCommand.ExecuteReader();
                    mySQLITECommand.Parameters.Clear();
                    string NAME;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("NAME", System.Data.DbType.String));
                    string SOCR;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("SOCR", System.Data.DbType.String));
                    string CODE;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("CODE", System.Data.DbType.String));
                    string POST_INDEX;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("POST_INDEX", System.Data.DbType.String));
                    string GNINMB;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("GNINMB", System.Data.DbType.String));
                    string UNO;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("UNO", System.Data.DbType.String));
                    string OCATD;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("OCATD", System.Data.DbType.String));
                    string STATUS;
                    mySQLITECommand.Parameters.Add(new SqliteParameter("STATUS", System.Data.DbType.String));
                    log(invokeForm, Language.Other.Transfer_records_kladr+"Transfer records 'KLADR' DBF->SQLite...");
                    string coderegion;
                    while (myDBFDataReader.Read())
                    {
                        NAME = myDBFDataReader["NAME"].ToString();
                        SOCR = myDBFDataReader["SOCR"].ToString();
                        CODE = myDBFDataReader["CODE"].ToString();
                        //if (CODE.Substring(CODE.Length - 2) != "00")
                        //    continue;
                        POST_INDEX = myDBFDataReader["INDEX"].ToString();
                        GNINMB = myDBFDataReader["GNINMB"].ToString();
                        UNO = myDBFDataReader["UNO"].ToString();
                        OCATD = myDBFDataReader["OCATD"].ToString();
                        STATUS = myDBFDataReader["STATUS"].ToString();
                        coderegion = CODE.Substring(0, 2);
                        if (!regionsDBConnections.ContainsKey(coderegion))
                        {
                            regionsDBConnections.Add(coderegion, new SqliteConnection(string.Format("Version=3,uri=file:{0}.sqlite", folderSQLITE + coderegion)));
                            regionsDBComands.Add(coderegion, ((SqliteCommand)regionsDBConnections[coderegion].CreateCommand()));
                            log(invokeForm, Language.Other.Create_data_base_to_region+" '" + coderegion + "'");
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("NAME", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("KORP", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("SOCR", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("CODE", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("POST_INDEX", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("GNINMB", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("UNO", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("OCATD", System.Data.DbType.String));
                            regionsDBComands[coderegion].Parameters.Add(new SqliteParameter("STATUS", System.Data.DbType.String));
                            regionsDBTransactions.Add(coderegion, null);

                            regionsDBConnections[coderegion].Open();
                            regionsDBComands[coderegion].CommandText = "PRAGMA journal_mode = off";
                            regionsDBComands[coderegion].ExecuteNonQuery();
                            //regionsDBComands[coderegion].CommandText = "PRAGMA temp_store = MEMORY";
                            //regionsDBComands[coderegion].ExecuteNonQuery();
                            regionsDBComands[coderegion].CommandText = "PRAGMA synchronous = off";
                            regionsDBComands[coderegion].ExecuteNonQuery();
                            //regionsDBComands[coderegion].CommandText = "PRAGMA cache_size = 16000";
                            //regionsDBComands[coderegion].ExecuteNonQuery();
                            regionsDBComands[coderegion].CommandText = "PRAGMA count_changes = off";
                            regionsDBComands[coderegion].ExecuteNonQuery();
                            regionsDBTransactions[coderegion] = regionsDBConnections[coderegion].BeginTransaction();
                            regionsDBComands[coderegion].CommandText = "CREATE TABLE KLADR (NAME TEXT NOT NULL, SOCR TEXT NOT NULL, CODE TEXT NOT NULL, POST_INDEX TEXT NOT NULL, GNINMB TEXT NOT NULL, UNO TEXT NOT NULL, OCATD TEXT NOT NULL, STATUS TEXT NOT NULL DEFAULT 'NONE', countSubItems INTEGER NOT NULL);";
                            regionsDBComands[coderegion].ExecuteNonQuery();
                            //regionsDBComands[coderegion].CommandText = "CREATE TABLE STREET (NAME TEXT NOT NULL, SOCR TEXT NOT NULL, CODE TEXT NOT NULL, POST_INDEX TEXT NOT NULL, GNINMB TEXT NOT NULL, UNO TEXT NOT NULL, OCATD TEXT NOT NULL);";
                            //regionsDBComands[coderegion].ExecuteNonQuery();
                            //regionsDBComands[coderegion].CommandText = "CREATE TABLE DOMA (NAME TEXT NOT NULL, KORP TEXT NOT NULL, SOCR TEXT NOT NULL, CODE TEXT NOT NULL, POST_INDEX TEXT NOT NULL, GNINMB TEXT NOT NULL, UNO TEXT NOT NULL, OCATD TEXT NOT NULL);";
                            //regionsDBComands[coderegion].ExecuteNonQuery();
                        }
                        regionsDBComands[coderegion].Parameters["NAME"].Value = NAME.Replace("\t", " ").Replace("  ", " ");
                        regionsDBComands[coderegion].Parameters["SOCR"].Value = SOCR;
                        regionsDBComands[coderegion].Parameters["CODE"].Value = CODE;
                        regionsDBComands[coderegion].Parameters["POST_INDEX"].Value = POST_INDEX;
                        regionsDBComands[coderegion].Parameters["GNINMB"].Value = GNINMB;
                        regionsDBComands[coderegion].Parameters["UNO"].Value = UNO;
                        regionsDBComands[coderegion].Parameters["OCATD"].Value = OCATD;
                        regionsDBComands[coderegion].Parameters["STATUS"].Value = STATUS;
                        regionsDBComands[coderegion].CommandText = "INSERT INTO KLADR (NAME, SOCR, CODE, POST_INDEX, GNINMB, UNO, OCATD, STATUS, countSubItems) VALUES(:NAME, :SOCR, :CODE, :POST_INDEX, :GNINMB, :UNO, :OCATD, :STATUS, -1)";
                        if (stopedAcynhOperation)
                        {
                            regionsDBConnections.CloseAllConnections();
                            mySQLITEConnection.Close();
                            return;
                        }
                        regionsDBComands[coderegion].ExecuteNonQuery();
                        
                    }
                    myDBFDataReader.Close();
                    #endregion
                    
                    #region Load table STREET.DBF
                    myDBFCommand.CommandText = "SELECT `STREET`.`NAME`, `STREET`.`SOCR`, `STREET`.`CODE`, `STREET`.`INDEX`, `STREET`.`GNINMB`, `STREET`.`UNO`, `STREET`.`OCATD` FROM STREET";
                    myDBFDataReader = myDBFCommand.ExecuteReader();
                    log(invokeForm, Language.Other.Transfer_records_street);
                    while (myDBFDataReader.Read())
                    {
                        NAME = myDBFDataReader["NAME"].ToString();
                        SOCR = myDBFDataReader["SOCR"].ToString();
                        CODE = myDBFDataReader["CODE"].ToString();
                        if (CODE.Substring(CODE.Length - 2) != "00")
                            continue;
                        POST_INDEX = myDBFDataReader["INDEX"].ToString();
                        GNINMB = myDBFDataReader["GNINMB"].ToString();
                        UNO = myDBFDataReader["UNO"].ToString();
                        OCATD = myDBFDataReader["OCATD"].ToString();
                        coderegion = CODE.Substring(0, 2);

                        regionsDBComands[coderegion].Parameters["NAME"].Value = NAME;
                        regionsDBComands[coderegion].Parameters["SOCR"].Value = SOCR;
                        regionsDBComands[coderegion].Parameters["CODE"].Value = CODE;
                        regionsDBComands[coderegion].Parameters["POST_INDEX"].Value = POST_INDEX;
                        regionsDBComands[coderegion].Parameters["GNINMB"].Value = GNINMB;
                        regionsDBComands[coderegion].Parameters["UNO"].Value = UNO;
                        regionsDBComands[coderegion].Parameters["OCATD"].Value = OCATD;
                        regionsDBComands[coderegion].CommandText = "INSERT INTO KLADR (NAME, SOCR, CODE, POST_INDEX, GNINMB, UNO, OCATD, countSubItems) VALUES(:NAME, :SOCR, :CODE, :POST_INDEX, :GNINMB, :UNO, :OCATD, -1)";
                        if (stopedAcynhOperation)
                        {
                            regionsDBConnections.CloseAllConnections();
                            mySQLITEConnection.Close();
                            return;
                        }
                        regionsDBComands[coderegion].ExecuteNonQuery();
                    }
                    myDBFDataReader.Close();
                    #endregion
                    
                    #region Load table DOMA.DBF
                    string KORP;
                    myDBFCommand.CommandText = "SELECT `DOMA`.`NAME`, `DOMA`.`KORP`, `DOMA`.`SOCR`, `DOMA`.`CODE`, `DOMA`.`INDEX`, `DOMA`.`GNINMB`, `DOMA`.`UNO`, `DOMA`.`OCATD` FROM DOMA";
                    myDBFDataReader = myDBFCommand.ExecuteReader();
                    log(invokeForm, Language.Other.Transfer_records_doma);
                    while (myDBFDataReader.Read())
                    {
                        NAME = myDBFDataReader["NAME"].ToString();
                        KORP = myDBFDataReader["KORP"].ToString();
                        SOCR = myDBFDataReader["SOCR"].ToString();
                        CODE = myDBFDataReader["CODE"].ToString();
                        POST_INDEX = myDBFDataReader["INDEX"].ToString();
                        GNINMB = myDBFDataReader["GNINMB"].ToString();
                        UNO = myDBFDataReader["UNO"].ToString();
                        OCATD = myDBFDataReader["OCATD"].ToString();
                        coderegion = CODE.Substring(0, 2);

                        regionsDBComands[coderegion].Parameters["NAME"].Value = NAME + (KORP == "" ? "" : " корпус " + KORP);
                        regionsDBComands[coderegion].Parameters["KORP"].Value = KORP;
                        regionsDBComands[coderegion].Parameters["SOCR"].Value = SOCR;
                        regionsDBComands[coderegion].Parameters["CODE"].Value = CODE;
                        regionsDBComands[coderegion].Parameters["POST_INDEX"].Value = POST_INDEX;
                        regionsDBComands[coderegion].Parameters["GNINMB"].Value = GNINMB;
                        regionsDBComands[coderegion].Parameters["UNO"].Value = UNO;
                        regionsDBComands[coderegion].Parameters["OCATD"].Value = OCATD;
                        regionsDBComands[coderegion].CommandText = "INSERT INTO KLADR (NAME, SOCR, CODE, POST_INDEX, GNINMB, UNO, OCATD, countSubItems) VALUES(:NAME, :SOCR, :CODE, :POST_INDEX, :GNINMB, :UNO, :OCATD, -1)";
                        if (stopedAcynhOperation)
                        {
                            regionsDBConnections.CloseAllConnections();
                            mySQLITEConnection.Close();
                            return;
                        }
                        regionsDBComands[coderegion].ExecuteNonQuery();
                    }
                    myDBFDataReader.Close();
                    #endregion

                    foreach (KeyValuePair<string, DbTransaction> t in regionsDBTransactions)
                    {
                        log(invokeForm, Language.Other.Indexing_sqlitq_database_to_region + t.Key + ")");
                        regionsDBComands[t.Key].CommandText = @"CREATE INDEX KLADR_full ON  KLADR (NAME, CODE, POST_INDEX, GNINMB, UNO, OCATD, STATUS);";
                        regionsDBComands[t.Key].ExecuteNonQuery();
                        //regionsDBComands[t.Key].CommandText = @"CREATE INDEX STREET_full ON  STREET (NAME, SOCR, CODE, POST_INDEX, GNINMB, UNO, OCATD);";
                        //regionsDBComands[t.Key].ExecuteNonQuery();
                        //regionsDBComands[t.Key].CommandText = @"CREATE INDEX DOMA_full ON  DOMA (NAME, KORP, SOCR, CODE, POST_INDEX, GNINMB, UNO, OCATD);";
                        //regionsDBComands[t.Key].ExecuteNonQuery();
                        t.Value.Commit();
                        regionsDBConnections[t.Key].Close();
                        invokeForm.FormClosing -= SafeCloseForm;
                    }
                    //log(invokeForm, "Committing transaction's...");
                    mySQLITETransaction.Commit();
                    mySQLITEConnection.Close();
                    log(invokeForm, Language.FormStart._status_label_text);
                    invokeForm.Invoke(new universalDelegate(delegate()
                    {
                        invokeForm.buttonClose.Enabled = true;
                        invokeForm.progressBarLoader.Style = ProgressBarStyle.Blocks;
                        invokeForm.progressBarLoader.Step = 1;
                        invokeForm.progressBarLoader.Maximum = 1;
                        invokeForm.progressBarLoader.Minimum = 0;
                        invokeForm.progressBarLoader.Value = 1;
                    }));
                });
            
            IAsyncResult result = load_DBFtoSQLiteDelegateObject.BeginInvoke(null, null);
            SafeCloseForm = new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
            {
                while (!result.IsCompleted) { stopedAcynhOperation = true;}
                try
                {
                    Directory.Delete(folderSQLITE, true);
                }
                catch
                {

                }
            });
            invokeForm.FormClosing += SafeCloseForm;
        }
    }
}