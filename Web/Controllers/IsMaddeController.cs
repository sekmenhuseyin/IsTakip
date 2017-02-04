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
    public class IsMaddeController : Controller
    {
        private readonly IIsMaddeRepository<IsMadde> _IsMaddeRepository;
        private readonly IIsRepository<Is> _IsRepository;

        public IsMaddeController(IIsMaddeRepository<IsMadde> IsMaddeRepository, IIsRepository<Is> IsRepository)
        {
            _IsMaddeRepository = IsMaddeRepository;
            _IsRepository = IsRepository;
        }

        public ActionResult IsMaddeEkle(string isurl)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }
            var IsBul = _IsRepository.BulveGetir(isurl);
            var ViewModel = new IsMaddeViewModel()
            {
                Is = IsBul
            };
            return View(ViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IsMaddeEkle(IsMaddeViewModel ViewModel)
        {
            if (ViewModel.IsMadde == null)
            {
                return RedirectToAction("Index", "Is");
            }

            ViewModel.IsMadde.IsMaddeTarih = DateTime.Now;
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(ViewModel.IsMadde.IsMaddeBasligi);
            ViewModel.IsMadde.Url = url.Replace.ToString();
            ViewModel.IsMadde.IsId = ViewModel.Is.Id;

            var ekle = _IsMaddeRepository.Ekle(ViewModel.IsMadde);

            return RedirectToAction("IsDetay", "Is", new { Url = ViewModel.Is.Url });
        }

        public ActionResult IsMaddeGuncelle(string isurl, string url)
        {
            if (Session["Yonetici"] == null)
            {
                return RedirectToAction("GirisYap", "Giris");
            }

            if (isurl == null || url == null)
            {
                return RedirectToAction("Index", "IsMadde");
            }

            var IsBul = _IsRepository.BulveGetir(isurl);
            if (IsBul == null)
            {
                return RedirectToAction("Index", "IsMadde");
            }

            var IsMaddeBul = _IsMaddeRepository.BulveGetir(url);
            if (IsMaddeBul == null)
            {
                return RedirectToAction("Index", "IsMadde");
            }
            var ViewModel = new IsMaddeViewModel()
            {
                Is = IsBul,
                IsMadde = IsMaddeBul
            };

            return View(ViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult IsMaddeGuncelle(IsMaddeViewModel ViewModel)
        {
            ViewModel.IsMadde.IsMaddeGuncellemeTarih = DateTime.Now;
            UrlManager.UrlReplace url = new UrlManager.UrlReplace(ViewModel.IsMadde.IsMaddeBasligi);
            var YeniUrl = url.Replace.ToString();

            if (YeniUrl != ViewModel.IsMadde.Url)
            {
                ViewModel.IsMadde.Url = YeniUrl;
            }

            ViewModel.IsMadde.IsId = ViewModel.Is.Id;

            var guncelle = _IsMaddeRepository.Guncelle(ViewModel.IsMadde);

            return RedirectToAction("Index", "IsMadde", new { isurl = ViewModel.Is.Url });
        }

        [HttpPost]
        public ActionResult IsMaddeDurumGuncelle()
        {
            return RedirectToAction("IsDetay", "Is", new { Url = Url });
        }

        public ActionResult IsMaddeSil(string isurl, string url)
        {
            var SilinecekIsMadde = _IsMaddeRepository.BulveGetir(url);
            _IsMaddeRepository.Sil(SilinecekIsMadde);

            return RedirectToAction("IsDetay", "Is", new { Url = isurl });
        }
    }
}