using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            var result = _categoryBLL.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public CategoryDTO GetById(int id)
        {
            var getID = _categoryBLL.GetById(id);
            if (getID == null)
            {
                throw new ArgumentException($"Not found {id}");
            }
            return getID;
        }

        [HttpGet("GetByName")]
        public IEnumerable<CategoryDTO> GetByName(string name)
        {
            var getbyname = _categoryBLL.GetByName(name);
            return getbyname;
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id)
        {
            var getcateg = _categoryBLL.GetById(id);
            if (getcateg == null)
            {
                throw new ArgumentException($"Not found {id}");
            }
            _categoryBLL.Delete(id);
            return Ok($"Data Category ID: {id} berhasil didelete");
        }

        [HttpPut("{id}")]
        public IActionResult Put(CategoryUpdateDTO category)
        {
            var getcateg = _categoryBLL.GetById(category.CategoryID);
            if (getcateg == null)
            {
                return NotFound();
            }
            _categoryBLL.Update(category);
            return Ok($"Data Category {category.CategoryID} berhasil diupdate !");
        }
        [HttpPost]
        public IActionResult Post(CategoryCreateDTO category)
        {
            _categoryBLL.Insert(category);
            return Ok($"Data Category {category.CategoryName} berhasil diupdate !");

        }
    }
}