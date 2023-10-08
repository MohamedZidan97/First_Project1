using Microsoft.EntityFrameworkCore;
using TempleteD.Business_Layer.AutoMapper;
using TempleteD.Business_Layer.Repositories;
using TempleteD.Data_Access_Layer;
using System.Net;
using TempleteD.Business_Layer.Interfaces;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using TempleteD.Business_Layer.Helper;
using Microsoft.AspNetCore.Identity;
using TempleteD.Models;

var builder = WebApplication.CreateBuilder(args);

//Mail Setting
var mailSettings = builder.Configuration.GetSection("MailSetting");
builder.Services.Configure<MailSettingOutlook>(mailSettings);

// Localization add a lot of languages in website

var supportedCultures = new[]
{
    new CultureInfo("ar-EG"),
    new CultureInfo("en-US"),
};
// Add services to the container.
// Add Newton Json 


builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization()
    .AddNewtonsoftJson(opt 
    =>{ opt.SerializerSettings.ContractResolver = new DefaultContractResolver();}) ;

// DI To Connection String \
var connectionstring = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseSqlServer(connectionstring));

// Auto Mapper

builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

//Instance of Identity Usres and Roles
builder.Services.AddIdentity<IdentityUser,IdentityRole>(
    options =>
    {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    }
    ).AddEntityFrameworkStores<ApplicationDbContext>()
    // allow to token in forget password action
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

//  
builder.Services.AddScoped<EmpRep>();
builder.Services.AddScoped<CountryRep>();
builder.Services.AddScoped<BranchRep>();
builder.Services.AddScoped< DepRep>();
builder.Services.AddScoped<StudentRep>();
builder.Services.AddScoped<MailingRep>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture= new RequestCulture("ar-EG"),
    SupportedCultures=supportedCultures,
    SupportedUICultures=supportedCultures,
    RequestCultureProviders=new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    }
});
app.UseStaticFiles();

app.UseRouting();
// Connect Login With all Controlleres
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
