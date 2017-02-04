using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Helpers
{
    public static class ImageViewHelpers
    {
        public static IHtmlString PersonelGorselBase64Image(this HtmlHelper helper, Eleman Personel)
        {
            if (Personel.AvatarResim != null)
            {
                var imgString = string.Format(@"<img width='150' height='120' src='data:{0};base64,{1}' />",
                        Personel.AvatarResimTipi,
                        Convert.ToBase64String(Personel.AvatarResim)
                        );
                return new HtmlString(imgString);
            }
            else
            {
                return null;
            }
        }

        public static IHtmlString ProfilGorselBase64Image(this HtmlHelper helper, byte[] AvatarResim, string AvatarResimTipi)
        {
            if (AvatarResim != null)
            {
                var imgString = string.Format(@"<img width='150' height='120' src='data:{0};base64,{1}' />",
                        AvatarResimTipi,
                        Convert.ToBase64String(AvatarResim)
                        );
                return new HtmlString(imgString);
            }
            else
            {
                return null;
            }
        }
    }
}
