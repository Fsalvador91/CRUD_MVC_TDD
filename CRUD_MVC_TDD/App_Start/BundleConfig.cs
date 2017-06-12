using System.Web.Optimization;

namespace CRUD_MVC_TDD.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JQUERY
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            // BASE
            bundles.Add(new StyleBundle("~/Content/Css").Include(
                    "~/Content/Site.css"));
            // BOOTSTRAP
            bundles.Add(new StyleBundle("~/Content/bootstrap/Css").Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   "~/Scripts/bootstrap.js"));
        }
    }
}
