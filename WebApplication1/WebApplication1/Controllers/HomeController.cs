using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FormularioVista()
        {
            return View();
        }

        public ActionResult CargaDatos()
        {
	            string nombre = Request.Form["nombre"].ToString();
	            string comentarios = Request.Form["comentarios"].ToString();
	            LibroVisitas libro = new LibroVisitas();
	            libro.Grabar(nombre, comentarios);
	            return View();
	    }

        public ActionResult ListadoVisitas()
        {
            LibroVisitas libro = new LibroVisitas();
            string todo = libro.Leer();
            ViewData["libro"] = todo;
            return View();
        }


    }
}