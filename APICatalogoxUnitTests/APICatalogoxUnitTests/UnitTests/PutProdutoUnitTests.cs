using APICatalogo.Controllers;
using APICatalogo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICatalogoxUnitTests.UnitTests
{
    public class PutProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public PutProdutoUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProdutosController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task PutProduto_Return_OkResult()
        {
            //Arrange

            var prodId = 1;

            var updateProdutoDto = new ProdutoDTO
            {
                ProdutoId = prodId,
                Nome = "Produto Atualizado",
                Descricao = "Descrição do Produto Teste",
                Preco = 10.99m,
                ImagemUrl = "http://teste.com/1.jpg",
                CategoriaId = 2
            };

            // Act
            var result = await _controller.Put(prodId, updateProdutoDto) as ActionResult<ProdutoDTO>;

            //Assert
            result.Should().NotBeNull();  
            result.Result.Should().BeOfType<OkObjectResult>();  

        }

        [Fact]
        public async Task PutProduto_Return_BadRequest()
        {
            //Arrange

            var prodId = 1000;

            var updateProdutoDto = new ProdutoDTO
            {
                ProdutoId = 14,
                Nome = "Produto Atualizado",
                Descricao = "Descrição do Produto Teste",
                Preco = 10.99m,
                ImagemUrl = "http://teste.com/1.jpg",
                CategoriaId = 2
            };

            // Act
            var result = await _controller.Put(prodId, updateProdutoDto);

            //Assert
            result.Result.Should().BeOfType<BadRequestResult>().Which.StatusCode.Should().Be(400);

        }
    }
}
