#define MySQL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

#if MSSQL
// MSSQL kodları
#elif MySQL
using MDbConnection = MySql.Data.MySqlClient.MySqlConnection;
using MDbConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;
using MDbCommand = MySql.Data.MySqlClient.MySqlCommand;
using MDbDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using MDbDataAdapter = MySql.Data.MySqlClient.MySqlDataAdapter;
#elif ACCESS
// ACCESS kodları
#endif


namespace acilcagrimerkeziveritabanıDL
{
    public static class DL
    {
        static MDbConnection baglanti = new MDbConnection(
             new MDbConnectionStringBuilder()
             {
#if MySQL
                 Server = "localhost", // gerçek durumda server ip'si
                 Database = "acilcagrimerkezi",
                 UserID = "root",
                 Password = "Omurcan14&",
#elif MSSQL
                
#elif ACCESS
#endif
             }.ConnectionString);
        public static int cagriekle(string cagriid, DateTime saattarih, string adı, string soyadı, string telefon, string adres, string birim, string olay)
        {
            try
            {
                if (baglanti.State != System.Data.ConnectionState.Open)
                    baglanti.Open();

                MDbCommand komut = new MDbCommand("cagriekle", baglanti) { CommandType = System.Data.CommandType.StoredProcedure };
                komut.Parameters.AddWithValue("@cagriid", cagriid);
                komut.Parameters.AddWithValue("@saattarih", saattarih);
                komut.Parameters.AddWithValue("@adi", adı);
                komut.Parameters.AddWithValue("@soyadi", soyadı);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@birim", birim);
                komut.Parameters.AddWithValue("@olay", olay);

                error = "";
                return komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
            finally
            {
                if (baglanti.State != System.Data.ConnectionState.Closed)
                    baglanti.Close();
            }
        }
        public static int cagriduzenle(string cagriid, DateTime saattarih, string adı, string soyadı, string telefon, string adres, string birim, string olay)
        {
                try
                {
                    if (baglanti.State != System.Data.ConnectionState.Open)
                        baglanti.Open();

                    MDbCommand komut = new MDbCommand("cagriduzenle", baglanti) { CommandType = System.Data.CommandType.StoredProcedure };
                    komut.Parameters.AddWithValue("@cagriid", cagriid);
                    komut.Parameters.AddWithValue("@saattarih", saattarih);
                    komut.Parameters.AddWithValue("@adi", adı);
                    komut.Parameters.AddWithValue("@soyadi", soyadı);
                    komut.Parameters.AddWithValue("@telefon", telefon);
                    komut.Parameters.AddWithValue("@adres", adres);
                    komut.Parameters.AddWithValue("@birim", birim);
                    komut.Parameters.AddWithValue("@olay", olay);

                    error = "";
                    return komut.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return -1;
                }
                finally
                {
                    if (baglanti.State != System.Data.ConnectionState.Closed)
                        baglanti.Close();
                }
        }
        public static int cagrisil(string cagriid)
        {
                try
                {
                    if (baglanti.State != System.Data.ConnectionState.Open)
                        baglanti.Open();

                    MDbCommand komut = new MDbCommand("cagrisil", baglanti) { CommandType = System.Data.CommandType.StoredProcedure };
                    komut.Parameters.AddWithValue("@cagriid", cagriid);

                    error = "";
                    return komut.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return -1;
                }
                finally
                {
                    if (baglanti.State != System.Data.ConnectionState.Closed)
                        baglanti.Close();
                }
        }
        public static List<(string cagriid, DateTime saattarih, string adı, string soyadı, string telefon, string adres , string birim,string olay
            )> tumcagriler(out string error)
        {
            List<(string, DateTime, string, string, string, string, string, string)> list = new List<(string, DateTime, string, string, string, string, string, string)>();
            try
            {
                if (baglanti.State != System.Data.ConnectionState.Open)
                    baglanti.Open();

                MDbCommand komut = new MDbCommand("tumcagriler", baglanti) { CommandType = System.Data.CommandType.StoredProcedure };
                MDbDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString(),
                        dr[7].ToString()
                            );
                }
                error = "";
                return list;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            finally
            {
                if (baglanti.State != System.Data.ConnectionState.Closed)
                    baglanti.Close();
            }
        }

    }
}
