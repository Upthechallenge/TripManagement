using Agencevoyage.Domain.Entities;
using Agencevoyage.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agencevoyage.Models;
using Agencevoyage.Helpers;

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
            List<FilmViewModel> fVM = new List<FilmViewModel>();
            foreach (var item in film)
            {
                fVM.Add(
                    new FilmViewModel {
                        Id=item.Id,
                        Description=item.Description,
                        Title=item.Title,
                        Genre=item.Genre,
                        ImageUrl=item.ImageUrl,
                        OutDate=item.OutDate,
                        ProducteurId=item.ProducteurId
                    });
            }
            return View(fVM);
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
      

       // POST: Film/Create
       [HttpPost]
        public ActionResult Create(FilmViewModel f, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            f.ImageUrl = Image.FileName;
            Film film = new Film {
                Title = f.Title,
                Description = f.Description,
                Genre = f.Genre,
                ImageUrl=f.ImageUrl,
                OutDate=f.OutDate,
                ProducteurId=f.ProducteurId
            };
            service.AddFilm(film);
            service.SaveChange();
            // Sauvgarde de l'image
          
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
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
