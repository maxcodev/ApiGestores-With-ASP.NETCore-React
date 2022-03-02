using System.ComponentModel.DataAnnotations;

namespace ApiGestores.Models
{
    public class GestoresBd
    {
        [Key]
        public int Id  { get; set; }
        [StringLength(50)] 
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public int Lanzamiento { get; set; }
        [Required(ErrorMessage = "El Desarrollador es Requerido")]
        public string Desarrollador { get; set; }
    }
}