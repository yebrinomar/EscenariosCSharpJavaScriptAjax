using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscenariosCSharpJavaScriptAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DuplicadorCantidad_CS(double cantidadCS)
        {
            var cantidadDuplicada = Duplicador(cantidadCS);
            ViewBag.Resultado = cantidadDuplicada;
            return View("Index");
        }

        [HttpPost]
        public ContentResult DuplicadorCantidad_Ajax(double cantidadAjax)
        {
            var cantidadDuplicada = Duplicador(cantidadAjax);
            return Content(cantidadDuplicada.ToString());
        }

        [HttpPost]
        public JsonResult Duplicador(int cantidad)
        {
            var cantidadDuplicada = Duplicador(Convert.ToDouble(cantidad));
            return Json(cantidadDuplicada);
        }

        [HttpPost]
        public JsonResult Duplicador2(int cantidad)
        {
            System.Threading.Thread.Sleep(200);
            var cantidadDuplicada = Duplicador(Convert.ToDouble(cantidad));
            return Json(cantidadDuplicada);
        }

        [HttpPost]
        public JsonResult CrearPersona(Persona persona)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if(persona.Edad < 18)
                {
                    throw new ApplicationException("La persona no puede ser menor de edad");
                }

                // código para crear peronsa...
                resultado.Mensaje = "Persona creada correctamente";
                resultado.OK = true;
            }
            catch (Exception ex)
            {

                resultado.Mensaje = ex.Message;
                resultado.OK = false;
            }

            return Json(resultado);
        }

        public PartialViewResult SeccionPrueba()
        {
            var personas = new List<Persona>()
            {
                new Persona() { Nombre = "Felipe", Edad = 999, Altura=191, Peso =87},
                new Persona() { Nombre = "Claudia", Edad = 44, Altura=182, Peso =95},
                new Persona() { Nombre = "Génesis", Edad = 23, Altura=178, Peso =88},
                new Persona() { Nombre = "Pedro", Edad = 52, Altura=154, Peso =78},
                new Persona() { Nombre = "Juan", Edad = 76, Altura=157, Peso =83 }
            };

            return PartialView("_Prueba", personas);
        }

        public PartialViewResult DetallePersona(string Nombre)
        {
            var personas = new List<Persona>()
            {
                new Persona() { Nombre = "Felipe", Edad = 999, Altura=191, Peso =87},
                new Persona() { Nombre = "Claudia", Edad = 44, Altura=182, Peso =95},
                new Persona() { Nombre = "Génesis", Edad = 23, Altura=178, Peso =88},
                new Persona() { Nombre = "Pedro", Edad = 52, Altura=154, Peso =78},
                new Persona() { Nombre = "Juan", Edad = 76, Altura=157, Peso =83 }
            };

            var persona = personas.FirstOrDefault(x => x.Nombre == Nombre);
            return PartialView("_DetallePersona", persona);
        }

        private double Duplicador(double cantidad)
        {
            return cantidad * 2;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class BaseRespuesta
    {
        public string Mensaje { get; set; }
        public bool OK { get; set; }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
    }
}