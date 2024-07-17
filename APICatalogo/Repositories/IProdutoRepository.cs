using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Linq;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);
        PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtosFiltroParams);
        IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
