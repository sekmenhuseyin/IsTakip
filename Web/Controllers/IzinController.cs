using Core.Infrastructure;
using Data.Enums;
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
    public class IzinController : Controller
    {
        private readonly IIzinRepository<Izin> _IzinRepository;
        private readonly IElemanRepository<Eleman> _ElemanRepository;

        public IzinController(IIzinRepository<Izin> IzinRepository, IElemanRepository<Eleman> ElemanRepository)
        {
            _IzinRepository = IzinRepository;
            _ElemanRepository = ElemanRepository;
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

            if (GirenKullanici.RolId == 1 || GirenKullanici.RolId == 2)
            {
                var IzınListesi = _IzinRepository.TumunuGetir();
                var ViewModel = new IzinViewModel()
                {
                    Izinler = IzınListesi,
                };
                return View(ViewModel);
            }
            else if (GirenKullanici.RolId == 3)
            {

                var IzınListesi = _IzinRepository.ElemanaGoreGetir(GirenKullanici.Url);
                var CalisanIzınListesi = _IzinRepository.DepartmanaGoreGetir(GirenKullanici.Departman.Url);
                var ViewModel = new IzinViewModel()
                {
                    Izinler = IzınListesi,
                    CalisanIzinleri = CalisanIzınListesi
                };
                return View(ViewModel);
            }
            else
            {
                var IzınListesi = _IzinRepository.ElemanaGoreGetir(GirenKullanici.Url);
                var ViewModel = new IzinViewModel()
                {
                    Izinler = IzınListesi,
                };
                return View(ViewModel);
            }
        }

        public ActionResult IzinEkle()
        {

            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IzinEkle(Izin Izin)
        {
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(Izin.IzinBasligi);
            Izin.Url = url.Replace.ToString();

            var ElemanBul = _ElemanRepository.BulveGetir(Session["YoneticiUrl"].ToString());
            if (ElemanBul == null)
            {
                return RedirectToAction("Index", "Izin");
            }
            Izin.ElemanId = ElemanBul.Id;
            if (ElemanBul.RolId == 3 || ElemanBul.RolId == 4)
            {
                Izin.IzinDurum = IzinDurumlari.Beklemede;
            }

            var ekleme = _IzinRepository.Ekle(Izin);

            return RedirectToAction("Index", "Izin");
        }

        public ActionResult IzinDetay(string url)
        {

            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var IzinBul = _IzinRepository.BulveGetir(url);
            if (IzinBul == null)
            {
                return RedirectToAction("Index", "Izin");
            }
            var DigerIzinler = _IzinRepository.ElemanaGoreGetir(IzinBul.Eleman.Url);
            if (DigerIzinler == null)
            {
                return RedirectToAction("Index", "Izin");
            }

            var ViewModel = new IzinViewModel()
            {
                GecmisIzinler = DigerIzinler,
                Izin = IzinBul
            };

            return View(ViewModel);
        }

        public ActionResult IzinGuncelle(string url)
        {

            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var IzinBul = _IzinRepository.BulveGetir(url);
            if (IzinBul == null)
            {
                return RedirectToAction("Index","Izin");
            }

            return View(IzinBul);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IzinGuncelle(Izin Izin)
        {

            var IzinBul = _IzinRepository.BulveGetir(Izin.Url);

            UrlManager.UrlReplace url = new UrlManager.UrlReplace(Izin.IzinBasligi);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != Izin.Url)
            {
                Izin.Url = YeniUrl;
            }

            
            if(Session["YoneticiRolId"].ToString() != "4")
            {
                if (Izin.IzinDurum != IzinBul.IzinDurum)
                {
                    var PersonelBul = _ElemanRepository.BulveGetir(Izin.Eleman.Url);
                    if (PersonelBul.KullanilanToplamIzın < PersonelBul.IzınGunSayisi)
                    {
                        var guncelle = _IzinRepository.Guncelle(Izin);

                        if (Izin.IzinDurum == IzinDurumlari.Onaylandi)
                        {
                            var IzinSuresi = Izin.BitisTarihi - Izin.BaslangicTarihi;
                            PersonelBul.KullanilanToplamIzın += IzinSuresi.Days + 1;
                            var personelguncelle = _ElemanRepository.Guncelle(PersonelBul);
                        }
                        else if (Izin.IzinDurum == IzinDurumlari.Iptal)
                        {
                            var IzinSuresi = Izin.BitisTarihi - Izin.BaslangicTarihi;
                            PersonelBul.KullanilanToplamIzın -= IzinSuresi.Days + 1;
                            var personelguncelle = _ElemanRepository.Guncelle(PersonelBul);
                        }
                    }
                }
                else
                {
                    Izin.IzinDurum = IzinBul.IzinDurum;
                    var guncelle = _IzinRepository.Guncelle(Izin);
                }
            }
            else
            {
                Izin.IzinDurum = IzinBul.IzinDurum;
                var guncelle = _IzinRepository.Guncelle(Izin);
            }

            return RedirectToAction("Index", "Izin");
        }

        public ActionResult IzinSil(string url)
        {
            var SilinecekIzin = _IzinRepository.BulveGetir(url);
            if (SilinecekIzin.IzinDurum != IzinDurumlari.Onaylandi)
            {
                _IzinRepository.Sil(SilinecekIzin);
            }
            return RedirectToAction("Index", "Izin");
        }
    }
}