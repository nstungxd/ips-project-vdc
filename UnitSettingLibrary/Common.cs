using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

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

        public static List<string> ToanTuSoSanh()
        {
            var list = new List<string>();
            list.Add(">");
            list.Add("<");
            list.Add("=");
            return list;
        }

        /// <summary>
        /// lay danh sach cac nam de load dropdownlist
        /// </summary>
        /// <param name="namBatDau">nam bat dau</param>
        /// <param name="namKetThuc">nam ket thuc</param>
        /// <returns></returns>
        public static List<int> DanhSachNam(int namBatDau,int namKetThuc)
        {
            if (namKetThuc < namBatDau) return null;
            var list = new List<int>();
            for (int i = namBatDau; i <= namKetThuc; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public static string Md5Encrypte(string inputString)
        {
            var u = new System.Text.UTF32Encoding();
            byte[] bytes = u.GetBytes(inputString); 
            System.Security.Cryptography.MD5 md = new System.Security.Cryptography.MD5CryptoServiceProvider();
          
            byte[] result = md.ComputeHash(bytes);
            return Convert.ToBase64String(result);
        }
    }    
}
