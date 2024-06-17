using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using TravesalCore_Proje.CQRS.Handlers.DestinationHandler;
using TravesalCore_Proje.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GetAllDestinationQueryHandler>();

builder.Services.AddLogging(x =>
    {
        x.ClearProviders();
        x.SetMinimumLevel(LogLevel.Debug);
        x.AddDebug();
    });

//þifre token yapýlanmasý
//Identity yapýlanmasý
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CoustumIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient();

//Entityden baðýmsýz hale  gelme yapýlanmasý
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();

builder.Services.AddScoped<IDestinationService, DestinationManager>();
builder.Services.AddScoped<IDestinationDal, EfDestinationDal>();

builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();

builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<InReservationDal, EfReservationDal>();

builder.Services.AddScoped<IGuideService, GuideManager>();
builder.Services.AddScoped<IGuideDal, EfGuideDal>();

builder.Services.AddScoped<IContactUsService, ContacUsManager>();
builder.Services.AddScoped<IContactUsDal, EfContatUsDal>();

builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IAnnounementDal, EfAnnouncementDal>();

//Auto Mapper Yapýlanmasý
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IValidator<AnnouncementAddDto>,AnnouncementValidator>();



// Add services to the container.
builder.Services.AddControllersWithViews();

//otantike olma iþlemi kod bloðu inþasý
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

//user otantike deðil ise logine yönlendirme iþlemi
builder.Services.ConfigureApplicationCookie(opitons =>
{
    opitons.LoginPath = "/Login/SýgnIn/";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//404 hata sayfasý kýsýtlayarak yönlendirme
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
