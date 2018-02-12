using System.Web;
using System.Web.Optimization;

namespace JansenAndSixel
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*")); 

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));





                

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //calendar css file
            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
                "~/Content/themes/jquery.ui.all.css",
                "~/Content/fullcalendar.css"));

            //calendar script file
            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                "~/Scripts/jquery-ui-{version}.min.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/fullcalendar.min.js"));

            //Justified Gallery css file
            bundles.Add(new StyleBundle("~/Content/JustifiedGallerycss").Include(
                "~/Content/justifiedCallendar.css",
                "~/Content/justifiedGallery.min.css"));

            //Justified Gallery js file
            bundles.Add(new ScriptBundle("~/bundles/JustifiedGalleryjs").Include(
                "~/Scripts/justifiedGallery.js"));

            //Justified Gallery jquery file
            bundles.Add(new ScriptBundle("~/bundles/jquery-justifiedGalleryjs").Include(
                "~/Scripts/jquery-justifiedGallery.js",
                "~/Scripts/jquery-justifiedGallery.min.js"));
        }
    }
}
