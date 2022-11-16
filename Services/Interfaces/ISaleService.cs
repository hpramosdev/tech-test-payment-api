using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.ViewModels.Sale;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface ISaleService
    {
        Task<SaleViewModel> GetById(Guid id);
        Task<IEnumerable<SaleViewModel>> GetAll();
        Task<SaleViewModel> Create(CreateSaleViewModel createSaleViewModel);
        Task<SaleViewModel> UpdateSaleStatus(UpdateSaleViewModel updateSaleViewModel);
    }
}