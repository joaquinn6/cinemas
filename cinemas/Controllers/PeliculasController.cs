using cinemas.Models.DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cinemas.Controllers
{
    public class PeliculasController : Controller
    {
        public object DAL { get; private set; }
        // GET: Peliculas
        public ActionResult Index()
        {
            return View(DALPelicula.ListarEstrenos());
        }

        public ActionResult Proximamente()
        {
            return View(DALPelicula.ListarProximamente());
        }

        public ActionResult Formulario(string id="")
        {
            if (id.Length==0)
                return View("Index", DALPelicula.ListarEstrenos());
            else {
                ViewBag.horas = DALPelicula.horas(id);
                ViewBag.ID = id;
                return View();
            }
        }
    }
}