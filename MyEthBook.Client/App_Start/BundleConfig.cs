using System.Web;
using System.Web.Optimization;

namespace MyEthBook.Client
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


            bundles.Add(new ScriptBundle("~/bundles/sha256").Include(
            "~/Scripts/sha256.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
            "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/kinetic").Include(
                        "~/Scripts/vendor/modernizr-2.8.3-respond-1.4.2.min.js",
                        "~/Scripts/vendor/bootstrap.min.js",
                        "~/Scripts/plugins.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/popup").Include(
                      "~/Scripts/jquery.magnific-popup.js"));

            bundles.Add(new ScriptBundle("~/bundles/ethbook").Include(
                        "~/Scripts/ethbook.js"));

            bundles.Add(new ScriptBundle("~/bundles/my-account").Include(
                        "~/Scripts/my-account.js"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/login.js"));
            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                        "~/Scripts/register.js"));

            bundles.Add(new ScriptBundle("~/bundles/contract").Include(
                        "~/Scripts/contract.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/popup").Include(
                      "~/Content/magnific-popup.css"));

            bundles.Add(new StyleBundle("~/Content/kinetic").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/bootstrap-theme.min.css",
                     "~/Content/fontAwesome.css",
                     "~/Content/tooplate-style.css"
                     ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
