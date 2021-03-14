using Backend.Models;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IProdutoRepository
    {
        //passar qualquer entidade de qualquer tipo
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Produto> GetProdutoById(int id);
        Task<Produto[]> GetProdutosByName(string name);
        Task<Produto[]> GetAll(string term, int tamanhoPagina, int paginaAtual);
        Task<Produto[]> GetAllSemFiltro();
    }   
}
