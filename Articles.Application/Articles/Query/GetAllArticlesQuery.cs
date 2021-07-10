using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Articles.Domain.Models;

namespace Articles.Application.Articles.Query
{
    public class GetAllArticlesQuery : IRequest<List<Article>> // zamiast Article powinno być jakieś DTO
    {
    }
}
