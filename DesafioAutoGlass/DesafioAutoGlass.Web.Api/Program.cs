using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Application.Services;
using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Core.Notifications;
using DesafioAutoGlass.Domain.Service;
using DesafioAutoGlass.Infrastructure.Data.Repositories;
using DesafioAutoGlass.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// API
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// APPLICATION
builder.Services.AddScoped<IApplicationProductServices, ApplicationProductServices>();
builder.Services.AddScoped<IApplicationSupplierServices, ApplicationSupplierServices>();

// DOMAIN SERVICE
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

// DOMAIN REPOSITORY
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<INotifier, Notifier>();

//INFRA
builder.Services.AddScoped<SqlDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error/500");
    app.UseStatusCodePagesWithRedirects("/error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
