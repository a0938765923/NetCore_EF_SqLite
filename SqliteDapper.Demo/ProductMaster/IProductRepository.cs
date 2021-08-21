using hw_backend_api_enhancement.Model;
using System.Threading.Tasks;

namespace SqliteDapper.Demo.ProductMaster
{
    public interface IProductRepository
    {
        Task Create(BillDetail product);
    }
}