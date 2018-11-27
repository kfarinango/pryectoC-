using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        LibroVisitas libro = null;
        SqlParameter[] parParameter = null;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FormularioVisita()
        {
            return View();
        }
        public ActionResult CargaDatos()
        {
            string nombre = Request.Form["nombre"].ToString();
            string comentario = Request.Form["comentarios"].ToString();
            int opc = 2;
            try
            {
                libro = new LibroVisitas();
                parParameter = new SqlParameter[3];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                //parParameter[0].SqlValue = objContacto.opc;
                parParameter[0].SqlValue = opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@nombre";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].SqlValue = nombre;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@comentario";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 500;
                parParameter[2].SqlValue = comentario;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            libro.EjecutarSP(parParameter, "sp_comentario");
            return View();
        }
    }
}
