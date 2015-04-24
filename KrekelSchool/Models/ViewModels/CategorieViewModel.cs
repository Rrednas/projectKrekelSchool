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
    public class CategorieViewModel
    {
        public virtual Collection<Categorie> Categorien { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Beschrijving verplicht")]
        public string Beschrijving { get; set; }

        public CategorieViewModel()
        {
            
        }

        public CategorieViewModel(Categorie categorie)
        {
            Id = categorie.Id;
            Beschrijving = categorie.Beschrijving;
        }
    }
}