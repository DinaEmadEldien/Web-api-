using ApiProjectTest.Models;
using ApiProjectTest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryRepository;
        public CategoryController(ICategory categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> catList=categoryRepository.GetAll();

            if (catList == null)
            {
                return BadRequest("Empty category");
            }
            return Ok(catList);
        }

        [HttpGet("{id:int}", Name = "getOneRoute")]
        public IActionResult getByID(int id)
        {
            Category category = categoryRepository.GetById(id);
            if (category == null)
            {
                return BadRequest("Empty category");
            }
            return Ok(category);
        }


        [Authorize]
        [HttpPost]
        public IActionResult insert(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.insert(category);
                    string url = Url.Link("getOneRoute", new { id = category.id });
                    return Created(url, category);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [Authorize]
        [HttpPut("{id:int}")]
        public IActionResult update(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.update(id, category);

                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

        ///self////////////////////////////////////////
        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.delete(id);

                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
    } 
}
