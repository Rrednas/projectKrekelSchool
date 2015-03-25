using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class LeerlingViewModel
    {
        public virtual Collection<Uitlening> Uitleningen { get; set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Naam { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Voornaam { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public LeerlingViewModel() { }

        public LeerlingViewModel(Lener leerling)
        {
            Id = leerling.Id;
            Naam = leerling.Naam;
            Voornaam = leerling.Voornaam;
        }
    }
}