using FreakyFashionServices.CatalogService.Data;
using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        public IActionResult UpdateProducts(UpdateProductDTO updateProductDto)
        {
            var products = new Product(
                  updateProductDto.Id,
                  updateProductDto.Name,
                  updateProductDto.Description,
                  updateProductDto.ImageUrl,
                  updateProductDto.Price,
                  updateProductDto.UrlSlug
                    );
            products.UrlSlug = Regex.Replace(
                updateProductDto.Name, @"\s|[-]", x => x.Value == " " ? "-" : "").ToLower();
            Context.Product.Add(products);
            Context.SaveChanges();
            return Created("",products);

        }
    

        [HttpGet]
        public IEnumerable<UpdateProductDTO> GetAll()
        {
            var productDtos = Context.Product.Select(x => new UpdateProductDTO
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
}
