using System.Web;
using System.Web.Optimization;

namespace TMD.GM.Site
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",                       
                        "~/Scripts/jquery-{version}.min.js"//,  "~/Scripts/jquery-1.7.1.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerypri").Include(
                        "~/Scripts/JScriptPrincipal.js"
                       ));


            bundles.Add(new ScriptBundle("~/bundles/kendo")
                  .Include("~/Scripts/kendo/2012.3.1315/kendo.web.*") // or kendo.all.*
                  .Include("~/Scripts/kendo/2012.3.1315/kendo.aspnetmvc.*")
                  .Include("~/Scripts/kendo/2012.3.1315/cultures/kendo.culture.es-PE.min.js")
                  //.Include("~/Scripts/kendo/2012.3.1315/jquery.min.js")
             );


            // The Kendo CSS bundle - replace "2012.3.1315" with the Kendo UI version that you are using
            bundles.Add(new StyleBundle("~/Content/kendo/2012.3.1315/css")
                  .Include("~/Content/kendo/2012.3.1315/kendo.common.*")
                  .Include("~/Content/kendo/2012.3.1315/kendo.default.*")
            );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css", 
                "~/Content/custom.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.IgnoreList.Clear();
        }
    }
}