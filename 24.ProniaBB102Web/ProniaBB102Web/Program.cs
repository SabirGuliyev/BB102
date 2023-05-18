using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(50);
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<LayoutService>();

var app = builder.Build();
app.UseSession();
app.UseStaticFiles();

app.MapControllerRoute(

    name: "Areas",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"

    );
app.MapControllerRoute(

    name:"Default",
    pattern:"{controller=home}/{action=index}/{id?}"

    );

app.Run();
