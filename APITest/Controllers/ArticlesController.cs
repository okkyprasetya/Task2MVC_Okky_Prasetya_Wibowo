using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;
        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }
        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            var results = _articleBLL.GetArticleWithCategory();
            return results;
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public ActionResult<ArticleDTO> GetById(int id)
        {
            var article = _articleBLL.GetArticleById(id);
            if (article == null)
            {
                return NotFound($"CategoryID {id} not found!");
            }
            return Ok(article);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public IActionResult Insert(ArticleCreateDTO articleCreate)
        {
            _articleBLL.Insert(articleCreate);
            return Ok($"article {articleCreate.Title} berhasil ditambahkan");
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ArticleUpdateDTO article)
        {
            var results = _articleBLL.GetArticleById(id);
            _articleBLL.Update(article);


            return Ok($"article {id} berhasil diupdate");
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleBLL.Delete(id);
            return Ok($"article ID : {id} berhasil dihapus");
        }
    }
}