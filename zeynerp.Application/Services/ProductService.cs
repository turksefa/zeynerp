using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Entities;

namespace zeynerp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(bool trackChanges)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(trackChanges);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int id, bool trackChanges)
        {
            return _mapper.Map<ProductDto>(await _unitOfWork.ProductRepository.GetByIdAsync(id, trackChanges));
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.SaveChangesAsync();
        }

        public void DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChangesAsync();
        }
    }
}