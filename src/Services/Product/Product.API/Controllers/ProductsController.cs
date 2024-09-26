using Bogus;
using Microsoft.AspNetCore.Mvc;
using Product.API.Enums;
using Product.API.InputModels.ProductInputModels;
using Product.API.ViewModels.ProductViewModels;

namespace Product.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {
            var productViewModels = await Task.FromResult((IEnumerable<ProductViewModel>)CreateFakerProducts());

            return Ok(productViewModels);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/api/products")]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel inputModel)
        {
            int productId = await Task.FromResult(new Faker().Random.Number(1, 5));

            return CreatedAtRoute(nameof(GetProduct), new { productId }, new { ProductId = productId });
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/api/products/{productId:int}", Name = nameof(GetProduct))]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var productViewModel = await Task.FromResult(CreateFakerProduct(productId));

            return Ok(productViewModel);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("/api/products/{productId:int}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductInputModel inputModel)
        {
            if (productId != inputModel.ProductId)
                return BadRequest();

            await Task.Delay(1000);

            return NoContent();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("/api/products/{productId:int}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await Task.Delay(1000);

            return NoContent();
        }


        #region FakeData

        private static ProductViewModel CreateFakerProduct(int productId)
            => new Faker<ProductViewModel>().CustomInstantiator(f
                => new ProductViewModel(
                    productId,
                    f.Name.FirstName(),
                    f.Name.JobTitle(),
                    f.Name.JobDescriptor(),
                    f.Random.Enum<ProductCategory>(),
                    f.Name.FullName(),
                    f.Name.FullName(),
                    f.Name.FullName(),
                    f.Random.Enum<ProductColor>(),
                    f.Random.Bool(),
                    f.Random.Bool(),
                    f.Random.Number()));

        private static List<ProductViewModel> CreateFakerProducts()
          => new Faker<ProductViewModel>().CustomInstantiator(f
                => new ProductViewModel(
                    f.Random.Number(1, 5),
                    f.Name.FirstName(),
                    f.Name.JobTitle(),
                    f.Name.JobDescriptor(),
                    f.Random.Enum<ProductCategory>(),
                    f.Name.FullName(),
                    f.Name.FullName(),
                    f.Name.FullName(),
                    f.Random.Enum<ProductColor>(),
                    f.Random.Bool(),
                    f.Random.Bool(),
                    f.Random.Number())).Generate(5);

        #endregion FakeData


    }
}
