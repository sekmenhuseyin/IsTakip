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
    public class DuyuruController : Controller
    {
        private readonly IDuyuruRepository<Duyuru> _DuyuruRepository;
        private readonly IElemanRepository<Eleman> _ElemanRepository;

        public DuyuruController(IDuyuruRepository<Duyuru> DuyuruRepository, IElemanRepository<Eleman> ElemanRepository)
        {
            _DuyuruRepository = DuyuruRepository;
            _ElemanRepository = ElemanRepository;
        }
        public ActionResult Index()
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            var DuyuruListesi = _DuyuruRepository.TumunuGetir().ToList();
            if (DuyuruListesi == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(DuyuruListesi);
        }

        public ActionResult DuyuruEkle()
        {
            if (Session["Yonetici"]==null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var PersonelListesi = _ElemanRepository.RolIdyeGoreGetir(3);//Yunusa kimlerin duyuru ekleye bileceğini sor?
            if (PersonelListesi==null)
            {
                return RedirectToAction("Index", "Duyuru");
            }
            var selectlistpersonel = PersonelListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });
            var calisanListesi = _ElemanRepository.RolIdyeGoreGetir(4);
            if (calisanListesi==null)
            {
                return RedirectToAction("Index", "Duyuru");
            }
            var selectlistcalisan = calisanListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Url.ToString() });
            var DuyuruViewModel = new DuyuruViewModel()
            {
                PersonelListe=selectlistpersonel,
                CalisanListe=selectlistcalisan
            };
            return View(DuyuruViewModel);
        }

        public ActionResult DuyuruEkle(DuyuruViewModel DuyuruModel)
        {
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(DuyuruModel.Duyuru.Duyurubasligi);
            DuyuruModel.Duyuru.Url = url.Replace.ToString();

            var ekleme = _DuyuruRepository.Ekle(DuyuruModel.Duyuru);

            if (ekleme)
            {

            }
            return RedirectToAction("Index", "Duyuru");
        }

        public ActionResult DuyuruGuncelle(string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (url == null)
            {
                return View("Index", "Duyuru");
            }

            var DuyuruBul = _DuyuruRepository.BulveGetir(url);
            if (DuyuruBul == null)
            {
                return RedirectToAction("Index", "Duyuru");
            }
            var PersonelListesi = _ElemanRepository.RolIdyeGoreGetir(3);
            if (PersonelListesi == null)
            {
                return RedirectToAction("Index", "Duyuru");
            }

            var selectlistpersonel = PersonelListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });


            var CalisanListesi = _ElemanRepository.RolIdyeGoreGetir(4);
            if (CalisanListesi == null)
            {
                return RedirectToAction("Index", "Duyuru");
            }
            var selectlistcalisan = CalisanListesi.Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() });

            var DuyuruCalisanlari = DuyuruBul.Ekleyen;
            if (DuyuruCalisanlari == null)
            {
                return RedirectToAction("Index", "Duyuru");
            }

            var DepartmanViewModel = new DepartmanViewModel()
            {
                PersonelListe = selectlistpersonel,
                CalisanListe = selectlistcalisan,
            };
            return View(DepartmanViewModel);
        }
    }
}