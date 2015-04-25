using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class DvdViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Naam { get; set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get; set; }

        [Display(Name = "Beschikbaar")]
        public bool Beschikbaar { get; set; }
        public int Leeftijd { get; set; }

        public int Size { get; set; }
        public ICollection<Categorie> Categories { get; set; }

        public DvdViewModel(DVD dvd)
        {
            Id = dvd.Id;
            Naam = dvd.Naam;
            Beschrijving = dvd.Beschrijving;
            Beschikbaar = dvd.Beschikbaar;
            Size = dvd.Size;
            Categories = dvd.Categories;
            Leeftijd = dvd.Leeftijd;
        }

        public DvdViewModel()
        {
            
        }
    }
}