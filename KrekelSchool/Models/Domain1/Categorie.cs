using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrekelSchool.Models.Domain1
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Thema")]
        public string Beschrijving { get; set; }

        public Categorie(string beschrijving)
        {
            Beschrijving = beschrijving;
        }

        public Categorie()
        {
            
        }
    }
}

