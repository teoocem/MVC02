using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();


builder.Services.AddAuthentication("cookie").AddCookie("cookie",options =>
{
    options.Cookie.Name = "AuthCookie"; // �erez ad�
    options.Cookie.HttpOnly = true; // Sadece HTTP eri�imine izin ver
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; // G�venli (HTTPS) veya herhangi bir protokolde �al��abilir


    options.LoginPath = "/Login/Index"; // Kullan�c� giri� yapmad�ysa y�nlendirilecek sayfa
    options.LogoutPath = "/Login/Index"; // Kullan�c� ��k�� yaparsa y�nlendirilecek sayfa
    options.AccessDeniedPath = "/Home/NotAuthorized"; // Yetkisiz eri�im durumunda y�nlendirilecek sayfa

    options.SlidingExpiration = true; // Kullan�c� etkin oldu�u s�rece oturumun s�resini uzat�r
    options.ExpireTimeSpan = TimeSpan.FromHours(1);

});

builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("RequireStandartCalisan", policy =>
    {
        policy.AddRequirements(new StandartCalisanRequirement("Standart"));
    });
    configure.AddPolicy("RequireSubeMuduru", policy =>
    {
        policy.AddRequirements(new StandartCalisanRequirement("SubeMuduru"));
    });
    configure.AddPolicy("RequireDaireBaskani", policy =>
    {
        policy.AddRequirements(new StandartCalisanRequirement("DaireBaskani"));
    });
});



builder.Services.AddSingleton<IAuthorizationHandler, StandartCalisanAuthorization>();


builder.Services.AddScoped<Context>();
builder.Services.AddScoped<CalisanRepository>(option =>
{
    var context = option.GetRequiredService<Context>();
    return new CalisanRepository(context);
});
builder.Services.AddScoped<CalisanManager>(provider =>
{
    var calisanRepo = provider.GetRequiredService<CalisanRepository>();
    return new CalisanManager(calisanRepo);
});


builder.Services.AddScoped<DepartmanRepository>(option =>
{
    var context = option.GetRequiredService<Context>();
    return new DepartmanRepository(context);
});
builder.Services.AddScoped<DepartmanManager>(provider =>
{
    var departmanRepo = provider.GetRequiredService<DepartmanRepository>();
    return new DepartmanManager(departmanRepo);
});
builder.Services.AddScoped<RolesRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new RolesRepository(context);
});
builder.Services.AddScoped<RolesDepartmanRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new RolesDepartmanRepository(context);
});

builder.Services.AddScoped<RolesManager>(provider =>
{
    var roleRepo = provider.GetRequiredService<RolesRepository>();
    var roleDepartmanRepo = provider.GetRequiredService<RolesDepartmanRepository>();
    return new RolesManager(roleRepo,roleDepartmanRepo);
});
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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "Default",pattern : "{controller=Login}/{action=Index}/{id?}");

app.Run();
