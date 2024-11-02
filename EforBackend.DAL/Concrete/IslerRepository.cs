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
    public class IslerRepository : IIslerRepository
    {
        public List<Isler> CalisanIsleriniGetir(int PersonelId)
        {
            List<Isler> tumListesi = new List<Isler>();
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "select * from Isler i where i.isPersonelId = @PersonelId order by iletilenTarih desc");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@PersonelId", PersonelId);
                    myConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Isler ekle = new Isler
                            {
                                isId = reader["isId"] is DBNull ? 0 : (int)reader["isId"],
                                isBaslik = reader["isBaslik"] is DBNull ? string.Empty : (string)reader["isBaslik"],
                                isAciklama = reader["isAciklama"] is DBNull ? string.Empty : (string)reader["isAciklama"],
                                isPersonelId = reader["isPersonelId"] is DBNull ? 0 : (int)reader["isPersonelId"],
                                iletilenTarih = reader["iletilenTarih"] is DBNull ? new DateTime(2000, 1, 1) : (DateTime)reader["iletilenTarih"],
                                yapilanTarih = reader["yapilanTarih"] is DBNull ? new DateTime(2000, 1, 1) : (DateTime)reader["yapilanTarih"],
                                isDurumId = reader["isDurumId"] is DBNull ? 0 : (int)reader["isDurumId"],
                                isYorum = reader["isYorum"] is DBNull ? string.Empty : (string)reader["isYorum"],
                                tahminiSure = reader["tahminiSure"] is DBNull ? 0 : (int)reader["tahminiSure"],
                                isOkunma = reader["isOkunma"] is DBNull ? false : (bool)reader["isOkunma"],
                                isBaslangic = reader["isBaslangic"] is DBNull ? new DateTime(2000, 1, 1) : (DateTime)reader["isBaslangic"],
                                isBitirmeSure = reader["isBitirmeSure"] is DBNull ? new DateTime(2000, 1, 1) : (DateTime)reader["isBitirmeSure"],
                            };
                            tumListesi.Add(ekle);
                        }
                        myConnection.Close();
                    }
                }
            }
            return tumListesi;
        }


        public int IsEkle(Isler m) 
        {
            int eklenenId = 0;
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "INSERT INTO Isler(isBaslik,isAciklama,isPersonelId,iletilenTarih,yapilanTarih,isDurumId,isYorum,tahminiSure,isOkunma,isBaslangic,isBitirmeSure) VALUES (@isBaslik,@isAciklama,@isPersonelId,@iletilenTarih,@yapilanTarih,@isDurumId,@isYorum,@tahminiSure,@isOkunma,@isBaslangic,@isBitirmeSure);SELECT SCOPE_IDENTITY()");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@isBaslik", m.isBaslik);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@isAciklama", m.isAciklama);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@isPersonelId", m.isPersonelId);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.DateTime, "@iletilenTarih", m.iletilenTarih);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.DateTime, "@yapilanTarih", m.yapilanTarih);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@isDurumId", m.isDurumId);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@isYorum", m.isYorum);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@tahminiSure", m.tahminiSure);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Bit, "@isOkunma", m.isOkunma);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.DateTime, "@isBaslangic", m.isBaslangic);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.DateTime, "@isBitirmeSure", m.isBitirmeSure);
                    myConnection.Open();
                    try { eklenenId = Convert.ToInt32(command.ExecuteScalar()); }
                    catch
                    { eklenenId = 0; }
                    if (eklenenId < 0) { eklenenId = 0; }
                    myConnection.Close();
                }
            }
            return eklenenId;
        }
        public bool GorevDurumuDegistir(int IsId, string IsYorum) {
            bool tamam = false;
            using (SqlConnection myConnection = new SqlConnection(VTFonksiyonlar.ConString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    VTFonksiyonlar.CommandOzellikler(command, myConnection, CommandType.Text, "UPDATE Isler SET isDurumId=@isDurumId,isYorum=@isYorum,isBitirmeSure=@isBitirmeSure WHERE isId=@isId");
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@isId", IsId);
                   
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.Int, "@isDurumId", 2);
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.VarChar, "@isYorum", IsYorum);
                   
                   
                    VTFonksiyonlar.ParametreYaz(command, SqlDbType.DateTime, "@isBitirmeSure", DateTime.Now);

                   
                    myConnection.Open();
                    int islem = command.ExecuteNonQuery();
                    if (islem > 0) { tamam = true; } else { tamam = false; }
                    myConnection.Close();
                }
            }
            return tamam;



        }
    }
}
