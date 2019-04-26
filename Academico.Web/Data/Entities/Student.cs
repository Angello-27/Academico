namespace Academico.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;    

    public class Student
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Image") ]
        public string ImageUrl { get; set; }

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

    }
}
