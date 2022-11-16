using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.ViewModels.SaleItem;

namespace tech_test_payment_api.ViewModels.Sale
{

    public class CreateSaleViewModel
    {        
        public Guid SellerId { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<CreateSaleItemsViewModel> Items { get; set; }
    }
}