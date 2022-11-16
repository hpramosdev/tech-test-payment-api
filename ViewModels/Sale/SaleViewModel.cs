using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Utils;
using tech_test_payment_api.ViewModels.SaleItem;
using tech_test_payment_api.ViewModels.Seller;

namespace tech_test_payment_api.ViewModels.Sale
{
public class SaleViewModel
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public DateTime Date { get; set; }        
        public SaleStatusEnum Status { get; set; }

        public SellerViewModel Seller { get; set; }
        public List<SaleItemsViewModel> Items { get; set; }

        public SaleViewModel()
        {
            Items = new List<SaleItemsViewModel>();
        }
    }
}