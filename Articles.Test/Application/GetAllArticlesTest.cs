using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.Application.Articles.Query;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using Articles.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Articles.Test.Application
{
    public class GetAllArticlesTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ApplicationDbForGetAll").Options;

        [Fact]
        public async Task Handle_GetArticles()
        {

            using var context = new ApplicationDbContext(dbContextOptions);
            SeedDb.SeedData(context);



            var mock = new Mock<IArticleRepository>();
            mock.Setup(repo => repo.GetArticles()).Returns(context.Articles);

            var handler = new GetAllArticlesQueryHandler(mock.Object);

            var result = await handler.Handle(new GetAllArticlesQuery(), default);

            result.Should().BeOfType<List<Article>>();
            result.Should().HaveCount(5);
        }
    }
}
