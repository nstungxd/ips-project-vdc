using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitSettingLibrary
{
    public class Common
    {
        public static string ConvertTableToJsonString(DataTable table)
        {
            if (table == null || table.Rows.Count == 0) return "";
            var headStrBuilder = new StringBuilder(table.Columns.Count * 5); //pre-allocate some space, default is 16 bytes
            for (int i = 0; i < table.Columns.Count; i++)
            {
                headStrBuilder.AppendFormat("\"{0}\" : \"{0}{1}¾\",", table.Columns[i].Caption, i);
            }
            headStrBuilder.Remove(headStrBuilder.Length - 1, 1); // trim away last ,

            var sb = new StringBuilder(table.Rows.Count * 5); //pre-allocate some space            
            sb.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tempStr = headStrBuilder.ToString();
                sb.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    var tg = "";
                    if (!table.Rows[i].IsNull(j))
                        tg = table.Rows[i][j].ToString().Replace("'", "");
                    tempStr = tempStr.Replace(table.Columns[j] + j.ToString(CultureInfo.InvariantCulture) + "¾", tg);
                }
                sb.Append(tempStr + "},");
            }
            sb.Remove(sb.Length - 1, 1); // trim last ,           
            sb.Append("]");
            return sb.ToString();
        }

        public static Dictionary<int,string> ToanTuSoSanh()
        {
            var list = new Dictionary<int,string>();
            list.Add(-1,"--Chon gia tri--");
            list.Add(0,">");
            list.Add(1,"<");
            list.Add(2,"=");
            return list;
        }
    }
}
