using Microsoft.EntityFrameworkCore;
using restate.db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("restatedb"))
);

// builder.Services.AddMvc()
//     .AddRazorPagesOptions(options => options.AllowAreas = true);


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    Seed.SeedData(context);
}

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

app.MapAreaControllerRoute(
    name: "RealEstateArea",
    areaName: "RealEstateManagement",
    pattern: "manage/{controller=Home}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "TenantPortalArea",
    areaName: "TenantPortal",
    pattern: "tenant-portal/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
