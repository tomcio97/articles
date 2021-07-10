using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain.Models;

namespace Articles.Domain.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetArticles();
        Task<Article> GetArticleById(int articleId);
        Task<bool> CreateArticle(Article article);
        Task<bool> DeleteArticle(Article article);
    }
}
