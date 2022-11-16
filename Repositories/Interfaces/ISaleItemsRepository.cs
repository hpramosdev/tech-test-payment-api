using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories.Interfaces
{
    public interface ISaleItemsRepository : IBaseRepository<SaleItems>
    {
         Task<IEnumerable<SaleItems>> GetAllBySaleId(Guid saleId);
    }
}