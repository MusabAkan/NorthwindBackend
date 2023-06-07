using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("get")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

    }
}
