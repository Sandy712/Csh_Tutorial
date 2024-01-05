using AspWeb.WebSite.Models;
using AspWeb.WebSite.Service;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();
//app.MapGet("/products", (context) =>
//{
//    var products = app.Services.GetService<JsonFileProductService>().GetProducts(); 
//    var jsonview= JsonSerializer.Serialize<IEnumerable<Product>>(products);

//    return context.Response.WriteAsJsonAsync(jsonview);

//});

app.Run();
