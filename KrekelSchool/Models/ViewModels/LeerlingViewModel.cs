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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Naam { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Voornaam { get; set; }


        public string Straat { get; set; }

        [Display(Name = "Huis nr.")]
        public string HuisNr { get; set; }

        [StringLength(4, ErrorMessage = "Postcode heeft maximaal 4 characters!!")]
        public string Postcode { get; set; }
        public string Gemeente { get; set; }

        [Display(Name = "Email adres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0} is niet correct!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Klas is verplicht!!")]
        [StringLength(3, ErrorMessage = "Klas heeft maximaal 3 characters!!")]
        public string Klas { get; set; }


        public LeerlingViewModel() { }

        public LeerlingViewModel(Lener leerling)
        {
            Id = leerling.Id;
            Naam = leerling.Naam;
            Voornaam = leerling.Voornaam;
            Straat = leerling.Straat;
            HuisNr = leerling.HuisNr;
            Postcode = leerling.Postcode;
            Gemeente = leerling.Gemeente;
            Email = leerling.Email;
            Klas = leerling.Klas;
        }
    }
}