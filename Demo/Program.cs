using Demo;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Produtos
app.MapGet("/product", (AppDbContext context) => {
    var results = context.product.Include(p => p.category).ToList();
    return Results.Ok(results);
});

app.MapPost("/product", (AppDbContext context, Product product) => {
    context.product.Add(product);
    context.SaveChanges();

    return Results.Ok(product);
});

app.MapPut("/product", (AppDbContext context, Product product) => {
    var productToUpdate = context.product.Find(product.id);

    productToUpdate.name = product.name;
    productToUpdate.categoryId = product.categoryId;

    context.SaveChanges();

    return Results.Ok(product);
});

app.MapDelete("/product/{id}", (AppDbContext context, int id) => {
    var product = context.product.Find(id);

    if(product == null)
        return Results.BadRequest("Produto não encontrado");

    context.product.Remove(product);
    context.SaveChanges();

    return Results.Ok("Produto removido com sucesso");
});

// Categoria
app.MapPost("/category", (AppDbContext context, Category category) => {
    context.category.Add(category);
    context.SaveChanges();

    return Results.Ok(category);
});

app.MapGet("/category", (AppDbContext context) => {
    var results = context.category.ToList();

    return Results.Ok(results);
});

app.Run();
