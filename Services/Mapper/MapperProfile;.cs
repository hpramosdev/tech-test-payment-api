using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tech_test_payment_api.Models;
using tech_test_payment_api.ViewModels.Product;
using tech_test_payment_api.ViewModels.Sale;
using tech_test_payment_api.ViewModels.SaleItem;
using tech_test_payment_api.ViewModels.Seller;

namespace tech_test_payment_api.Services.Mapper
{
 public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<UpdateProductViewModel, Product>();

            CreateMap<Seller, SellerViewModel>().ReverseMap();
            CreateMap<CreateSellerViewModel, Seller>();
            CreateMap<UpdateSellerViewModel, Seller>();

            CreateMap<Sale, SaleViewModel>().ReverseMap();
            CreateMap<CreateSaleViewModel, Sale>();
            CreateMap<UpdateSaleViewModel, Sale>();

            CreateMap<SaleItems, SaleItemsViewModel>().ReverseMap();
            CreateMap<CreateSaleItemsViewModel, SaleItems>();            
        }
    }
}