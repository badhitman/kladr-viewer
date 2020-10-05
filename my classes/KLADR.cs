using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KLADR_viewer_v4
{
    public class KLADR
    {
        public string name;
        public string korp;
        public string socr;
        public string post_index;
        public string code;
        public string gninmb;
        public string uno;
        public string ocatd;
        public string status;
        public string typeObj;
        public bool existSubElements;

        public Color getColorObjectKladr()
        {
            Color currBColor;
            switch (typeObj)
            {
                case "cyty":
                    currBColor = Color.Linen;
                    break;
                case "smallcity":
                    currBColor = Color.Silver;
                    break;
                case "area":
                    currBColor = Color.LightGray;
                    break;
                case "street":
                    currBColor = Color.Snow;
                    break;
                default:
                    currBColor = Color.Snow;
                    break;
            }
            return currBColor;
        }

        public KLADR(string name, string socr, string post_index, string code, string gninmb, string uno, string ocatd, string status = null, string korp = null, string typeObj = null, bool existSubElements = true)
        {
            this.name = name;
            this.korp = korp;
            this.socr = socr;
            this.post_index = post_index;
            this.code = code;
            this.gninmb = gninmb;
            this.uno = uno;
            this.ocatd = ocatd;
            this.status = status;
            this.typeObj = typeObj;
            this.existSubElements = existSubElements;
        }

        public KLADR(Community.CsharpSqlite.SQLiteClient.SqliteDataReader reader)
        {
            this.name = reader["name"].ToString();
            
            try
            {
                this.korp = reader["korp"].ToString();
            }
            catch
            { }
            this.socr = reader["socr"].ToString();
            this.post_index = reader["post_index"].ToString();
            this.code = reader["code"].ToString();
            this.gninmb = reader["gninmb"].ToString();
            this.uno = reader["uno"].ToString();
            this.ocatd = reader["ocatd"].ToString();
            this.typeObj = reader["typeObj"].ToString();
            try
            {
                this.status = reader["status"].ToString();
            }
            catch
            { }
            //try
            //{
            //    this.existSubElements = reader["existSubElements"].ToString().ToLower() == "0" ? false : true;
            //}
            //catch
            //{
            //    int i = 0;
            //}
        }
    }
}
