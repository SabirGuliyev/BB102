using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name:"Default",
    pattern:"{Controller=Home}/{Action=Index}/{id?}"
    );

app.Run();
