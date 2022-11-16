using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.ViewModels.Seller;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface ISellerService
    {
        Task<SellerViewModel> GetById(Guid id);
        Task<IEnumerable<SellerViewModel>> GetAll();
        Task<SellerViewModel> Create(CreateSellerViewModel createSellerViewModel);
        Task<SellerViewModel> Update(UpdateSellerViewModel updateSellerViewModel);
        Task<SellerViewModel> Delete(Guid id);
    }
}