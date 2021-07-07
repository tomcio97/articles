using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.Application.Articles.Command;
using Articles.Application.Articles.Query;
using Articles.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Articles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IArticleRepository articleRepository;

        public ArticleController(IMediator mediator, IArticleRepository articleRepository)
        {
            this.mediator = mediator;
            this.articleRepository = articleRepository;
        }
        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var result = await mediator.Send(new GetAllArticlesQuery());


            return Ok(result);
        }

        // GET api/<ArticleController>/5
        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetArticleById(int articleId)
        {
            var result = await mediator.Send(new GetArticlesByIdQuery() { ArticleId = articleId });

            return Ok(result);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand article)
        {

           var result =  await mediator.Send(article);

            return Ok(result);
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
