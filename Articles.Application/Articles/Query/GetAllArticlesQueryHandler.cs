using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Articles.Application.Articles.Query
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<Article>>
    {
        private readonly IArticleRepository articleRepository;

        public GetAllArticlesQueryHandler(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<List<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await articleRepository.GetArticles().ToListAsync();

            return articles;
        }
    }
}
