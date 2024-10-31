using EforBackend.BLL.Abstract;
using EforBackend.BLL.Concrete;
using EforBackend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EforBackend.WebApi2.Controllers
{
    public class YoneticiController : Controller
    {
        private IIslerService _isService;
        public YoneticiController()
        {
            _isService = new IslerService();
        }
        [HttpGet]
        public JsonResult CalisanIsleriniGetir(int PersonelId)
        {
            List<Isler> veriler = _isService.CalisanIsleriniGetir(PersonelId);
            return Json(veriler, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsEkle()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                Isler veri = JsonConvert.DeserializeObject<Isler>(json);

                string uyari = "";

                if (veri.isPersonelId == 0)
                {
                    uyari += "Personel girilmedi !..";
                }
                //KAANSENDE


                if (uyari == "")
                {
                    Isler yeniEklenen = new Isler 
                    {
                        isDurumId = 0,
                        iletilenTarih = DateTime.Now,
                        isBaslik = veri.isBaslik,
                        isBaslangic = veri.isBaslangic,
                        isAciklama = veri.isAciklama,
                        isBitirmeSure = veri.isBitirmeSure,
                        isId = 0,
                        isOkunma = false,
                        isPersonelId = veri.isPersonelId,
                        isYorum = veri.isYorum,
                        tahminiSure = veri.tahminiSure,
                        yapilanTarih = new DateTime(2000,1,1)
                    };

                    int ekleId = _isService.IsEkle(yeniEklenen);
                    if (ekleId > 0)
                    {

                        JsonSonucModel gonder = new JsonSonucModel
                        {
                            DonenID = ekleId,
                            Sonuc = true,
                            SonucAciklama = "Görev eklendi !.."
                        };
                        return Json(gonder, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        JsonSonucModel gonder = new JsonSonucModel
                        {
                            DonenID = 0,
                            Sonuc = false,
                            SonucAciklama = uyari
                        };
                        return Json(gonder, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    JsonSonucModel gonder = new JsonSonucModel
                    {
                        DonenID = 0,
                        Sonuc = false,
                        SonucAciklama = uyari
                    };
                    return Json(gonder, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                JsonSonucModel gonder = new JsonSonucModel
                {
                    DonenID = 0,
                    Sonuc = false,
                    SonucAciklama = ex.Message
                };
                return Json(gonder, JsonRequestBehavior.AllowGet);
            }


        }
    }
}