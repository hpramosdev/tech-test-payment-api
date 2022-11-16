using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories.Interfaces;
using tech_test_payment_api.Services.Interfaces;
using tech_test_payment_api.UoW.Interfaces;
using tech_test_payment_api.ViewModels.Seller;

namespace tech_test_payment_api.Services
{
public class SellerService : ISellerService
    {
        private readonly IUnityOfWork _uow;
        private readonly ISellerRepository _sellerRepository;
        public readonly IMapper _mapper;

        public SellerService(IUnityOfWork uow, ISellerRepository sellerRepository, IMapper mapper)
        {
            _uow = uow;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SellerViewModel>> GetAll()
            =>  _mapper.Map<IEnumerable<SellerViewModel>>(await _sellerRepository.GetAll());

        public async Task<SellerViewModel> GetById(Guid id)
            => _mapper.Map<SellerViewModel>(await _sellerRepository.GetById(id));

        public async Task<SellerViewModel> Create(CreateSellerViewModel createSellerViewModel)
        {
            try
            {
                var createSeller = _mapper.Map<Seller>(createSellerViewModel);

                await _sellerRepository.Create(createSeller);

                await _uow.Commit();
                
                return _mapper.Map<SellerViewModel>(createSeller);                    
            }
            catch
            {       
                await _uow.Roolback();

                throw;
            }
        }

        public async Task<SellerViewModel> Update(UpdateSellerViewModel updateSellerViewModel)
        {
            try
            {
                var updateSeller = await _sellerRepository.GetById(updateSellerViewModel.Id);

                if (updateSeller is null)
                    return null;
                
                updateSeller.Update(_mapper.Map<Seller>(updateSellerViewModel));

                _sellerRepository.Update(updateSeller);    

                await _uow.Commit();

                return _mapper.Map<SellerViewModel>(updateSeller);
            }
            catch
            {             
                await _uow.Roolback();   

                throw;
            }
        }

        public async Task<SellerViewModel> Delete(Guid id)
        {
            try
            {
                var deleteSeller = await _sellerRepository.GetById(id);

                if (deleteSeller is null)
                    return null;

                _sellerRepository.Delete(deleteSeller);

                await _uow.Commit();

                return _mapper.Map<SellerViewModel>(deleteSeller);
            }
            catch
            {                
                await _uow.Roolback();  

                throw;
            }
        }
    }
}