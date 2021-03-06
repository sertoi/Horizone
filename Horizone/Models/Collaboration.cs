﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Collaboration
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Title", ResourceType = typeof(StaticResource.Resources))]       
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "LastName", ResourceType = typeof(StaticResource.Resources))]      
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "FirstName", ResourceType = typeof(StaticResource.Resources))]
        public string FirstName { get; set; }

        [AllowHtml]
        [Display(Name ="Fonction", ResourceType = typeof(StaticResource.Resources))]
        public string FonctionEn { get; set; }
        [AllowHtml]
        [Display(Name = "Fonction", ResourceType = typeof(StaticResource.Resources))]
        public string FonctionFr { get; set; }
        [AllowHtml]
        [Display(Name = "Fonction", ResourceType = typeof(StaticResource.Resources))]
        public string FonctionZh { get; set; }

        [AllowHtml]
        [Display(Name = "Affiliation", ResourceType = typeof(StaticResource.Resources))]
        public string AffiliationFr { get; set; }
        [AllowHtml]
        [Display(Name = "Affiliation", ResourceType = typeof(StaticResource.Resources))]
        public string AffiliationEn { get; set; }
        [AllowHtml]
        [Display(Name = "Affiliation", ResourceType = typeof(StaticResource.Resources))]
        public string AffiliationZh { get; set; }

        [Display(Name = "CVName")]
        public string CV { get; set; }

        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]        
        public string Email { get; set; }

        [Display(Name = "Publications", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Publication> Publications { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]        
        public ICollection<ImageCollaboration> ImageCollaborations { get; set; }

        [Display(Name = "Team", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Team { get; set; }

        [Display(Name = "AssociatedResearcher", ResourceType = typeof(StaticResource.Resources))]
        public Boolean AssociatedResearcher { get; set; }

        [Display(Name = "Collaborator", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Collaborator { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

        [Display(Name = "Order", ResourceType = typeof(StaticResource.Resources))]
        public int Order { get; set; }
    }
}