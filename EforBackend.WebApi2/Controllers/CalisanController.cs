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
    public class CalisanController : Controller
    {
        private IIslerService _isService;
        public CalisanController()
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
        public JsonResult GorevDurumDegistir()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                Isler veri = JsonConvert.DeserializeObject<Isler>(json);

                string uyari = "";


                if (uyari == "")
                {
                    

                    bool ekle = _isService.GorevDurumuDegistir(veri.isId,veri.isYorum);

                    if (ekle )
                    {

                        JsonSonucModel gonder = new JsonSonucModel
                        {
                            DonenID = veri.isId,
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