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
            name = reader["name"].ToString();

            try
            {
                korp = reader["korp"].ToString();
            }
            catch
            { }
            socr = reader["socr"].ToString();
            post_index = reader["post_index"].ToString();
            code = reader["code"].ToString();
            gninmb = reader["gninmb"].ToString();
            uno = reader["uno"].ToString();
            ocatd = reader["ocatd"].ToString();
            typeObj = reader["typeObj"].ToString();
            try
            {
                status = reader["status"].ToString();
            }
            catch
            { }
        }
    }
}
