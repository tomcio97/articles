using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Articles.Application.Exceptions;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using MediatR;

namespace Articles.Application.Articles.Query
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, Article>
    {
        private readonly IArticleRepository articleRepository;

        public GetArticlesByIdQueryHandler(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<Article> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
           var result =  await articleRepository.GetArticleById(request.ArticleId);

            if(result is null)
            {
                throw new NotFoundException("Not found");
            }

            return result;
        }
    }
}
