using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Context;
using tech_test_payment_api.UoW.Interfaces;

namespace tech_test_payment_api.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataContext _context;

        public UnityOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            return success;
        }        

        public Task Roolback()
        {   
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}