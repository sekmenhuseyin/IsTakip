using Data.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Classes
{
    public class UrlManager
    {
        public class UrlReplace
        {
            string url;
            public string Replace
            {
                get { return url; }
                set { url = value; }
            }

            public UrlReplace(string kelime)
            {
                url = kelime;
                string Temp = url.ToLower();
                Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "-");
                Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
                Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
                Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
                Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
                Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
                Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
                Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
                Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
                Temp = Temp.Replace("?", ""); Temp = Temp.Replace(".", "");
                Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("'", "");
                url = Temp;
            }
        }

        #region UrlKontrol
        //    public class UrlKontrol
        //    {
        //        public static string EklemeUrlKontrolSistemi<T>(int s, string url, List<T> kontrollist)
        //        {
        //            //string newurl = url;
        //            //ArrayList kontrolarray = kontrollist.ToArray();
        //            //foreach (var item in kontrolarray)
        //            //{
        //            //    if (personel.Url == newurl)
        //            //    {

        //            //    }
        //            //}

        //            //if (dtKontrol.Rows.Count > 0)
        //            //{
        //            //    int z = s + 1;

        //            //    for (int a = s; a < z; a++)
        //            //    {
        //            //        DataTable dtAltKontrol = UcIslem.kosulluliste("" + tabloadi + "", "Url='" + (newurl + (a + 1)) + "'");
        //            //        dtKontrol.Dispose();

        //            //        if (dtAltKontrol.Rows.Count > 0)
        //            //        {
        //            //            z += 1;
        //            //        }
        //            //        else
        //            //        {
        //            //            newurl = url + (a + 1);
        //            //        }
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    newurl = url;
        //            //}

        //            return newurl;
        //        }

        //        //public static string DuzenlemeUrlKontrolSistemi(int Id, int s, string tabloadi, string url)
        //        //{
        //        //    string newurl = url;

        //        //    DataTable dtKontrol = UcIslem.kosulluliste("" + tabloadi + "", "Id!='" + Id + "' and Url='" + newurl + "'");
        //        //    dtKontrol.Dispose();

        //        //    if (dtKontrol.Rows.Count > 0)
        //        //    {
        //        //        int z = s + 1;

        //        //        for (int a = s; a < z; a++)
        //        //        {
        //        //            DataTable dtAltKontrol = UcIslem.kosulluliste("" + tabloadi + "", "Id!='" + Id + "' and Url='" + (newurl + (a + 1)) + "'");
        //        //            dtKontrol.Dispose();

        //        //            if (dtAltKontrol.Rows.Count > 0)
        //        //            {
        //        //                z += 1;
        //        //            }
        //        //            else
        //        //            {
        //        //                newurl = url + (a + 1);
        //        //            }
        //        //        }
        //        //    }
        //        //    else
        //        //    {
        //        //        newurl = url;
        //        //    }

        //        //    return newurl;
        //        //}
        //    }
        //} 
        #endregion
    }
}
