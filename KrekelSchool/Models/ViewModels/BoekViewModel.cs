﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class BoekViewModel 
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get;  set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public string Naam { get;  set; }

        [Display(Name = "Beschrijving")]
        public string Beschrijving { get;  set; }

        [Display(Name = "Beschikbaar")]
        public bool Beschikbaar { get;  set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "{0} mag niet 0 of negatief zijn!!")]
        [Required(ErrorMessage = "{0} is verplicht!!")]
        public int Leeftijd { get;  set; }
        
        [Display(Name = "Afbeelding URL")]
        [Url(ErrorMessage = "{0} bevat geen geldige URL!!")]
        public string ImgUrl { get;  set; }

        [Display(Name = "ISBN-nummer")]
        public string Isbn { get; set; }

        public string Auteur { get; set; }
        public string Uitgever { get; set; }
       
        [Display(Name = "Thema's")]
        public Categorie Categorie { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        public VoorlopigeUitleningViewModel UitleningViewModel { get; set; }


        public BoekViewModel(Boek boek)
        {
            Id = boek.Id;
            Naam = boek.Naam;
            Beschrijving = boek.Beschrijving;
            Beschikbaar = boek.Beschikbaar;
            Leeftijd = boek.Leeftijd;
            ImgUrl = boek.ImgUrl;
            Isbn = boek.Isbn;
            Auteur = boek.Auteur;
            Uitgever = boek.Uitgever;
            Categorie = boek.Categorie;
        }


        public BoekViewModel()
        {
        }
        
    }
}