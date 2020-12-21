using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        public readonly RepositoryContext _context;
        public TarefaRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async void Add(Tarefa tarefa)
        {
           _context.Add(tarefa);

           await _context.SaveChangesAsync();
        }

        public async void Delete(Tarefa tarefa)
        {
            _context.Remove(tarefa);

            await _context.SaveChangesAsync();
        }

        public async  void Update(Tarefa tarefa)
        {
            _context.Update(tarefa);

            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa> GetTarefaAsyncById(int tarefaId)
        {
            IQueryable<Tarefa> query = _context.Tarefa.AsNoTracking()
                .Where(x => x.TarefaId == tarefaId );

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tarefa[]> GetTarefaAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Tarefa> query = _context.Tarefa.AsNoTracking()
                .Where(x => x.UsuarioId == usuarioId);

            return await query.ToArrayAsync();
        }

        public async Task<Tarefa[]> GetTarefasAsync()
        {
            IQueryable<Tarefa> query = _context.Tarefa.AsNoTracking();

            return await query.ToArrayAsync();
               
        }

        
    }
}
