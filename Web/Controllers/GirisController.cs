using Core.Infrastructure;
using Data.Model;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class GirisController : Controller
    {
        private readonly IElemanRepository<Eleman> _ElemanRepository;

        public GirisController(IElemanRepository<Eleman> ElemanRepository)
        {
            _ElemanRepository = ElemanRepository;
        }

        public ActionResult GirisYap()
        {
            if (Session["Yonetici"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult GirisYap(GirisViewModel Giris)
        {
            if (Giris.GirisDurumu == false)
            {
                Giris.HataAciklamasi = "Kullanıcı Adı/Şifre Alanı Boş Bırakılamaz !";
                return View(Giris);
            }
            var eposta = Giris.EpostaAdresi;
            var sifre = Giris.Sifre;

            var GirisKontrol = _ElemanRepository.Giris(eposta, sifre);

            if (GirisKontrol == null)
            {
                Giris.GirisDurumu = false;
                Giris.HataAciklamasi = "Giriş Bilgileri Hatalı Girildi !";
                return View(Giris);
            }

            Session["Yonetici"] = GirisKontrol;
            Session["YoneticiUrl"] = GirisKontrol.Url;
            Session["YoneticiRolId"] = GirisKontrol.RolId;
            Session["YoneticiAdSoyad"] = GirisKontrol.Ad + GirisKontrol.Soyad;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SifremiUnuttum()
        {
            if (Session["Yonetici"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [ActionName("Cikis")]
        public ActionResult Cikis()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("GirisYap", "Giris");
        }
    }
}