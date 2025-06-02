using lib_presentaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using asp_presentaciones;
using Microsoft.EntityFrameworkCore;
using lib_repositorios.Implementaciones;
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder, builder.Services);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Registro de tus servicios de presentación
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IProoveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IJuguetesPresentacion, JuguetesPresentacion>();
builder.Services.AddScoped<IDetallesVentaPresentacion, DetallesVentaPresentacion>();
builder.Services.AddScoped<IEstantesPresentacion, EstantePresentacion>();
builder.Services.AddScoped<IPedidosPresentacion, PedidosPresentacion>();
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
startup.Configure(app, app.Environment);
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

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapControllers(); // Si estás usando controladores

app.Run();