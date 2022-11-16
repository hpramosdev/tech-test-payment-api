using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.ViewModels.Seller
{
    public class CreateSellerViewModel
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
    }
}