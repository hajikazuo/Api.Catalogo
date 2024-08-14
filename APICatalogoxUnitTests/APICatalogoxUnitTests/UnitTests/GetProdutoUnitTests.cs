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
    public class GetProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public GetProdutoUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProdutosController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task GetProdutoById_OKResult()
        {
            // Arrange
            var produtoId = 1;

            // Act
            var data = await _controller.Get(produtoId);

            // Assert
            data.Result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(200); 
        }

        [Fact]
        public async Task GetProdutoById_Return_NotFound()
        {
            // Arrange
            var produtoId = 999;

            // Act
            var data = await _controller.Get(produtoId);

            // Assert
            data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetProdutoById_Return_BadRequest()
        {
            // Arrange
            var produtoId = -1;

            // Act
            var data = await _controller.Get(produtoId);

            // Assert
            data.Result.Should().BeOfType<BadRequestObjectResult>()
            .Which.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetProdutos_Return_ListProdutoDTO()
        {
            // Act
            var data = await _controller.Get();

            // Assert
            data.Result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeAssignableTo<IEnumerable<ProdutoDTO>>()
            .And.NotBeNull();
        }
    }
}
