using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public readonly RepositoryContext _context;
        public UsuarioRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async void Add(Usuario usuario)
        {
            _context.Add(usuario);

            await _context.SaveChangesAsync();
        }
        public async void Update(Usuario usuario)
        {
            _context.Update(usuario);

            await _context.SaveChangesAsync();
        }

        public async void Delete(Usuario usuario)
        {
            _context.Remove(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task<Usuario[]> GetAsyncAll()
        {
            IQueryable<Usuario> query = _context.Usuario.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuario.AsNoTracking()
                 .Where(x => x.UsuarioId == usuarioId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
