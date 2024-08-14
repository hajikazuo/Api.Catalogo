using APICatalogo.Controllers;
using APICatalogo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APICatalogoxUnitTests.UnitTests
{
    public class DeleteProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProdutosController _controller;

        public DeleteProdutoUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProdutosController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task DeleteProdutoById_Return_OkResult()
        {
            //Arrange
            var produtoId = 13;

            //Act
            var result = await _controller.Delete(produtoId);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();       
        }

        [Fact]
        public async Task DeleteProdutoById_Return_NotFound()
        {
            //Arrange
            var produtoId = 999;

            //Act
            var result = await _controller.Delete(produtoId);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
