using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITarefaRepository
    {
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);

        Task<Tarefa[]> GetTarefasAsync();
        Task<Tarefa> GetTarefaAsyncById(int tarefaId);
        Task<Tarefa[]> GetTarefaAsyncByUsuarioId(int usuarioId);

    }
}
