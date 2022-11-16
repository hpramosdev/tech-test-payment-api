using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.ViewModels.Product;

namespace tech_test_payment_api.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> Create(CreateProductViewModel createProductViewModel);
        Task<ProductViewModel> Update(UpdateProductViewModel updateProductViewModel);
        Task<ProductViewModel> Delete(Guid id);
    }
}