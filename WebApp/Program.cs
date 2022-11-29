using Microsoft.EntityFrameworkCore;
using WebApp;

string? dbName, password;
Console.WriteLine("Podaj nazwę bazy danych:");
dbName = Console.ReadLine();

Console.WriteLine("Podaj hasło bazy danych:");
password = Console.ReadLine();

var builder = WebApplication.CreateBuilder(args);
var connectionString = $"Server=192.168.1.9,1433;Database={dbName};User Id=sa;Password={password}; encrypt=false";
//var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ?? throw new InvalidOperationException("Connection string 'SqlConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
