using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace tech_test_payment_api.ViewModels.SaleItem
{
    public class CreateSaleItemsViewModel
    {
        [JsonIgnore]   
        public Guid SaleId { get; set; } 
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        
    }
}