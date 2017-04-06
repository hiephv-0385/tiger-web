using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TigerWeb.Models;
using TigerWeb.Repositories.Categories;

namespace TigerWeb.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController: Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categorysRepository)
        {
            _categoryRepository = categorysRepository;
        }

        // problems with cache
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpPost]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category newCategory = _categoryRepository.Add(category);

            return CreatedAtRoute("GetSingleCategory", new { id = newCategory.Id }, newCategory);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate(int id, [FromBody] JsonPatchDocument<Category> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            Category existingEntity = _categoryRepository.GetSingle(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            Category category = existingEntity;
            patchDoc.ApplyTo(category, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category updatedCategory = _categoryRepository.Update(id, category);

            return Ok(updatedCategory);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSingleCategory")]
        public IActionResult Single(int id)
        {
            Category category = _categoryRepository.GetSingle(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            Category category = _categoryRepository.GetSingle(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]Category category)
        {
            var categoryToCheck = _categoryRepository.GetSingle(id);

            if (categoryToCheck == null)
            {
                return NotFound();
            }

            if (id != category.Id)
            {
                return BadRequest("Ids do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category updatedCategory = _categoryRepository.Update(id, category);

            return Ok(updatedCategory);
        }
    }
}
