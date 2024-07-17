using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;
using X.PagedList;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams)
    {
        var categorias = await GetAllAsync();

        var categoriaOrdenadas = categorias.OrderBy(p => p.CategoriaId).AsQueryable();

        //var resultado = PagedList<Categoria>.ToPagedList(categoriaOrdenadas, categoriasParams.PageNumber,
        //    categoriasParams.PageSize);

        var resultado = await categoriaOrdenadas.ToPagedListAsync(categoriasParams.PageNumber, categoriasParams.PageSize);

        return resultado;
    }

    public async Task<IPagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams)
    {
        var categorias = await GetAllAsync();

        if (!string.IsNullOrEmpty(categoriasParams.Nome))
        {
            categorias = categorias.Where(p => p.Nome.Contains(categoriasParams.Nome));
        }

        //var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias.AsQueryable(), categoriasParams.PageNumber,
        //    categoriasParams.PageSize);

        var categoriasFiltradas = await categorias.ToPagedListAsync(categoriasParams.PageNumber, categoriasParams.PageSize);

        return categoriasFiltradas;
    }
}
