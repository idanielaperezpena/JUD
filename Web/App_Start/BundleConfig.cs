using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bundles SINVI
            bundles.Add(new ScriptBundle("~/bundles/general_js").Include(
                        "~/Scripts/UI/jquery/jquery-{version}.js",
                        "~/Scripts/UI/bootstrap/bootstrap.js",
                        "~/Scripts/UI/admin/adminlte.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquery_validate").Include(
                        "~/Scripts/UI/jquery/jquery.validate-{version}.js",
                        "~/Scripts/UI/jquery/jquery.validate.unobtrusive-{version}.js",
                        "~/Scripts/UI/admin/validaciones_general.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/select2_js").Include(
                        "~/Scripts/UI/select2/select2.full.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/datatables_js").Include(
                        "~/Scripts/UI/datatables.net/jquery.dataTables.min.js",
                        "~/Scripts/UI/datatables.net-bs/dataTables.bootstrap.min.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/general_css").Include(
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/fontawesome/css/all-{version}.css",
                        "~/Content/ionicons/ionicons.min.css",
                        "~/Content/estilos_base/AdminLTE.min.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/estilos").Include(
                        "~/Content/estilos_base/skin-green-light.min.css",
                        "~/Content/BaseInvi.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/select2_css").Include(
                        "~/Content/select2/elect2.min.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/datatables_css").Include(
                        "~/Content/datatables.net-bs/dataTables.bootstrap.min.css"
                        ));


            // Bundles de la pLantilla
            bundles.Add(new StyleBundle("~/Content/Base").Include(
                "~/Content/fontawesome/css/all-{version}.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/Utilidades").Include(
                "~/Content/jquery-ui/jquery-ui.min-{version}.css",
                "~/Content/pnotify/pnotify-{version}.css",
                "~/Content/pnotify/pnotify.buttons-{version}.css",
                "~/Content/pnotify/pnotify.mobile-{version}.css",
                "~/Content/bootstrap-datepicker/bootstrap-datepicker3-{version}.css",
                "~/Content/daterangepicker/daterangepicker-{version}.css"));

            bundles.Add(new StyleBundle("~/Content/Custom").Include(
                "~/Content/BaseWeb.css"));

            bundles.Add(new ScriptBundle("~/Bundles/Base").Include(
                "~/Scripts/UI/jquery/jquery-{version}.js",
                "~/Scripts/UI/jquery/jquery.validate-{version}.js",
                "~/Scripts/UI/jquery/jquery.validate.unobtrusive-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/Utilidades").Include(
                "~/Scripts/UI/jquery-ui/jquery-ui.min-{version}.js",
                "~/Scripts/UI/pnotify/pnotify-{version}.js",
                "~/Scripts/UI/pnotify/pnotify.buttons-{version}.js",
                "~/Scripts/UI/pnotify/pnotify.mobile-{version}.js",
                "~/Scripts/UI/autoNumeric/autoNumeric-{version}.js",
                "~/Scripts/UI/bootstrap-datepicker/bootstrap-datepicker-{version}.js",
                "~/Scripts/UI/bootstrap-datepicker/bootstrap-datepicker-es-{version}.js",
                "~/Scripts/UI/moment/moment-with-locales-{version}.js",
                "~/Scripts/UI/daterangepicker/daterangepicker-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/Custom").Include(
                "~/Scripts/BaseWeb.js",
                "~/Scripts/BaseInit.js"));
        }
    }
}