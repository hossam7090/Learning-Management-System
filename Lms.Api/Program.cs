using Lms.Core;
using Lms.Core.MiddelWare;
using Lms.Data.Entities.Identity;
using Lms.Infrastructure;
using Lms.Infrastructure.Data;
using Lms.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





#region Dependency Injection
builder.Services.AddInfrastructureDependencies()
                .AddServicesDependencies()
                .AddCoreDependencies()
                .AddServiceRegisteration();
#endregion

#region Localization

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new AcceptLanguageHeaderRequestCultureProvider() // Lowest priority
    };

});



#endregion

#region AllowCORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion

var app = builder.Build();



// Configure the HTTP request pipeline.
#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors(CORS);
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();            // exposes /openapi/v1.json
    app.MapScalarApiReference(); // serves Scalar UI (e.g. /scalar/v1)
}
app.MapControllers();

app.Run();
