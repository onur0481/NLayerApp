using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Api.Filter;
using NLayer.core.Services;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Api.Controllers
{
    
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        
        private readonly IProductService _service;

        public ProductController(IService<Product> service,IMapper mapper,IProductService productService)
        {
            _mapper = mapper;

            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GettAll();
            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product=await _service.GetByIdAsync(id);
            var productDto= _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
             await _service.UpdateAsync(_mapper.Map<Product>(productDto));
           
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsycn(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }



    }
}
