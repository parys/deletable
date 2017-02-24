using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletableExample.Contracts
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(string address) where T : class;
    }
}
