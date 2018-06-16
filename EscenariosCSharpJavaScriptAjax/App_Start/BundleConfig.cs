using System.Web;
using System.Web.Optimization;

namespace EscenariosCSharpJavaScriptAjax
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.unobtrusive-ajax.js", "~/Scripts/jquery-ui-1.12.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Uniendo y minificando archivos de una carpeta ,sin importar el orden
            bundles.Add(new ScriptBundle("~/bundles/lib").IncludeDirectory("~/Scripts/lib", "*.js"));

            //Uniendo y minificando Javascript y CSS  ** Tambien se puede hacer desde el Web.config, seteando <compilation debug="true" en false y BundleTable no hace falta
            BundleTable.EnableOptimizations = true;
        }
    }
}
