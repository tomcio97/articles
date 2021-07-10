using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Articles.Domain.Interfaces.Repositories;
using Articles.Domain.Models;
using MediatR;

namespace Articles.Application.Articles.Command
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IArticleRepository articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new Article()
            {
                Title = request.Title,
                Content = request.Content
            };

             await articleRepository.CreateArticle(article);

            return article.ArticleId;
        }
    }
}
