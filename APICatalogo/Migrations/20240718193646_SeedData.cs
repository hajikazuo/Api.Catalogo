using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Categorias",
            columns: new[] { "CategoriaId", "Nome", "ImagemUrl" },
            values: new object[,]
            {
                { 1, "Eletrônicos", "eletronicos.jpg" },
                { 2, "Roupas", "roupas.jpg" },
                { 3, "Alimentos", "alimentos.jpg" }
            });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Nome", "Descricao", "Preco", "ImagemUrl", "Estoque", "DataCadastro", "CategoriaId" },
                values: new object[,]
                {
                { 1, "TV", "Televisor 50 polegadas", 2500m, "tv.jpg", 10f, DateTime.Now, 1 },
                { 2, "Laptop", "Laptop com 16GB RAM", 3500m, "laptop.jpg", 20f, DateTime.Now, 1 },
                { 3, "Camiseta", "Camiseta de algodão", 50m, "camiseta.jpg", 100f, DateTime.Now, 2 },
                { 4, "Calça", "Calça jeans", 80m, "calca.jpg", 50f, DateTime.Now, 2 },
                { 5, "Arroz", "Pacote de 5kg de arroz", 20m, "arroz.jpg", 200f, DateTime.Now, 3 },
                { 6, "Feijão", "Pacote de 1kg de feijão", 10m, "feijao.jpg", 150f, DateTime.Now, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Produtos",
            keyColumn: "ProdutoId",
            keyValues: new object[] { 1, 2, 3, 4, 5, 6 });

            migrationBuilder.DeleteData(
            table: "Categorias",
            keyColumn: "CategoriaId",
            keyValues: new object[] { 1, 2, 3 });
        }
    }
}
