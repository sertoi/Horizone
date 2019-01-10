﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Bibliography
    {
        public int Id { get; set; }

       
        [Display(Name = "Author", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(150, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Author { get; set; }


        
        [Display(Name = "PublicationDate", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(10, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string PublicationDate { get; set; }

        [AllowHtml]
        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Newspaper", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Journal { get; set; }

       
        [Display(Name = "Link", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string UlrBibliography { get; set; }
        
    }
}