using APICatalogo.Context;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICatalogoxUnitTests.UnitTests
{
    public class ProdutosUnitTestController
    {
        public IUnitOfWork repository;
        public IMapper mapper;

        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=APICatalogo;Trusted_Connection=True;MultipleActiveResultSets=true";

        static ProdutosUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public ProdutosUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProdutoDTOMappingProfile());
            });

            mapper = config.CreateMapper();
            var context = new AppDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }   
    }
}
