using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGraoOuro.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string senha { get; set; }
    }
}
