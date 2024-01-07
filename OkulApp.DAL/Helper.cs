using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OkulApp.DAL
{
    public class Helper:IDisposable
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;

        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (cn = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext, cn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                cn = new SqlConnection(cstr);
                cmd = new SqlCommand(cmdtext, cn);
                if (p != null)
                {
                    cmd.Parameters.AddRange(p);
                }
                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {

                throw new Exception("Veri Tabanı Hatası",ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Üzgünüz...Hatanın sebenini bulamadık", ex);
            }   
        }
        public void Dispose()
        {
            // SqlConnection ve SqlCommand nesnelerini temizle
            cn?.Dispose();
            cmd?.Dispose();
        }
    }

}
