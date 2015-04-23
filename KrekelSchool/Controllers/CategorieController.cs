using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

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
            IEnumerable<Categorie>categories = mediatheek.Categories.OrderBy(l => l.Beschrijving);
            IEnumerable<CategorieViewModel> cvm = categories.Select(l => new CategorieViewModel(l)).ToList();
            return View(cvm);
        }

    }
}