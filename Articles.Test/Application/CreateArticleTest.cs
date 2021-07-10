using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.Application.Articles.Command;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using Articles.Infrastructure;
using Articles.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Articles.Test.Application
{
    public class CreateArticleTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ApplicationDbForCreate").Options;

        [Fact]
        public async Task Handle_CreateArticle_AddedToDatabase()
        {
            using var context = new ApplicationDbContext(dbContextOptions);
            SeedDb.SeedData(context);

            var mock = new Mock<IArticleRepository>();
            mock.Setup(repo => repo.CreateArticle(It.IsAny<Article>())).ReturnsAsync((Article article) => {

                context.Add(article);
                return context.SaveChanges() > 0;
            });

            var countAllArticlesBeforeAdd = context.Articles.Count();

           

            var handler = new CreateArticleCommandHandler(mock.Object);

            var result = await handler.Handle(new CreateArticleCommand() {Title = "Article6", Content = "Article6lalalal" }, default);

            var countAllArticlesAfterAdd = context.Articles.Count();

            countAllArticlesAfterAdd.Should().NotBe(countAllArticlesBeforeAdd);
            result.Should().Be(6);
        }
    }
}
