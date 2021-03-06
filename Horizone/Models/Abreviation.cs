﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Abreviation
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "Symbol", ResourceType = typeof(StaticResource.Resources))]
        public string Symbol { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [AllowHtml]
        [Display(Name = "Link", ResourceType = typeof(StaticResource.Resources))]
        public string Link { get; set; }

    }
}