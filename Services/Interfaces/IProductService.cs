using System.Collections.Generic;
using System.Threading.Tasks;
using CustomApi.Models;

namespace CustomApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
