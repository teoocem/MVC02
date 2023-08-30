using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Authorizations;
using BusinessLayer.Abstract.Requirements;
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
    options.Cookie.Name = "AuthCookie"; // Çerez adý
    options.Cookie.HttpOnly = true; // Sadece HTTP eriþimine izin ver
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; // Güvenli (HTTPS) veya herhangi bir protokolde çalýþabilir


    options.LoginPath = "/Login/Index"; // Kullanýcý giriþ yapmadýysa yönlendirilecek sayfa
    options.LogoutPath = "/Login/Index"; // Kullanýcý çýkýþ yaparsa yönlendirilecek sayfa
    options.AccessDeniedPath = "/Home/NotAuthorized"; // Yetkisiz eriþim durumunda yönlendirilecek sayfa

    options.SlidingExpiration = true; // Kullanýcý etkin olduðu sürece oturumun süresini uzatýr
    options.ExpireTimeSpan = TimeSpan.FromHours(1);

});

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("RequireStandartCalisan", policy => policy.AddRequirements(new CalisanRequirement("Standart")));
    config.AddPolicy("RequireSubeMuduru", policy => policy.AddRequirements(new CalisanRequirement("SubeMuduru")));
    config.AddPolicy("RequireDaireBaskani", policy => policy.AddRequirements(new CalisanRequirement("DaireBaskani")));
    config.AddPolicy("RequireAdmin", policy => policy.AddRequirements(new CalisanRequirement("Admin")));

});



builder.Services.AddSingleton<IAuthorizationHandler, CalisanAuthorization>();


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
builder.Services.AddScoped<LoginRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new LoginRepository(context);
});
builder.Services.AddScoped<LoginManager>(provider =>
{
    var repo = provider.GetRequiredService<LoginRepository>();
    return new LoginManager(repo);
});

builder.Services.AddScoped<RolesManager>(provider =>
{
    var roleRepo = provider.GetRequiredService<RolesRepository>();
    var roleDepartmanRepo = provider.GetRequiredService<RolesDepartmanRepository>();
    return new RolesManager(roleRepo,roleDepartmanRepo);
});
builder.Services.AddScoped<IzinRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new IzinRepository(context);
});
builder.Services.AddScoped<IzinManager>(provider =>
{
    var izinRepo = provider.GetRequiredService<IzinRepository>();
    return new IzinManager(izinRepo);
});
builder.Services.AddScoped<CalisanGorevRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new CalisanGorevRepository(context);
});
builder.Services.AddScoped<CalisanGorevAtamasiManager>(provider =>
{
    var calisanGorevRepo = provider.GetRequiredService<CalisanGorevRepository>();
    return new CalisanGorevAtamasiManager(calisanGorevRepo);
});
builder.Services.AddScoped<GorevRepository>(provider =>
{
    var context = provider.GetRequiredService<Context>();
    return new GorevRepository(context);
});
builder.Services.AddScoped<GorevManager>(provider =>
{
    var gorevRepo = provider.GetRequiredService<GorevRepository>();
    var gorevDepartman = provider.GetRequiredService<CalisanGorevAtamasiManager>();
    return new GorevManager(gorevRepo, gorevDepartman);
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
