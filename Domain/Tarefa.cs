using System.Collections.Generic;

namespace Domain
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Completa { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; }

    }
}