using Microsoft.EntityFrameworkCore;
using Polizia_Municipale.Models.Entities;
using Polizia_Municipale.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string connectionString = string.Empty;

try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection String Not Found!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
      );

builder.Services.AddScoped<AnagraficaService>();
builder.Services.AddScoped<ViolazioniService>();
builder.Services.AddScoped<VerbaliService>();
builder.Services.AddScoped<IHomeService, HomeService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
