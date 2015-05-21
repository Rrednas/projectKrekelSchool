﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class LeerlingScreenViewModel
    {
        public VoorlopigeUitleningViewModel Voorlopige { get; set; }
        public IEnumerable<LeerlingViewModel> Leners { get; set; }
        public User User { get; set; }

        public LeerlingScreenViewModel(VoorlopigeUitlening voorlopige, IEnumerable<LeerlingViewModel> obj,User user)
        {
            Voorlopige = new VoorlopigeUitleningViewModel(voorlopige.VoorlopigItem, voorlopige.VoorlopigeLener);
            Leners = obj;
            User = user;
        }
    }
}