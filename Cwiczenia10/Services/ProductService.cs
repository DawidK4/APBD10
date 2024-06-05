using Cwiczenia10.Contexts;
using Cwiczenia10.Models;
using Cwiczenia10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Services;

public interface IProductService
{
    Task<PostProductResponseModel> PostProductWithCategories(PostProductResponseModel request);
}

public class ProductService : IProductService
{
    private readonly DatabaseContext _databaseContext;

    public ProductService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<PostProductResponseModel> PostProductWithCategories(PostProductResponseModel request)
    {
        var product = new Product
        {
            Name = request.productName,
            Weight = request.productWeight,
            Width = request.productWidth,
            Height = request.productHeight,
            Depth = request.productDepth,
            Categories = request.productCategories.Select(categoryId => new Category
            {
                PkCategory = categoryId
            }).ToList()
        };

        _databaseContext.Products.Add(product);
        await _databaseContext.SaveChangesAsync();

        var response = new PostProductResponseModel
        {
            productName = product.Name,
            productWeight = product.Weight,
            productWidth = product.Width,
            productHeight = product.Height,
            productDepth = product.Depth,
            productCategories = product.Categories.Select(pc => pc.PkCategory)
        };

        return response;
    }
}