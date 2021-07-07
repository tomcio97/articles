﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ArticleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateArticle(Article article)
        {
            dbContext.Add(article);

            await dbContext.SaveChangesAsync();

        }

        public async Task<bool> DeleteArticle(Article article)
        {
            dbContext.Remove(article);

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Article> GetArticleById(int articleId)
        {
            return await dbContext.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
        }

        public IQueryable<Article> GetArticles()
        {
            return dbContext.Articles;
        }
    }
}
