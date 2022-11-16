using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories.Interfaces;

namespace tech_test_payment_api.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
            
        }        
    }
}