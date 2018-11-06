using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApplication1.Models
{
	public class Librovisitas
	{
		public void Grabar(String nombre, String comentarios)
		{
			StreamWriter archivo = new StreamWriter(HostingEnvironment.MapPath("-") + "/App_Data/datos.txt", true);
			archivo.WriteLine("Nombre" + nombre + "<br>comentarios:" + comentarios + "</br>");
			archivo.Close();

		}
	}
}