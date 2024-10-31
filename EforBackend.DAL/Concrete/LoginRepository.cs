using EforBackend.DAL.Abstract;
using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.DAL.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        public JsonSonucModel LoginOl(string KullaniciAd, string Parola)
        {
            //""
            Personeller personel = new Personeller();
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "select * from Personeller where personelKullaniciAd=@KullaniciAd and personelParola=@Parola");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@KullaniciAd", KullaniciAd);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@Parola", Parola);
                    myConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personeller ekle = new Personeller
                            {
                                personelId = reader["personelId"] is DBNull ? 0 : (int)reader["personelId"],
                                personelAdSoyad = reader["personelAdSoyad"] is DBNull ? string.Empty : (string)reader["personelAdSoyad"],
                                personelKullaniciAd = reader["personelKullaniciAd"] is DBNull ? string.Empty : (string)reader["personelKullaniciAd"],
                                personelParola = reader["personelParola"] is DBNull ? string.Empty : (string)reader["personelParola"],
                                personlBirimId = reader["personlBirimId"] is DBNull ? 0 : (int)reader["personlBirimId"],
                                personelYetkiTurId = reader["personelYetkiTurId"] is DBNull ? 0 : (int)reader["personelYetkiTurId"],
                            };
                            personel = ekle;
                        }
                        myConnection.Close();
                    }
                }
            }

            if (personel.personelId > 0)
            {
                return new JsonSonucModel { Sonuc = true, SonucAciklama = "Giriş yapıldı", DonenID = personel.personelId };
            }
            else
            {
                return new JsonSonucModel { Sonuc = false, SonucAciklama = "Kullanıcı bulunamadı !..", DonenID = 0 };
            }
        }

        public Personeller PersonelIdyeGoreGetir(int PersonelId) 
        {
            Personeller tumListesi = new Personeller();
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "SELECT * FROM Personeller WHERE personelId=@personelId");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@personelId", PersonelId);
                    myConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personeller ekle = new Personeller
                            {
                                personelId = reader["personelId"] is DBNull ? 0 : (int)reader["personelId"],
                                personelAdSoyad = reader["personelAdSoyad"] is DBNull ? string.Empty : (string)reader["personelAdSoyad"],
                                personelKullaniciAd = reader["personelKullaniciAd"] is DBNull ? string.Empty : (string)reader["personelKullaniciAd"],
                                personelParola = reader["personelParola"] is DBNull ? string.Empty : (string)reader["personelParola"],
                                personlBirimId = reader["personlBirimId"] is DBNull ? 0 : (int)reader["personlBirimId"],
                                personelYetkiTurId = reader["personelYetkiTurId"] is DBNull ? 0 : (int)reader["personelYetkiTurId"],
                            };
                            tumListesi = ekle;
                        }
                        myConnection.Close();
                    }
                }
            }
            return tumListesi;
        }

        public List<Personeller> YoneticininPersonelleriniGetir(int PersonelId) 
        {
            List<Personeller> tumListesi = new List<Personeller>();
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "select * from Personeller p where p.personelYetkiTurId = 2 and p.personlBirimId in (select personlBirimId from Personeller where personelId = @PersonelId) order by personelAdSoyad asc");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@PersonelId", PersonelId);
                    myConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personeller ekle = new Personeller
                            {
                                personelId = reader["personelId"] is DBNull ? 0 : (int)reader["personelId"],
                                personelAdSoyad = reader["personelAdSoyad"] is DBNull ? string.Empty : (string)reader["personelAdSoyad"],
                                personelKullaniciAd = reader["personelKullaniciAd"] is DBNull ? string.Empty : (string)reader["personelKullaniciAd"],
                                personelParola = reader["personelParola"] is DBNull ? string.Empty : (string)reader["personelParola"],
                                personlBirimId = reader["personlBirimId"] is DBNull ? 0 : (int)reader["personlBirimId"],
                                personelYetkiTurId = reader["personelYetkiTurId"] is DBNull ? 0 : (int)reader["personelYetkiTurId"],
                            };
                            tumListesi.Add(ekle);
                        }
                        myConnection.Close();
                    }
                }
            }
            return tumListesi;
        }
    }
}
