using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ProdutosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("produtos/{id}")]
    public ActionResult <IEnumerable<Produto>> GetProdutosCategoria(int id)
    {
        var produtos = _unitOfWork.ProdutoRepository.GetProdutosPorCategoria(id);
        if (produtos is null)
        {
            return NotFound();
        }
        return Ok(produtos);    
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _unitOfWork.ProdutoRepository.GetAll().ToList();
        if (produtos is null)
        {
            return NotFound();
        }
        return Ok(produtos);
    }

    [HttpGet("{id}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.Get(c=> c.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado...");
        }
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("ObterProduto",
            new { id = novoProduto.ProdutoId }, novoProduto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest();
        }

        var produtoAtualizado = _unitOfWork.ProdutoRepository.Update(produto);
        _unitOfWork.Commit();

       return Ok(produtoAtualizado);

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
       var produto = _unitOfWork.ProdutoRepository.Get(p=> p.ProdutoId == id);
        if(produto is null)
        {
            return NotFound("Produto não encontrado");
        }
        var produtoExcluido = _unitOfWork.ProdutoRepository.Delete(produto);
        _unitOfWork.Commit();

        return Ok(produtoExcluido);
    }
}