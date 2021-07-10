using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Articles.Application.Articles.Command
{
    public class CreateArticleCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
