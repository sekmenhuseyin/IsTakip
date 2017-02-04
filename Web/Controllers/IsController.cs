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
    public class IsController : Controller
    {
        private readonly IElemanRepository<Eleman> _ElemanRepository;
        private readonly IIsRepository<Is> _IsRepository;
        private readonly IIsMaddeRepository<IsMadde> _IsMaddeRepository;
        private readonly IDepartmanRepository<Departman> _DepartmanRepository;

        public IsController(IElemanRepository<Eleman> ElemanRepository, IIsRepository<Is> IsRepository, IIsMaddeRepository<IsMadde> IsMaddeRepository, IDepartmanRepository<Departman> DepartmanRepository)
        {
            _ElemanRepository = ElemanRepository;
            _IsRepository = IsRepository;
            _IsMaddeRepository = IsMaddeRepository;
            _DepartmanRepository = DepartmanRepository;
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

            List<Is> IsListele;

            if (GirenKullanici.RolId == 1 || GirenKullanici.RolId == 2)
            {
                IsListele = _IsRepository.TumunuGetir().ToList();
            }
            else if (GirenKullanici.RolId == 3)
            {
                IsListele = _IsRepository.DepartmanaGoreGetir(GirenKullanici.Departman.Url).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(IsListele);
        }

        public ActionResult IsEkle()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var DepartmanListesi = _DepartmanRepository.TumunuGetir();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Is");
            }
            var Calisanlar = _ElemanRepository.TumunuGetir().ToList();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Is");
            }

            var IsEkleViewModel = new IsViewModel {
                Departmanlar = DepartmanListesi,
                Calisanlar = Calisanlar
            };
            return View(IsEkleViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IsEkle(IsViewModel IsViewModel)
        {
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(IsViewModel.Is.IsBasligi);
            IsViewModel.Is.Url = url.Replace.ToString();
            
            IsViewModel.Is.Tarih = DateTime.Now;


            var SecilenCalisanlar = new List<Eleman>();
            foreach (var item in IsViewModel.SeciliCalisanlarinIdleri)
            {
                var bulunan = _ElemanRepository.IdyeGoreBulveGetir(item);
                if (bulunan == null)
                {
                    return RedirectToAction("Index", "Is");
                }
                SecilenCalisanlar.Add(bulunan);
            }


            var ekleme = _IsRepository.Ekle(IsViewModel.Is);

            IsViewModel.Is.Eleman = SecilenCalisanlar;
            ekleme = _IsRepository.Guncelle(IsViewModel.Is);

            return RedirectToAction("IsMaddeEkle", "IsMadde", new { IsUrl = IsViewModel.Is.Url});
        }

        public ActionResult IsDetay(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            if (url == null)
            {
                return RedirectToAction("Index", "Is");
            }

            var IsBul = _IsRepository.BulveGetir(url);
            var IsMaddeListesi = _IsMaddeRepository.IseGoreMaddeListele(url);
            if (IsBul == null || IsMaddeListesi == null)
            {
                return RedirectToAction("Index", "Is");
            }

            var ViewModel = new IsViewModel()
            {
                Is = IsBul,
                IsMaddeler = IsMaddeListesi
            };

            return View(ViewModel);
        }

        public ActionResult IsGuncelle(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return View("Index", "Is");
            }

            var IsBul = _IsRepository.BulveGetir(url);
            if (IsBul == null)
            {
                return View("Index", "Is");
            }
            var DepartmanListesi = _DepartmanRepository.TumunuGetir();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Is");
            }
            var ViewModel = new IsViewModel
            {
                Departmanlar = DepartmanListesi,
                Is = IsBul
            };
            return View(ViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IsGuncelle(Is Is)
        {
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(Is.IsBasligi);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != Is.Url)
            {
                Is.Url = YeniUrl;
            }

            Is.GuncellemeTarihi = DateTime.Now;

            var guncelle = _IsRepository.Guncelle(Is);
            string _sonuc;
            if (guncelle)
            {
                _sonuc = "Düzenleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi.";
            }
            else
            {
                _sonuc = "Düzenleme İşlemi Sırasında Beklenmedik Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.";
            }

            var IsBul = _IsRepository.BulveGetir(Is.Url);
            if (IsBul == null)
            {
                return View("Index", "Is");
            }
            var DepartmanListesi = _DepartmanRepository.TumunuGetir();
            if (DepartmanListesi == null)
            {
                return RedirectToAction("Index", "Is");
            }
            var ViewModel = new IsViewModel
            {
                Sonuc = _sonuc,
                Departmanlar = DepartmanListesi,
                Is = IsBul
            };
            return View(ViewModel);
        }

        public ActionResult IsSil(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return RedirectToAction("Index", "Is");
            }

            var SilinecekIs = _IsRepository.BulveGetir(url);
            if (SilinecekIs == null)
            {
                return RedirectToAction("Index", "Is");
            }

            var SilinecekIsMaddeleri = _IsMaddeRepository.IseGoreMaddeListele(SilinecekIs.Url);

            foreach (var item in SilinecekIsMaddeleri)
            {
                var silinecekismadde = _IsMaddeRepository.BulveGetir(item.Url);
                _IsMaddeRepository.Sil(silinecekismadde);
            }

            _IsRepository.Sil(SilinecekIs);

            return RedirectToAction("Index","Is");
        }
    }
}