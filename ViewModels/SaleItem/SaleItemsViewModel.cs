using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.ViewModels.Product;

namespace tech_test_payment_api.ViewModels.SaleItem
{
    public class SaleItemsViewModel
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }

        public ProductViewModel Produtcx { get; set; } 
    }
}