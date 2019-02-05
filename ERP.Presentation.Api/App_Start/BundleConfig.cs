using System.Collections.Generic;
using System.Web.Optimization;

namespace ERP.Presentation.Api
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/tecnun").Include(
                "~/content/tecnun.css"));

            //Componentes JS e CSS para o Bootstrap
            bundles.Add(new StyleBundle("~/css/Bootstrap").Include(
                "~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/js/Bootstrap").Include(
                "~/Content/bootstrap/bootstrap.js"));

            var bundle = new ScriptBundle("~/bundles/jqueryval") { Orderer = new AsIsBundleOrderer() };

            //Componentes JS e CSS para o JQuery
            bundle.Include(
                "~/Scripts/jquery-{version}.js",
                "~/Content/jquery/jquery.maskedinput.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate-vsdoc.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/globalize/globalize.js",
                "~/Scripts/jquery.validate.globalize.js");

            bundles.Add(bundle);

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-2.8.3.js"));

            //Componentes JS e CSS para o DataTable
            bundles.Add(new ScriptBundle("~/JS/DataTable") { Orderer = new AsIsBundleOrderer() }.Include(
                "~/Content/datatable/js/dataTables.bootstrap.min.js",
                "~/Content/datatable/js/jquery.dataTables.js"));

            bundles.Add(new StyleBundle("~/CSS/DataTable").Include(
                "~/Content/datatable/css/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/SELECT2") { Orderer = new AsIsBundleOrderer() }.Include(
                "~/Content/select2/select2.min.css",
                "~/Content/select2/select2-bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/SELECT2").Include("~/Content/select2/select2.min.js"));

        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}