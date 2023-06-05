using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _CategoryService;

        public CategoriesController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _CategoryService.GetList();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        
        [HttpGet("get")]
        public IActionResult GetById(int CategoryId)
        {
            var result = _CategoryService.GetById(CategoryId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Category Category)
        {
            var result = _CategoryService.Add(Category);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Category Category)
        {
            var result = _CategoryService.Update(Category);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Category Category)
        {
            var result = _CategoryService.Delete(Category);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

    }
}
