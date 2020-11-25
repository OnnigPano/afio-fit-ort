using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIOFIT_NT1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UsuarioCurso> Cursos { set; get; }
    }
}
