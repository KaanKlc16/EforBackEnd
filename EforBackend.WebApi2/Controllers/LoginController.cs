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
    public class LoginController : Controller
    {
        private ILoginService _loginService;
         
        public LoginController()
        {
            _loginService = new LoginService();
        }

        [HttpGet]
        public JsonResult YoneticininPersonelleriGetir(int PersonelId) 
        {
            List<Personeller> veriler = _loginService.YoneticininPersonelleriniGetir(PersonelId);
            return Json(veriler, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult KullaniciGiris()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                LoginModel veri = JsonConvert.DeserializeObject<LoginModel>(json);

                JsonSonucModel getir = _loginService.LoginOl(veri.KullaniciAd, veri.Parola);



                Personeller personel = new Personeller();
                if (getir.Sonuc)
                {
                    personel = _loginService.PersonelIdyeGoreGetir(getir.DonenID);
                }
                KullaniciGirisResult sonuc = new KullaniciGirisResult
                {
                    Sonuc = getir,
                    Personel = personel,
                    Url = getir.Sonuc ? (personel.personelYetkiTurId == 1 ? "Yonetici/Index" : "Calisan/Index") : ""
                };
                return Json(sonuc, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                KullaniciGirisResult gonder = new KullaniciGirisResult
                {
                    Personel = new Personeller(),
                    Sonuc = new JsonSonucModel { DonenID = 0, Sonuc = false, SonucAciklama = ex.Message },
                    Url = ""
                };
                return Json(gonder, JsonRequestBehavior.AllowGet);
            }
        }
    }
}