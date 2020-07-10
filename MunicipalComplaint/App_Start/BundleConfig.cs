using System.Web;
using System.Web.Optimization;

namespace MunicipalComplaint
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/alljs").Include(
                       "~/Scripts/js/easing.min.js",
                       "~/Scripts/js/hoverIntent.js",
                       "~/Scripts/js/superfish.min.js",
                       "~/Scripts/js/jquery.ajaxchimp.min.js",
                       "~/Scripts/js/jquery.magnific-popup.min.js",
                       "~/Scripts/js/owl.carousel.min.js",
                       "~/Scripts/js/jquery.sticky.js",
                       "~/Scripts/js/jquery.nice-select.min.js",
                       "~/Scripts/js/waypoints.min.js",
                       "~/Scripts/js/jquery.counterup.min.js",
                       "~/Scripts/js/parallax.min.js",
                       "~/Scripts/js/mail-script.js",
                       "~/Scripts/js/main.js",
                       "~/Scripts/js/vendor/jquery-2.2.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/CustomerJs").Include(
                 "~/Scripts/CustomerJs/jquery.js",
                 "~/Scripts/CustomerJs/bootstrap.js"


                ));
            bundles.Add(new ScriptBundle("~/bundles/AdminJS").Include(
                     "~/Scripts/AdminJS/jquery.min.js",
                     "~/Scripts/AdminJS/popper.js",
                     "~/Scripts/AdminJS/tooltip.js",
                     "~/Scripts/AdminJS/bootstrap.min.js",
                     "~/Scripts/AdminJS/jquery.nicescroll.min.js",
                     "~/Scripts/AdminJS/scroll-up-bar.min.js",
                     "~/Scripts/AdminJS/sa-functions.js",
                     "~/Scripts/AdminJS/chart.min.js",
                     "~/Scripts/AdminJS/summernote-lite.js",
                     "~/Scripts/AdminJS/scripts.js",
                     "~/Scripts/AdminJS/custom.js",
                     "~/Scripts/AdminJS/demo.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap/bootstrap.css",
                      "~/Content/sectionStyle.css",
                      "~/Content/site.css",
                      "~/Content/css/linearicons.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/nice-select.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/main.css",
                      "~/Content/css/nice-select.css"));

            bundles.Add(new StyleBundle("~/Content/Customercss").Include(
                 "~/Content/Customercss/slider.css"
                
                ));

            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                     "~/Content/AdminCss/bootstrap.min.css",
                     "~/Content/AdminCss/demo.css",
                     "~/Content/AdminCss/ModalStlyes.css",
                     "~/Content/AdminCss/flag-icon.min.css",
                     "~/Content/AdminCss/fontawesome-all.min.css",
                     "~/Content/AdminCss/ionicons.min.css",
                     "~/Content/AdminCss/style.css",
                     "~/Content/AdminCss/summernote-lite.css",
                     "~/Content/AdminCss/darksidebar.css",
                     "~/Content/AdminCss/lightblue.css",
                      "~/Content/AdminCss/deeppurple.css",
                       "~/Content/AdminCss/blue.css",
                        "~/Content/AdminCss/summernote-bs4.css"
                    ));

        }
    }
}
