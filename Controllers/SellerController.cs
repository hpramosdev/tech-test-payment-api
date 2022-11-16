using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModels.Seller;


namespace tech_test_payment_api.Controllers
{
    [Route("sellers")]
    public class SellerController : BaseController
    {
        protected readonly ILogger<SellerController> _logger;
        private readonly ISellerService _sellerService;

        public SellerController(ILogger<SellerController> logger, ISellerService sellerService)
        {
            _logger = logger;
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try            
            {
                var sellers = await _sellerService.GetAll();
                return Ok(sellers);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = "Erro ao obter os vendedores." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var seller = await _sellerService.GetById(id);

                if (seller is null)
                    return NotFound();

                return Ok(seller);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao obter o vendedor." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSellerViewModel createSellerViewModel)
        {
            try
            {
                var seller = await _sellerService.Create(createSellerViewModel);

                return CreatedAtAction(nameof(GetById), new { id = seller.Id }, seller);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao incluir o vendedor." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSellerViewModel updateSellerViewModel)
        {
            try
            {
                var seller = await _sellerService.Update(updateSellerViewModel);

                if (seller is null)
                    return NotFound();

                return Ok(seller);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao alterar o vendedor." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var seller = await _sellerService.Delete(id);

                if (seller is null)
                    return NotFound();

                return Ok(seller);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao excluir o vendedor." });            
            }
        }    
    }
}