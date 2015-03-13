﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.ViewModels
{
    public class UitleningViewModel
    {
        public UitleningViewModel(Uitlening uitlening)
        {
            Item = uitlening.Item;
            BeginDatum = uitlening.BeginDatum;
            EindDatum = uitlening.EindDatum;
            IsTerug = uitlening.IsTerug;
        }
        public Item Item { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool IsTerug { get; set; }
    }
}