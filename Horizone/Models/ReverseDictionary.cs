﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ReverseDictionary
    {
        public int Id { get; set; }

        [Display(Name = "Words", ResourceType = typeof(StaticResource.Resources))]
        public string Word { get; set; }

        [Display(Name = "Symbol", ResourceType = typeof(StaticResource.Resources))]
        public string SymbolPrefix { get; set; }


        [Display(Name = "Reverse", ResourceType = typeof(StaticResource.Resources))]
        public string ReverseWord { get; set; }

        [Display(Name = "Symbol", ResourceType = typeof(StaticResource.Resources))]
        public string SymbolSufix { get; set; }

    }
}