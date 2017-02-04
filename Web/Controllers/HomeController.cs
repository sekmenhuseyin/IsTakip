using Core.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Classes;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IElemanRepository<Eleman> _ElemanRepository;

        public HomeController(IElemanRepository<Eleman> ElemanRepository)
        {
            _ElemanRepository = ElemanRepository;
        }

        public ActionResult Index()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            return View();
        }

        public ActionResult Profil()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var ProfilSahibi = _ElemanRepository.BulveGetir(Session["YoneticiUrl"].ToString());
            if (ProfilSahibi == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var ViewModel = new ProfilViewModel()
            {
                Eleman = ProfilSahibi
            };
            return View(ViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Profil(ProfilViewModel ViewModel, HttpPostedFileBase AvatarGorsel)
        {
            var PersonelBul = _ElemanRepository.BulveGetir(ViewModel.Eleman.Url);
            if (PersonelBul == null)
            {
                return RedirectToAction("Profil", "Personel");
            }

            var adsoyad = ViewModel.Eleman.Ad + " " + ViewModel.Eleman.Soyad;

            UrlManager.UrlReplace url = new UrlManager.UrlReplace(adsoyad);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != ViewModel.Eleman.Url)
            {
                ViewModel.Eleman.Url = YeniUrl;
            }

            ViewModel.Eleman.KayitTarihi = PersonelBul.KayitTarihi;

            if (ViewModel.Eleman.AvatarResim != null && ViewModel.Eleman.AvatarResimIsmi != null && ViewModel.Eleman.AvatarResimTipi != null)
            {
                ViewModel.Eleman.AvatarResim = ViewModel.Eleman.AvatarResim;
                ViewModel.Eleman.AvatarResimIsmi = ViewModel.Eleman.AvatarResimIsmi;
                ViewModel.Eleman.AvatarResimTipi = ViewModel.Eleman.AvatarResimTipi;
            }

            if (AvatarGorsel != null && AvatarGorsel.ContentLength > 0)
            {
                ViewModel.Eleman.AvatarResimIsmi = Path.GetFileName(AvatarGorsel.FileName);
                ViewModel.Eleman.AvatarResimTipi = AvatarGorsel.ContentType;

                using (var reader = new BinaryReader(AvatarGorsel.InputStream))
                {
                    ViewModel.Eleman.AvatarResim = reader.ReadBytes(AvatarGorsel.ContentLength);
                }
            }
            var guncelleme = _ElemanRepository.Guncelle(ViewModel.Eleman);

            Session["YoneticiUrl"] = ViewModel.Eleman.Url;

            return RedirectToAction("Profil", "Home");
        }

        public ActionResult AvatarGorselKaldir()
        {
            var Personel = _ElemanRepository.BulveGetir(Session["YoneticiUrl"].ToString());

            if (Personel == null)
            {
                return RedirectToAction("Index", "Personel");
            }

            Personel.AvatarResim = null;
            Personel.AvatarResimIsmi = null;
            Personel.AvatarResimTipi = null;

            _ElemanRepository.Guncelle(Personel);

            return RedirectToAction("Profil", "Home");
        }
    }
}