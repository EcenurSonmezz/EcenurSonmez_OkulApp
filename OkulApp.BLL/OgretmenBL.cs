using OkulApp.DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        public bool OgretmenKaydet (Ogretmen ogretmen)
        { 
            var helper=new Helper();
            var param = new SqlParameter[]
                {
                    new SqlParameter("@Tc",ogretmen.Tc),
                    new SqlParameter("@Ad",ogretmen.Name),
                    new SqlParameter("@Soyad",ogretmen.Surname),
                    new SqlParameter("@BransKodu",ogretmen.BransKodu)
                };
            return helper.ExecuteNonQuery("Insert into Ogretmen Values (@Tc,@Ad,@Soyad,@BransKodu)", param) > 0;
        }

        
        public Ogretmen OgretmenBul(string Tc)
        {
            try
            {
                var hlp = new Helper();
                SqlParameter[] p = { new SqlParameter("@Tc", Tc) };
                var dr = hlp.ExecuteReader("Select Tc,Name,Surname,BransKodu from Ogretmen where Tc=@Tc", p);
                Ogretmen ogr = null;
                if (dr.Read())
                {
                    ogr = new Ogretmen();
                    ogr.Name = dr["Name"].ToString();
                    ogr.Surname = dr["Surname"].ToString();
                    ogr.BransKodu = dr["BransKodu"].ToString();
                    ogr.Tc =dr["Tc"].ToString();

                }
                dr.Close();
                return ogr;
            }

            catch (Exception ex)
            {

                throw new Exception("UYARI! Hata: " + ex.Message, ex);
            }


        }
        public bool OgretmenSil(String Tc)
        {
            try
            {
                var hlp = new Helper();
                var p = new SqlParameter[] {
                   new SqlParameter("@Tc", Tc)
                 };
                return hlp.ExecuteNonQuery("DELETE FROM Ogretmen WHERE Tc = @Tc", p) > 0;
            }

            catch (Exception ex)
            {
                throw new Exception("UYARI! Hata: " + ex.Message, ex);
            }
            finally
            {
            }
        }



        public bool OgretmenGuncelle(Ogretmen ogr)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@Name",ogr.Name),
            new SqlParameter("@Surname", ogr.Surname),
            new SqlParameter("@BransKodu",ogr.BransKodu),
            new SqlParameter("@Tc",ogr.Tc)};

                Helper hlp = new Helper();
                return hlp.ExecuteNonQuery("Update Ogretmen set Name=@Name,Surname=@Surname,BransKodu=@BransKodu where Tc=@Tc", p) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("UYARI! Hata: " + ex.Message, ex);
            }
        }
    }
}
