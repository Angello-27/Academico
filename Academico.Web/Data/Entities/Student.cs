﻿namespace Academico.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;    

    public class Student
    {
        public int Id { get; set; }
        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Image") ]
        public string ImageUrl { get; set; }

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

    }
}