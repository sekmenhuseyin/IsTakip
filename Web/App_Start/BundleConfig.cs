using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Genel/Css").Include(
                      "~/document/css/bootstrap.min.css",
                      "~/document/css/dashboard.css",
                      "~/document/css/jqtransform.css",
                      "~/document/css/icons.css",
                      "~/document/css/bootstrap-switch.css",
                      "~/document/css/pages.css"));

           
            bundles.Add(new ScriptBundle("~/Genel/Js").Include(
                    "~/document/js/jquery.min.js",
                    "~/document/js/bootstrap.min.js",
                    "~/document/js/jquery.jqtransform.js",
                     "~/document/js/bootstrap-switch.js",
                    "~/document/js/element.js"));

         

        }
    }
}
