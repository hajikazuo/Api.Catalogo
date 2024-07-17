using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Linq;
using X.PagedList;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IPagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParams);
        Task<IPagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtosFiltroParams);
        Task <IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);
    }
}
