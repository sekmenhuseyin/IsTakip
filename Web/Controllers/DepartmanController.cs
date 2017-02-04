using Core.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Classes;
using Web.ViewModel;

namespace Web.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly IDepartmanRepository<Departman> _DepartmanRepository;
        private readonly IElemanRepository<Eleman> _ElemanRepository;

        public DepartmanController(IDepartmanRepository<Departman> DepartmanRepository, IElemanRepository<Eleman> ElemanRepository)
        {
            _DepartmanRepository = DepartmanRepository;
            _ElemanRepository = ElemanRepository;
        }

        public ActionResult Index()
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
            return View(DepartmanListesi);
        }

        public ActionResult DepartmanEkle()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var PersonelListesi = _ElemanRepository.RolIdyeGoreGetir(3);
            if (PersonelListesi == null)
            {
                return RedirectToAction("Index", "Departman");
            }
            var selectlistpersonel =  PersonelListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });

            var DepartmanViewModel = new DepartmanViewModel()
            {
                PersonelListe = selectlistpersonel,
            };
            return View(DepartmanViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DepartmanEkle(DepartmanViewModel DepartmanModel)
        {
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(DepartmanModel.Departman.DepartmanAdi);
            DepartmanModel.Departman.Url = url.Replace.ToString();

            var ekleme = _DepartmanRepository.Ekle(DepartmanModel.Departman);

            return RedirectToAction("Index", "Departman");
        }

        public ActionResult DepartmanGuncelle(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return View("Index", "Departman");
            }

            var DepartmanBul = _DepartmanRepository.BulveGetir(url);
            if (DepartmanBul == null)
            {
                return RedirectToAction("Index", "Departman");
            }
            var PersonelListesi = _ElemanRepository.RolIdyeGoreGetir(3);
            if (PersonelListesi == null)
            {
                return RedirectToAction("Index", "Departman");
            }

            var selectlistpersonel = PersonelListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });

            var DepartmanViewModel = new DepartmanViewModel()
            {
                PersonelListe = selectlistpersonel,
                Departman = DepartmanBul
            };
            return View(DepartmanViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DepartmanGuncelle(Departman Departman)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var DepartmanBul = _DepartmanRepository.BulveGetir(Departman.Url);
            if (DepartmanBul == null)
            {
                return RedirectToAction("Index", "Departman");
            }

            UrlManager.UrlReplace url = new UrlManager.UrlReplace(Departman.DepartmanAdi);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != Departman.Url)
            {
                Departman.Url = YeniUrl;
            }

            var guncelle = _DepartmanRepository.Guncelle(Departman);
            string _sonuc;
            if (guncelle)
            {
                _sonuc = "Düzenleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi.";
            }
            else
            {
                _sonuc = "Düzenleme İşlemi Sırasında Beklenmedik Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.";
            }

            var PersonelListesi = _ElemanRepository.RolIdyeGoreGetir(3);
            if (PersonelListesi == null)
            {
                return RedirectToAction("Index", "Departman");
            }

            var selectlistpersonel = PersonelListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });

            var DepartmanViewModel = new DepartmanViewModel()
            {
                PersonelListe = selectlistpersonel,
                Sonuc = _sonuc,
                Departman = DepartmanBul
            };
            return View(DepartmanViewModel);
        }

        public ActionResult DepartmanSil(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return RedirectToAction("Index", "Departman");
            }

            var SilinecekDepartman = _DepartmanRepository.BulveGetir(url.ToString());
            if (SilinecekDepartman == null)
            {
                return RedirectToAction("Index", "Departman");
            }
            
            var DepartmanYoneticisi = _ElemanRepository.IdyeGoreBulveGetir(SilinecekDepartman.YoneticiId.Value);
            if (DepartmanYoneticisi == null)
            {
                return RedirectToAction("Index", "Departman");
            }

            DepartmanYoneticisi.DepartmanId = null;
            _ElemanRepository.Guncelle(DepartmanYoneticisi);
            _DepartmanRepository.Sil(SilinecekDepartman);

            return RedirectToAction("Index", "Departman");
        }
    }
}