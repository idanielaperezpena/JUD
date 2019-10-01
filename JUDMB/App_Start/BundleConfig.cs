using System.Web;
using System.Web.Optimization;

namespace JUDMB
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundles/general_js").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/adminlte.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquery_validate").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/validaciones_general.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/select2_js").Include(
                        "~/Scripts/select2.full.min.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/general_css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/ionicons.min.css",
                        "~/Content/AdminLTE.min.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/estilos").Include(
                        "~/Content/skin-green-light.min.css",
                        "~/Content/estilos.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/select2_css").Include(
                        "~/Content/select2.min.css"
                        ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



        }
    }
}
