using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories.Interfaces;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.UoW.Interfaces;
using tech_test_payment_api.ViewModels.Product;

namespace tech_test_payment_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnityOfWork _uow;
        private readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;

        public ProductService(IUnityOfWork uow, IProductRepository productRepository, IMapper mapper)
        {
            _uow = uow;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
            =>  _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());

        public async Task<ProductViewModel> GetById(Guid id)
            => _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));

        public async Task<ProductViewModel> Create(CreateProductViewModel createProductViewModel)
        {
            try
            {
                var createProduct = _mapper.Map<Product>(createProductViewModel);

                await _productRepository.Create(createProduct);

                await _uow.Commit();
                
                return _mapper.Map<ProductViewModel>(createProduct);                    
            }
            catch
            {       
                await _uow.Roolback();

                throw;
            }
        }

        public async Task<ProductViewModel> Update(UpdateProductViewModel updateProductViewModel)
        {
            try
            {
                var updateProduct = await _productRepository.GetById(updateProductViewModel.Id);

                if (updateProduct is null)
                    return null;
                
                updateProduct.Update(_mapper.Map<Product>(updateProductViewModel));

                _productRepository.Update(updateProduct);    

                await _uow.Commit();

                return _mapper.Map<ProductViewModel>(updateProduct);
            }
            catch
            {             
                await _uow.Roolback();   

                throw;
            }
        }

        public async Task<ProductViewModel> Delete(Guid id)
        {
            try
            {
                var deleteProduct = await _productRepository.GetById(id);

                if (deleteProduct is null)
                    return null;

                _productRepository.Delete(deleteProduct);

                await _uow.Commit();

                return _mapper.Map<ProductViewModel>(deleteProduct);
            }
            catch
            {                
                await _uow.Roolback();  

                throw;
            }
        }
    }
}