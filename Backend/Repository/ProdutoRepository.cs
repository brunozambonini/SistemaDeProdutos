using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly getwayContext _context;

        public ProdutoRepository(getwayContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Produto[]> GetProdutosByName(string name)
        {
            IQueryable<Produto> query = _context.Produtos;
 
            query = query.AsNoTracking()
                .Where(p => p.Nome.Contains(name))
                .OrderBy(p => p.Id);


            return await query.ToArrayAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Produto[]> GetAll(string term, int page, int pageSize)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking()
                .Where(x => x.Nome.Contains(term));

            int qtdProdutos = query.Count();
            int qunatidadePaginas = Convert.ToInt32(Math.Ceiling(qtdProdutos * 1M / pageSize));

            if (page > qunatidadePaginas)
            {
                return null;
            }

            // Pula uma qunatidade de registros de acordo com a pagina
            // Se for a primeira página, pega os primeiros registros, se for a segunda, pula as primeiras que foi pego na primeira página...
            query = query.Skip(pageSize * (page - 1)).Take(pageSize);
            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllSemFiltro()
        {
            IQueryable<Produto> query = _context.Produtos;

            return await query.ToArrayAsync();
        }
    }
}
