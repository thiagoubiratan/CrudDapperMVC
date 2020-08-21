using System.Web.Optimization;

namespace CrudDapperMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/album.css",
                      "~/Content/sticky-footer-navbar.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/Content/toastrCss").Include(
                      "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/toastrJs").Include(
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/toastrFunction.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                      "~/Scripts/inputmask/jquery.inputmask.js",
                      "~/Scripts/MaskFunction.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesJs").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTablesFunction.js"));
        }
    }
}
