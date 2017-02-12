using Agencevoyage.Domain.Entities;
using Agencevoyage.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agencevoyage.Helpers;
using Agencevoyage.Models;

namespace Agencevoyage.Controllers
{
    public class FilmController : Controller
    {
       

        IFilmManagementService service = null;
        public FilmController()
        {
            service = new FilmManagementService();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Film
        public ActionResult Index()
        {
            var film = service.GetAllFilm();
            return View(film);
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            var filmVM = new FilmViewModel();
            filmVM.Productors = service.GetAllProducteur().ToSelectListItems();
            List<string> genres = new List<string> { "Comedy","Action","Horror"};
            filmVM.Genres = genres.ToSelectListItems();
        
            return View(filmVM);
        }
      

      
        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
