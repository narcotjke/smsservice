using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/uploadify").Include(
                "~/Uploadify/jquery.uploadify.min.js",
                "~/Scripts/initUploadify.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/datepickerConfig.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/accordion").Include(
                "~/Scripts/accordionConfig.js"
                ));

            bundles.Add(new StyleBundle("~/Content/uploadify").Include(
                "~/Uploadify/uploadify.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/theme.css",
                "~/Content/themes/base/accordion.css"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                "~/Content/themes/base/theme.css",
                "~/Content/themes/base/datepicker.css"));
        }
    }
}
