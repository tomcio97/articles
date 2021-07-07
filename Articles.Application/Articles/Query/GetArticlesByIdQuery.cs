using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Domain.Models;
using MediatR;

namespace Articles.Application.Articles.Query
{
    public class GetArticlesByIdQuery : IRequest<Article> // tutaj powinno być DTO
    {
        public int ArticleId { get; set; }
    }
}
