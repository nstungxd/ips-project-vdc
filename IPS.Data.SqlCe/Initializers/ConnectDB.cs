using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using UnitSettingLibrary;
using System.Threading.Tasks;

namespace IPS.Data.SqlCe.Initializers
{
    public class ConnectDB
    {       
        private const string OradbDt = "Data Source=123.30.171.20:1521/ORA;User ID=tqldt;Password=qldt123";
        //private const string OradbGs = "Data Source=TUNGNS-PC:1521/ORCL;User ID=dev_gs;Password=dev_gs";
        private const string OradbGs = "Data Source=TUNGNS-PC:1521/ORCL;User ID=dev_gs;Password=dev_gs";

        public static OracleConnection GetOracleConnection(OracleConnection connect, NameDatabase dbName = NameDatabase.GiamSat)
        {
            try
            {
                connect.ConnectionString = dbName == NameDatabase.DauTu ? OradbDt : OradbGs;
                connect.Open();
                return connect;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void CloseConnection(OracleConnection connect)
        {
            if (connect == null) return;
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
            connect.Dispose();
        } 
    }
}
