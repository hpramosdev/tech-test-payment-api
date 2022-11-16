using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories.Interfaces;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.UoW.Interfaces;
using tech_test_payment_api.ViewModels.Sale;

namespace tech_test_payment_api.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnityOfWork _uow;
        private readonly ISaleRepository _saleRepository;        
        private readonly ISellerRepository _sellerRepository;
        public readonly IMapper _mapper;

        public SaleService(IUnityOfWork uow, ISaleRepository saleRepository, ISellerRepository sellerRepository, IMapper mapper)
        {
            _uow = uow;
            _saleRepository = saleRepository;            
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaleViewModel>> GetAll()
        {
            var getSales = await _saleRepository.GetAll();

            foreach(var sale in getSales)
            {
                sale.Seller = await _sellerRepository.GetById(sale.SellerId);
            }            

            return _mapper.Map<IEnumerable<SaleViewModel>>(getSales);
        }

        public async Task<SaleViewModel> GetById(Guid id)
        {
            var getSale = await _saleRepository.GetById(id);

            getSale.Seller = await _sellerRepository.GetById(getSale.SellerId);

            return _mapper.Map<SaleViewModel>(getSale);
        }

        public async Task<SaleViewModel> Create(CreateSaleViewModel createSaleViewModel)
        {
            try
            {
                var createSale = _mapper.Map<Sale>(createSaleViewModel);

                await _saleRepository.Create(createSale);                      

                await _uow.Commit();                
                
                return _mapper.Map<SaleViewModel>(await GetById(createSale.Id));                    
            }
            catch
            {       
                await _uow.Roolback();

                throw;
            }
        }

        public async Task<SaleViewModel> UpdateSaleStatus(UpdateSaleViewModel updateSaleViewModel)
        {
            try
            {
                var updateSale = await _saleRepository.GetById(updateSaleViewModel.Id);

                if (updateSale is null)
                    return null;
                
                updateSale.UpdateSaleStatus(updateSaleViewModel.Status);

                _saleRepository.Update(updateSale);    

                await _uow.Commit();                

                return _mapper.Map<SaleViewModel>(await GetById(updateSale.Id));           
            }
            catch
            {       
                await _uow.Roolback();

                throw;
            }
        }
    }
}