using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class GebruikerViewModel
    {
        [Display(Name = "Gebruikersnaam")]
        public string Uname { get; set; }
        public string Pswd { get; set; }
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Naam { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }

        public GebruikerViewModel()
        {
            
        }

        public GebruikerViewModel(Gebruiker gebruiker)
        {
            Uname = gebruiker.Uname;
            Pswd = gebruiker.Pswd;
            Naam = gebruiker.Naam;
            Id = gebruiker.Id;
        }
    }
}