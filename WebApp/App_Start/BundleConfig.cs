using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        , "~/Scripts/bootstrap-datetimepicker/moment-with-locales.js"
                        , "~/Scripts/bootstrap-datetimepicker/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Client Scripts/mvcfoolproof.unobtrusive.min.js",
                        "~/Client Scripts/MvcFoolproofJQueryValidation.min.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootbox.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker/bootstrap-datetimepicker.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js"));
        }
    }
}
