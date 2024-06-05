using Cwiczenia10.Contexts;
using Cwiczenia10.Exceptions;
using Cwiczenia10.ResponseModels;
using Cwiczenia10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/accounts/{accountId:int}", async (int id, IAccountService service) =>
{
    try
    {
        return Results.Ok(await service.GetAccountByIdAsync(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});

app.MapPost("api/products", async (PostProductResponseModel request, IProductService productService) =>
{
    var productResponse = await productService.PostProductWithCategories(request);
    return Results.Ok(productResponse);
});

app.Run();