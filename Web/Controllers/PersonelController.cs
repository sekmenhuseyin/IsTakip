using Core.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Web.Classes;
using System.Collections;
using Data.Enums;

namespace Web.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IElemanRepository<Eleman> _ElemanRepository;
        private readonly IDepartmanRepository<Departman> _DepartmanRepository;
        private readonly IRolRepository<Rol> _RolRepository;

        public PersonelController(IElemanRepository<Eleman> ElemanRepository, IDepartmanRepository<Departman> DepartmanRepository, IRolRepository<Rol> RolRepository)
        {
            _ElemanRepository = ElemanRepository;
            _DepartmanRepository = DepartmanRepository;
            _RolRepository = RolRepository;
        }

        public ActionResult Index()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var GirenKullanici = _ElemanRepository.BulveGetir(Session["YoneticiUrl"].ToString());
            if (GirenKullanici == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            List<Eleman> PersonelListesi;
            if (GirenKullanici.RolId == 1 || GirenKullanici.RolId == 2)
            {
                PersonelListesi = _ElemanRepository.TumunuGetir().ToList();
            }
            else if (GirenKullanici.RolId == 3)
            {
                PersonelListesi = _ElemanRepository.DepartmanaGoreGetir(GirenKullanici.Departman.Url).ToList();
            }
            else
            {
                return RedirectToAction("Cikis", "Giris");
            }

            return View(PersonelListesi);
        }

        public ActionResult PersonelEkle()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var DepartmanListesi = _DepartmanRepository.TumunuGetir().ToList();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var RolListesi = _RolRepository.TumunuGetir().ToList();
            if (RolListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var PersonelViewModel = new PersonelViewModel
            {
                Departmanlar = DepartmanListesi,
                Roller = RolListesi
            };
            return View(PersonelViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PersonelEkle(Eleman Personel, HttpPostedFileBase AvatarGorsel)
        {
            var adsoyad = Personel.Ad + " " + Personel.Soyad;

            UrlManager.UrlReplace url = new UrlManager.UrlReplace(adsoyad);
            Personel.Url = url.Replace.ToString();

            Personel.KayitTarihi = DateTime.Now;
            Personel.KullanilanToplamIzın = 0;
            if (AvatarGorsel != null && AvatarGorsel.ContentLength > 0)
            {
                Personel.AvatarResimIsmi = Path.GetFileName(AvatarGorsel.FileName);
                Personel.AvatarResimTipi = AvatarGorsel.ContentType;

                using (var reader = new BinaryReader(AvatarGorsel.InputStream))
                {
                    Personel.AvatarResim = reader.ReadBytes(AvatarGorsel.ContentLength);
                }
            }

            var ekleme = _ElemanRepository.Ekle(Personel);

            return RedirectToAction("Index", "Personel");
        }

        public ActionResult PersonelGuncelle(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return View("Index", "Personel");
            }

            var DepartmanListesi = _DepartmanRepository.TumunuGetir().ToList();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var RolListesi = _RolRepository.TumunuGetir().ToList();
            if (RolListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var PersonelBul = _ElemanRepository.BulveGetir(url);
            if (PersonelBul == null)
            {
                return View("Index", "Personel");
            }

            var PersonelViewModel = new PersonelViewModel
            {
                Personel = PersonelBul,
                Roller = RolListesi,
                Departmanlar = DepartmanListesi
            };

            return View(PersonelViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PersonelGuncelle(Eleman Personel, HttpPostedFileBase AvatarGorsel)
        {

            var PersonelBul = _ElemanRepository.BulveGetir(Personel.Url);
            if (PersonelBul == null)
            {
                return RedirectToAction("Index", "Personel");
            }

            var adsoyad = Personel.Ad + " " + Personel.Soyad;

            UrlManager.UrlReplace url = new UrlManager.UrlReplace(adsoyad);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != Personel.Url)
            {
                Personel.Url = YeniUrl;
            }

            Personel.KayitTarihi = PersonelBul.KayitTarihi;

            if (Personel.AvatarResim != null && Personel.AvatarResimIsmi != null && Personel.AvatarResimTipi != null)
            {
                Personel.AvatarResim = Personel.AvatarResim;
                Personel.AvatarResimIsmi = Personel.AvatarResimIsmi;
                Personel.AvatarResimTipi = Personel.AvatarResimTipi;
            }

            if (AvatarGorsel != null && AvatarGorsel.ContentLength > 0)
            {
                Personel.AvatarResimIsmi = Path.GetFileName(AvatarGorsel.FileName);
                Personel.AvatarResimTipi = AvatarGorsel.ContentType;

                using (var reader = new BinaryReader(AvatarGorsel.InputStream))
                {
                    Personel.AvatarResim = reader.ReadBytes(AvatarGorsel.ContentLength);
                }
            }
            var guncelle = _ElemanRepository.Guncelle(Personel);
            string _sonuc;
            if (guncelle)
            {
                _sonuc = "Düzenleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi.";
            }
            else
            {
                _sonuc = "Düzenleme İşlemi Sırasında Beklenmedik Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.";
            }

            var DepartmanListesi = _DepartmanRepository.TumunuGetir().ToList();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var RolListesi = _RolRepository.TumunuGetir().ToList();
            if (RolListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var PersonelViewModel = new PersonelViewModel
            {
                Personel = PersonelBul,
                Sonuc = _sonuc,
                Roller = RolListesi,
                Departmanlar = DepartmanListesi
            };

            return View(PersonelViewModel);
        }

        public ActionResult AvatarGorselKaldir(string Url)
        {
            var Personel = _ElemanRepository.BulveGetir(Url);

            if (Personel == null)
            {
                return RedirectToAction("Index", "Personel");
            }

            Personel.AvatarResim = null;
            Personel.AvatarResimIsmi = null;
            Personel.AvatarResimTipi = null;

            _ElemanRepository.Guncelle(Personel);

            return RedirectToAction("PersonelGuncelle", "Personel", new { Url = Personel.Url });
        }

        public ActionResult PersonelSil(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var SilinecekPersonel = _ElemanRepository.BulveGetir(url.ToString());
            _ElemanRepository.Sil(SilinecekPersonel);

            return RedirectToAction("Index", "Personel");
        }
    }
}