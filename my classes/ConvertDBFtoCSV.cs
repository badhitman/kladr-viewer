using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace KLADR_viewer_v4.my_classes
{
    class ConvertDBFtoCSV
    {
        #region variables
        private delegate void ConvertDelegate(FormKLADRtoCSV invokeForm);
        ConvertDelegate ConvertDelegateObject;

        private OleDbConnection myDBFConnection;
        private OleDbCommand myDBFCommand;
        private OleDbDataReader myDBFDataReader;

        private List<string> columnsOfDBF;
        private string columnsOfDBFasString;

        string directoryFile;
        string fileName;

        FormKLADRtoCSV ownerForm;
        #endregion

        public ConvertDBFtoCSV(string filePatch, FormKLADRtoCSV ownerForm)
        {
            this.ownerForm = ownerForm;

            directoryFile = Path.GetDirectoryName(filePatch);
            fileName = Path.GetFileNameWithoutExtension(filePatch);
            columnsOfDBF = new List<string>();
            columnsOfDBFasString = "";
            try
            {
                myDBFConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directoryFile + "\\;Extended Properties=DBASE IV;Persist Security Info=False;");
                myDBFCommand = myDBFConnection.CreateCommand();
                myDBFConnection.Open();
                myDBFCommand.CommandText = "SELECT TOP 1 * FROM " + fileName;
                myDBFDataReader = myDBFCommand.ExecuteReader();
                myDBFDataReader.Read();
                for (int i = 0; i < myDBFDataReader.FieldCount; i++)
                {
                    columnsOfDBF.Add(myDBFDataReader.GetName(i));
                    columnsOfDBFasString += "," + myDBFDataReader.GetName(i);
                }
                myDBFDataReader.Close();
                columnsOfDBFasString = " " + columnsOfDBFasString.Substring(1) + " ";
            }
            catch (Exception e)
            {
                MessageBox.Show("could not connect to '" + directoryFile + "' database.\n" + e.Message);
                ownerForm.Close();
            }
        }

        public void StartConvert()
        {
            ConvertDelegateObject = new ConvertDelegate(delegate(FormKLADRtoCSV ownerForm)
            {
                int totalCountRows = 0;
                if (myDBFConnection.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("database has not yet been opened");
                    return;
                }
                string importedNewFileName = directoryFile + "\\" + fileName;
                if (File.Exists(importedNewFileName + ".csv"))
                {
                    for (int i = 1; i < 100000; i++)
                    {
                        if (!File.Exists(importedNewFileName + "_" + i.ToString() + ".csv"))
                        {
                            importedNewFileName = importedNewFileName + "_" + i.ToString();
                            break;
                        }
                    }
                }
                StreamWriter outfile = new StreamWriter(importedNewFileName + ".csv", false, Encoding.UTF8);
                outfile.WriteLine("\"" + columnsOfDBFasString.Trim().Replace(",", "\";\"") + "\"");
                myDBFCommand.CommandText = "SELECT * FROM " + fileName;
                myDBFDataReader = myDBFCommand.ExecuteReader();
                string buferString = "";
                int flagCountBufer = 0;
                while (myDBFDataReader.Read())
                {
                    string stringIntoOutFile = "";
                    for (int i = 0; i < myDBFDataReader.FieldCount; i++)
                    {
                        stringIntoOutFile += "\";\"" + myDBFDataReader[i].ToString().Replace("\"", "\"\"");
                    }
                    stringIntoOutFile = stringIntoOutFile.Substring(2) + "\"";
                    flagCountBufer++;
                    totalCountRows++;

                    if (flagCountBufer >= 100)
                    {
                        flagCountBufer = 0;
                        outfile.WriteLine(buferString.Trim());
                        buferString = "";
                        this.ownerForm.toolStripStatusLabelImportKLADRtoCSV.Text = "Imports of " + totalCountRows.ToString() + " rows";
                    }
                    else
                    {
                        buferString += System.Environment.NewLine + stringIntoOutFile;
                    }
                }
                if (buferString.Trim() != "")
                {
                    this.ownerForm.toolStripStatusLabelImportKLADRtoCSV.Text = "Imports of " + totalCountRows.ToString() + " rows";
                    outfile.WriteLine(buferString.Trim());
                }

                myDBFDataReader.Close();
                outfile.Close();
                MessageBox.Show("import was successful ");

                this.ownerForm.notCloseForm = false;
                this.ownerForm.Invoke(new ConvertDelegate(delegate(FormKLADRtoCSV ownerForm2) { ownerForm2.Close(); }), new object[] { this.ownerForm });
            });
            ConvertDelegateObject.BeginInvoke(this.ownerForm, null, null);
        }
    }
}
