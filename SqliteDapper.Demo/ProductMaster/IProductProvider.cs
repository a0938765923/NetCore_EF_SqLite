using hw_backend_api_enhancement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.ProductMaster
{
    public interface IProductProvider
    {
        Task<IEnumerable<dynamic>> Get();
    }
}