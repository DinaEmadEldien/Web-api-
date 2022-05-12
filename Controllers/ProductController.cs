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
    public class ProductController : ControllerBase
    {
        private readonly IProduct productRepository;
        public ProductController(IProduct productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> prodList = productRepository.GetAll();

            if (prodList == null)
            {
                return BadRequest("Empty product");
            }
            return Ok(prodList);
        }


        [HttpGet("{id:int}", Name = "getOneRoutep")]
        public IActionResult getByID(int id)
        {
            Product product = productRepository.GetById(id);
            if (product == null)
            {
                return BadRequest("Empty product");
            }
            return Ok(product);
        }

        [HttpGet("AnyThing/{CategoryID:int}")]
        public IActionResult getByCategoryID(int CategoryID)
        {
            List<Product> prodtList = productRepository.GetByCatogeryID(CategoryID);
            if (prodtList == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(prodtList);

        }


        [Authorize]
        [HttpPost]
        public IActionResult insert(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.insert(product);
                    string url = Url.Link("getOneRoutep", new { id = product.id });
                    return Created(url, product);
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
        public IActionResult update(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.update(id, product);

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
                    productRepository.delete(id);

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
