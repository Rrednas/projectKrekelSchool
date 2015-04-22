using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Controllers
{
    public class CategorieController : Controller
    {
        private IMediatheekRepository mediatheekRepository;
        private Mediatheek mediatheek;
        public CategorieController(IMediatheekRepository repository)
        {
            mediatheekRepository = repository;
            mediatheek = mediatheekRepository.GetMediatheek();
        }
        // GET: Categorie
        public ActionResult Index()
        {
            IEnumerable<Categorie> categories = mediatheek.Categories.AsEnumerable();
            return View(categories);
        }

    }
}