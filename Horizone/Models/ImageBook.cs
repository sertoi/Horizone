﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ImageBook
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public byte[] Content { get; set; }

        [Display(Name = "Book", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int BibliographyId { get; set; }

        [ForeignKey("BibliographyId")]
        public Bibliography Bibliography { get; set; }
    }
}