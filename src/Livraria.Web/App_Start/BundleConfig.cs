using System.Web.Optimization;

namespace Livraria.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.jgrowl.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/lvBase.js"));

            bundles.Add(new ScriptBundle("~/bundles/autores").Include(
                    "~/Scripts/Autores/Autores.js"));

            bundles.Add(new ScriptBundle("~/bundles/editoras").Include(
                   "~/Scripts/Editoras/Editoras.js"));

            bundles.Add(new ScriptBundle("~/bundles/generos").Include(
                   "~/Scripts/Generos/Generos.js"));

            bundles.Add(new ScriptBundle("~/bundles/livros").Include(
                   "~/Scripts/Livros/Livros.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.jgrowl.*",
                      "~/Content/site.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
            foreach (var bundle in bundles)
            {
                bundle.Transforms.Clear();
            }
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}