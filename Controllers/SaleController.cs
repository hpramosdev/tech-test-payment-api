using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.ViewModels.Sale;

namespace tech_test_payment_api.Controllers
{
    [Route("sales")]
    public class SaleController : BaseController
    {
        protected readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;

        public SaleController(ILogger<SaleController> logger, ISaleService saleService)
        {
            _logger = logger;
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try            
            {
                var sales = await _saleService.GetAll();
                return Ok(sales);
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
                var sale = await _saleService.GetById(id);

                if (sale is null)
                    return NotFound();

                return Ok(sale);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao obter o produto." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleViewModel createSaleViewModel)
        {
            try
            {
                var sale = await _saleService.Create(createSaleViewModel);

                return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao incluir o produto." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSaleViewModel updateSaleViewModel)
        {
            try
            {
                var sale = await _saleService.UpdateSaleStatus(updateSaleViewModel);

                if (sale is null)
                    return NotFound();

                if (sale.Status != updateSaleViewModel.Status)
                    return BadRequest("Erro ao atualizar o Status da venda.");

                return Ok(sale);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { message = $"Erro ao alterar o produto." });
            }
        }
    }
}