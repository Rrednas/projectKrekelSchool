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

        public ICollection<Categorie> Categories { get; set; }

        public SpelViewModel(Spel item)
        {
            Id = item.Id;
            Naam = item.Naam;
            Beschrijving = item.Beschrijving;
            Beschikbaar = item.Beschikbaar;
            Leeftijd = item.Leeftijd;
        }

        public SpelViewModel()
        {
            
        }
    }
}