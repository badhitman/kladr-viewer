using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLADR_viewer_v4.management
{
    class DictionaryConnections : Dictionary<string, Community.CsharpSqlite.SQLiteClient.SqliteConnection>
    {
        public void CloseAllConnections()
        {
            foreach (KeyValuePair<string, Community.CsharpSqlite.SQLiteClient.SqliteConnection> t in this)
            {
                if (t.Value.State != System.Data.ConnectionState.Closed)
                    t.Value.Close();
            }
        }
    }
}
