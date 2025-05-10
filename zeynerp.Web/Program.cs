using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using zeynerp.Application.Interfaces;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Application.Mapper;
using zeynerp.Application.Services;
using zeynerp.Application.Services.Tanimlamalar;
using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure;
using zeynerp.Infrastructure.Data;
using zeynerp.Infrastructure.Data.Contexts;
using zeynerp.Infrastructure.Data.Repositories;
using zeynerp.Infrastructure.Data.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Identity;
using zeynerp.Infrastructure.Identity.Models;
using zeynerp.Infrastructure.Identity.Services;
using zeynerp.Infrastructure.Services;
using zeynerp.Web.Mapper;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErrorDescriber>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(WebMappingProfile));
builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));

builder.Services.AddScoped<TenantDbContextFactory>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
builder.Services.AddScoped<ITenantUnitOfWork, TenantUnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IPaymentProcessor, IyzicoPaymentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ITenantPlanService, TenantPlanService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInvitationService, InvitationService>();
builder.Services.AddScoped<IStokGrupService, StokGrupService>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<ITenantPlanRepository, TenantPlanRepository>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IStokGrupRepository, StokGrupRepository>();

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

app.UseMiddleware<TenantMiddleware>();
// app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
