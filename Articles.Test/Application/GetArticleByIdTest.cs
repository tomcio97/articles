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
    public class GetArticleByIdTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ApplicationDbForGetById").Options;
        [Fact]
        public async Task Handle_GetArticleById_ExistArticle()
        {
            using var context = new ApplicationDbContext(dbContextOptions);
            SeedDb.SeedData(context);

            var defualtId = 1;
            var mock = new Mock<IArticleRepository>();
            mock.Setup(repo => repo.GetArticleById(defualtId)).Returns(context.Articles.FirstOrDefaultAsync(x => x.ArticleId == defualtId));

            var handler = new GetArticlesByIdQueryHandler(mock.Object);

            var result = await handler.Handle(new GetArticlesByIdQuery() { ArticleId = defualtId }, default);

            result.Should().BeOfType<Article>();
            result.ArticleId.Should().Be(defualtId);
            result.Content.Should().Be("Article1dsada");
        }

        [Fact]
        public async Task Handle_GetArticleById_NotExistArticle()
        {
            using var context = new ApplicationDbContext(dbContextOptions);

            var defualtId = 999;
            var mock = new Mock<IArticleRepository>();
            mock.Setup(repo => repo.GetArticleById(defualtId)).Returns(context.Articles.FirstOrDefaultAsync(x => x.ArticleId == defualtId));

            var handler = new GetArticlesByIdQueryHandler(mock.Object);

            var result = await handler.Handle(new GetArticlesByIdQuery() { ArticleId = defualtId }, default);

            result.Should().BeNull();
        }
    }
}
