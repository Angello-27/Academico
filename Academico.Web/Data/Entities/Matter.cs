namespace Academico.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Matter : IEntity
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Required]
        public string Name { get; set; }
    }
}
