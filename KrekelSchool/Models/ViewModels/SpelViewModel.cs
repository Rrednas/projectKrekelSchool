using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class SpelViewModel
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

        [Display(Name = "Afbeelding URL")]
        [Url(ErrorMessage = "{0} bevat geen geldige URL!!")]
        public string ImgUrl { get; set; }

        [Display(Name = "Thema's")]
        public Categorie Categorie { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        public VoorlopigeUitleningViewModel UitleningViewModel { get; set; }

        public SpelViewModel(Spel spel)
        {
            Id = spel.Id;
            Naam = spel.Naam;
            Beschrijving = spel.Beschrijving;
            Beschikbaar = spel.Beschikbaar;
            Leeftijd = spel.Leeftijd;
            ImgUrl = spel.ImgUrl;
            Categorie = spel.Categorie;
        }

        public SpelViewModel()
        {
            
        }
    }
}