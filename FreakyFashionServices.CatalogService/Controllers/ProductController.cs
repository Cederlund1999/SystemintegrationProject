using FreakyFashionServices.CatalogService.Data;
using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(CatalogServiceContext context)
        {
            Context = context;
        }

        private CatalogServiceContext Context { get; }

        [HttpPost]
        public IActionResult UpdateProducts( UpdateProductDTO updateProductDto)
        {
            var products = new Product(
                  updateProductDto.Id,
                  updateProductDto.Name,
                  updateProductDto.Description,
                  updateProductDto.UrlSlug,
                  updateProductDto.Price,
                  updateProductDto.ImageUrl
                    );
            Context.Product.Add(products);
            Context.SaveChanges();
            return NoContent();


            /*var products = Context.Product.FirstOrDefault(x => x.Id == updateProductDto.Id);
            if(products == null)
            {
                products = new Product(
                  updateProductDto.Id,
                  updateProductDto.Name,
                  updateProductDto.Description,
                  updateProductDto.UrlSlug,
                  updateProductDto.Price,
                  updateProductDto.ImageUrl
                    );
                Context.Product.Add(products);
            }
            else
            {
                products.Name = updateProductDto.Name;
            }
            Context.SaveChanges();
            return NoContent();*/
        }

        [HttpGet]
        public IEnumerable<ProductsDto> GetAll()
        {
            var productDtos = Context.Product.Select(x => new ProductsDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                UrlSlug = x.UrlSlug

            });
            return productDtos;
        }

    }
    public class ProductsDto
    {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Price { get; set; }

    public string UrlSlug { get; set; }
}
}
