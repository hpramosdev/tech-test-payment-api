using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModels.Product;

namespace tech_test_payment_api.Controllers
{
    [Route("products")]
    public class ProductController : BaseController
    {
        protected readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try            
            {
                var products = await _productService.GetAll();
                return Ok(products);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = "Erro ao obter os produtos." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.GetById(id);

                if (product is null)
                    return NotFound();

                return Ok(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao obter o produto." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel createProductViewModel)
        {
            try
            {
                var product = await _productService.Create(createProductViewModel);

                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao incluir o produto." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductViewModel updateProductViewModel)
        {
            try
            {
                var product = await _productService.Update(updateProductViewModel);

                if (product is null)
                    return NotFound();

                return Ok(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao alterar o produto." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var product = await _productService.Delete(id);

                if (product is null)
                    return NotFound();

                return Ok(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao excluir o produto." });            
            }
        }
    }
}