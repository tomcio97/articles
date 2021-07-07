using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Dtos
{
    public class GetArticleDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
