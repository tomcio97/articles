using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain.Models;
using Articles.Infrastructure;

namespace Articles.Test.Application
{
    public static class SeedDb
    {
        public static void SeedData(ApplicationDbContext context)
        {
            var articles = new List<Article>()
            {
                {new Article() { ArticleId = 1, Title="Article1", Content="Article1dsada"}},
                {new Article() { ArticleId = 2, Title="Article2", Content="Article2dsada"}},
                {new Article() { ArticleId = 3, Title="Article3", Content="Article3dsada"}},
                {new Article() { ArticleId = 4, Title="Article4", Content="Article4dsada"}},
                {new Article() { ArticleId = 5, Title="Article5", Content="Article5dsada"}},
            };

            context.AddRange(articles);
            context.SaveChanges();
        }
    }
}
