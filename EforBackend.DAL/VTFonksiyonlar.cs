using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.DAL
{
    public class VTFonksiyonlar
    {

        public static string ConString
        {
            get
            {
                return @"Data Source=.;Initial Catalog=IsTakipDB;User ID=sa;Password=1309634486";
            }
        }



        public static void ParametreYaz(SqlCommand command, SqlDbType tip, string ParametreAd, object ParametreDeger)
        {

            SqlParameter parameter = new SqlParameter(ParametreAd, tip);
            parameter.Value = (ParametreDeger == null ? DBNull.Value : ParametreDeger);
            command.Parameters.Add(parameter);
        }

        public static void ParametreYaz(SqlCommand command, SqlDbType tip, string ParametreAd, object ParametreDeger, string TypeName)
        {
            SqlParameter parameter = new SqlParameter(ParametreAd, tip);
            parameter.Value = (ParametreDeger == null ? DBNull.Value : ParametreDeger);
            parameter.TypeName = TypeName;
            command.Parameters.Add(parameter);
        }

        public static void CommandOzellikler(SqlCommand command, SqlConnection myConnection, CommandType tip, string commandText)
        {
            command.CommandTimeout = 3600000;
            command.Connection = myConnection;
            command.CommandType = tip;
            command.CommandText = commandText;
        }

        public static int VeriGetir_Int(SqlDataReader reader, string KolonAdi)
        {
            return reader[KolonAdi] is DBNull ? 0 : (int)reader[KolonAdi];
        }

        public static decimal VeriGetir_Decimal(SqlDataReader reader, string KolonAdi)
        {
            return reader[KolonAdi] is DBNull ? 0 : (decimal)reader[KolonAdi];
        }

        public static string VeriGetir_String(SqlDataReader reader, string KolonAdi)
        {
            return reader[KolonAdi] is DBNull ? string.Empty : reader[KolonAdi].ToString();
        }

        public static DateTime VeriGetir_DateTime(SqlDataReader reader, string KolonAdi)
        {
            return reader[KolonAdi] is DBNull ? new DateTime(1900, 1, 1) : (DateTime)reader[KolonAdi];
        }

        public static bool VeriGetir_Bool(SqlDataReader reader, string KolonAdi)
        {
            return reader[KolonAdi] is DBNull ? false : (bool)reader[KolonAdi];
        }
    }
}
