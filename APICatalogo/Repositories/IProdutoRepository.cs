using APICatalogo.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Linq;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
