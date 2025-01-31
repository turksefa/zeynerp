using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts(bool trackChanges);
        Task<ProductDto> GetProductById(int id, bool trackChanges);
        Task<ProductDto> CreateProduct(ProductDto productDto);
        void UpdateProduct(ProductDto productDto);
        void DeleteProduct(ProductDto productDto);
    }
}