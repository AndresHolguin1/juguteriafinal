using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asp_presentaciones
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
            builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            builder.Services.AddScoped<IProoveedoresPresentacion, ProveedoresPresentacion>();
            builder.Services.AddScoped<IJuguetesPresentacion, JuguetesPresentacion>();
            builder.Services.AddScoped<IDetallesVentaPresentacion, DetallesVentaPresentacion>();
            builder.Services.AddScoped<IEstantesPresentacion, EstantePresentacion>();
            builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            builder.Services.AddScoped<IPedidosPresentacion, PedidosPresentacion>();
            builder.Services.AddScoped<IConexion, Conexion>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            
            app.Run();
        }
    }
}
