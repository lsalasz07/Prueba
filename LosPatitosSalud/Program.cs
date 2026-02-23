using Microsoft.EntityFrameworkCore;
using LosPatitosSalud.Data;
using LosPatitosSalud.Repositories;
using LosPatitosSalud.Services;

var builder = WebApplication.CreateBuilder(args);

var cadenaConexion = builder.Configuration.GetConnectionString("ConexionMySQL");
builder.Services.AddDbContext<AppDbContext>(opciones =>
    opciones.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion)));

builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<ICitaService, CitaService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Citas}/{action=Listar}/{id?}");

app.Run();
