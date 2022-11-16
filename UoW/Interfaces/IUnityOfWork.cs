using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.UoW.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Roolback();
    }
}