using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Giris", url: "Giris", defaults: new { Controller = "Giris", Action = "GirisYap" });
            routes.MapRoute(name: "SifremiUnuttum", url: "SifremiUnuttum", defaults: new { Controller = "Giris", Action = "SifremiUnuttum" });
            routes.MapRoute(name: "Anasayfa", url: "Anasayfa", defaults: new { Controller = "Index", Action = "Home" });
            routes.MapRoute(name: "Profil", url: "Profil", defaults: new { Controller = "Profil", Action = "Home" });

            routes.MapRoute(name: "PersonelListesi", url: "PersonelListesi", defaults: new { Controller = "Personel", Action = "Index" });
            routes.MapRoute(name: "PersonelEkle", url: "PersonelEkle", defaults: new { Controller = "Personel", Action = "PersonelEkle" });
            routes.MapRoute(name: "PersonelGuncelle", url: "PersonelGuncelle/{Url}", defaults: new { Controller = "Personel", Action = "PersonelGuncelle", Url = "" });
            routes.MapRoute(name: "PersonelSil", url: "PersonelSil/{Url}", defaults: new { Controller = "Personel", Action = "PersonelSil", Url = "" });
            routes.MapRoute(name: "PersonelAvatarGorseliKaldir", url: "PersonelAvatarKaldir/{Url}", defaults: new { Controller = "Personel", Action = "AvatarGorselKaldir", Url = "" });

            routes.MapRoute(name: "DepartmanListesi", url: "DepartmanListesi", defaults: new { Controller = "Departman", Action = "Index" });
            routes.MapRoute(name: "DepartmanEkle", url: "DepartmanEkle", defaults: new { Controller = "Departman", Action = "DepartmanEkle" });
            routes.MapRoute(name: "DepartmanGuncelle", url: "DepartmanGuncelle/{Url}", defaults: new { Controller = "Departman", Action = "DepartmanGuncelle", Url = "" });
            routes.MapRoute(name: "DepartmanSil", url: "DepartmanSil/{Url}", defaults: new { Controller = "Departman", Action = "DepartmanSil", Url = "" });

            routes.MapRoute(name: "IsListesi", url: "IsListesi", defaults: new { Controller = "Is", Action = "Index" });
            routes.MapRoute(name: "IsEkle", url: "IsEkle", defaults: new { Controller = "Is", Action = "IsEkle" });
            routes.MapRoute(name: "IsDetay", url: "IsDetay/{Url}", defaults: new { Controller = "Is", Action = "IsDetay", Url = "" });
            routes.MapRoute(name: "IsGuncelle", url: "IsGuncelle/{Url}", defaults: new { Controller = "Is", Action = "IsGuncelle", Url = "" });
            routes.MapRoute(name: "IsSil", url: "IsSil/{Url}", defaults: new { Controller = "Is", Action = "IsSil", Url = "" });

            routes.MapRoute(name: "IsMaddeEkle", url: "IsMaddeEkle/{IsUrl}", defaults: new { Controller = "IsMadde", Action = "IsMaddeEkle", IsUrl = "" });
            routes.MapRoute(name: "IsMaddeGuncelle", url: "IsMaddeGuncelle/{IsUrl}/{Url}", defaults: new { Controller = "IsMadde", Action = "IsMaddeGuncelle", IsUrl = "", Url = "" });
            routes.MapRoute(name: "IsMaddeSil", url: "IsMaddeSil/{IsUrl}/{Url}", defaults: new { Controller = "IsMadde", Action = "IsMaddeSil", IsUrl = "", Url = "" });

            routes.MapRoute(name: "IzinListesi", url: "IzinListesi", defaults: new { Controller = "Izin", Action = "Index" });
            routes.MapRoute(name: "IzinEkle", url: "IzinEkle", defaults: new { Controller = "Izin", Action = "IzinEkle" });
            routes.MapRoute(name: "IzinDetay", url: "IzinDetay/{Url}", defaults: new { Controller = "Izin", Action = "IzinDetay", Url = "" });
            routes.MapRoute(name: "IzinGuncelle", url: "IzinGuncelle/{Url}", defaults: new { Controller = "Izin", Action = "IzinGuncelle", Url = "" });
            routes.MapRoute(name: "IzinSil", url: "IzinSil/{Url}", defaults: new { Controller = "Izin", Action = "IzinSil", Url = "" });

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
