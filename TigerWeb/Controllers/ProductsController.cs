using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tiger.Data.Entities;
using Tiger.Data.Repositories.Products;

namespace TigerWeb.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController: Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // problems with cache
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpPost]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product newProduct = _productRepository.Add(product);

            return CreatedAtRoute("GetSingleProduct", new { id = newProduct.Id }, newProduct);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            Product existingEntity = _productRepository.GetSingle(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            Product product = existingEntity;
            patchDoc.ApplyTo(product, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedProduct = _productRepository.Update(id, product);

            return Ok(updatedProduct);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSingleProduct")]
        public IActionResult Single(int id)
        {
            Product product = _productRepository.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            Product product = _productRepository.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]Product product)
        {
            var productToCheck = _productRepository.GetSingle(id);

            if (productToCheck == null)
            {
                return NotFound();
            }

            if (id != product.Id)
            {
                return BadRequest("Ids do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product updatedProduct = _productRepository.Update(id, product);

            return Ok(updatedProduct);
        }
    }
}
