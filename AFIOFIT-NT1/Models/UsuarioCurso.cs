using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFIOFIT_NT1.Models
{
    public class UsuarioCurso
    {
        [Key]
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
