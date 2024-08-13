using APICatalogo.Controllers;
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
            var produtoId = 2;

            // Act
            var data = await _controller.Get(produtoId);

            // Assert
            data.Result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(200); 
        }   
    }
}
