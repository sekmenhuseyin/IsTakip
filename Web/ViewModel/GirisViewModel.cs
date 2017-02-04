using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class GirisViewModel
    {
        private string temizle, eposta, sifree;

        public string EpostaAdresi
        {
            get
            {
                return eposta;
            }
            set
            {
                if (value != null)
                {
                    temizle = value;
                    temizle = temizle.Replace(" ", "-"); temizle = temizle.Replace("?", "");
                    temizle = temizle.Replace("\"", ""); temizle = temizle.Replace("/", "");
                    temizle = temizle.Replace("(", ""); temizle = temizle.Replace(")", "");
                    temizle = temizle.Replace("{", ""); temizle = temizle.Replace("}", "");
                    temizle = temizle.Replace("%", ""); temizle = temizle.Replace("&", "");
                    temizle = temizle.Replace("+", ""); temizle = temizle.Replace(",", "");
                    temizle = temizle.Replace("'", "_"); temizle = temizle.Replace("ç", "c");
                    temizle = temizle.Replace("ğ", "g"); temizle = temizle.Replace("ı", "i");
                    temizle = temizle.Replace("ö", "o"); temizle = temizle.Replace("ş", "s");
                    temizle = temizle.Replace("ü", "u"); temizle = temizle.Replace("ı", "i");
                    eposta = temizle;
                    GirisDurumu = true;
                }
                else
                {
                    GirisDurumu = false;
                }
            }
        }
        public string Sifre
        {
            get
            {
                return sifree;
            }
            set
            {
                if (value != null)
                {
                    temizle = value;
                    temizle = temizle.Replace(" ", "-"); temizle = temizle.Replace("'", "_");
                    temizle = temizle.Replace("\"", ""); temizle = temizle.Replace("/", "");
                    temizle = temizle.Replace("(", ""); temizle = temizle.Replace(")", "");
                    temizle = temizle.Replace("{", ""); temizle = temizle.Replace("}", "");
                    temizle = temizle.Replace("%", ""); temizle = temizle.Replace("&", "");
                    sifree = temizle;
                    GirisDurumu = true;
                }
                else
                {
                    GirisDurumu = false;
                }
            }
        }
        public bool GirisDurumu { get; set; }
        public string HataAciklamasi { get; set; }
    }
}
