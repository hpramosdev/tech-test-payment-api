using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Utils;

namespace tech_test_payment_api.ViewModels.Sale
{
    public class UpdateSaleViewModel
    {
        public Guid Id { get; set; }
        public SaleStatusEnum Status { get; set; }
    }
}