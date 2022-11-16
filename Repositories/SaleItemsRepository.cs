using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories.Interfaces;

namespace tech_test_payment_api.Repositories
{
    public class SaleItemsRepository : BaseRepository<SaleItems>, ISaleItemsRepository
    {
        public SaleItemsRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<SaleItems>> GetAllBySaleId(Guid saleId)
        {
            return await _context.SalesItems.Where(w => w.SaleId == saleId).ToListAsync();
        }
    }
}