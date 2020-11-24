using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFIOFIT_NT1.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        public Boolean Disponible { get; set; }
        public double Descuento { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
    }
}
