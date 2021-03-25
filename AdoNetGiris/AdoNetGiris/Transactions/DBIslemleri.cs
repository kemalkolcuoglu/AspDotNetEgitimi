using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdoNetGiris.Models;
using System.Data;

namespace AdoNetGiris.Transactions
{
    public class DBIslemleri
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder;
        private SqlConnection con;
        public DBIslemleri()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = "Server=myServerAddress;Database=AdoNetGiris;Trusted_Connection=True;";
            con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public int ExecuteCommand(SqlCommand cmd)
        {
            int result = 0;
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }

        public SqlDataReader ExecuteCommandDR(SqlCommand cmd)
        {
            SqlDataReader dr = null;
            try
            {
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return dr;
        }

        public List<Kitap> VeriGetirDR()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From Kitap", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Kitap> kitaplar = new List<Kitap>();
                while (dr.Read())
                {
                    Kitap kitap = new Kitap
                    {
                        Ad = dr["Ad"].ToString(),
                        Fiyat = Convert.ToDecimal(dr["Fiyat"].ToString()),
                        Tur = dr["Tur"].ToString(),
                        Yazar = Convert.ToInt32(dr["Yazar"].ToString())
                    };
                    kitaplar.Add(kitap);
                }
                con.Close();
                return kitaplar;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable VeriGetirDA()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kitap", con);
            DataTable dt = new DataTable();
            int result = da.Fill(dt);
            return dt;
        }

        public int VeriEkle(Kitap kitap)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert Into Kitap Values(@Ad, @Tur, @Fiyat, @Yazar)";

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@Ad", kitap.Ad);
            sqlParameters[1] = new SqlParameter("@Tur", kitap.Tur);
            sqlParameters[2] = new SqlParameter("@Fiyat", kitap.Fiyat);
            sqlParameters[3] = new SqlParameter("@Yazar", kitap.Yazar);

            cmd.Parameters.AddRange(sqlParameters);

            int result = ExecuteCommand(cmd);
            return result;
        }

        public int VeriGuncelle(string column, string value, int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update Kitap Set @Column = @Value Where ID = @ID";

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Column", column);
            sqlParameters[1] = new SqlParameter("@Value", value);
            sqlParameters[2] = new SqlParameter("@ID", id);

            cmd.Parameters.AddRange(sqlParameters);

            int result = ExecuteCommand(cmd);
            return result;
        }

        public int VeriSil(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete From Kitap Where ID = @ID";

            SqlParameter param = new SqlParameter("@ID", id);

            cmd.Parameters.Add(param);

            int result = ExecuteCommand(cmd);
            return result;
        }
    }
}
