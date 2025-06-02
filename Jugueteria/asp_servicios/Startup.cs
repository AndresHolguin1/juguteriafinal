using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
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
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped<IConexion, Conexion>();
            // Aplicaciones
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IVentasAplicacion, VentasAplicacion>();
            services.AddScoped<IPedidiosAplicacion, PedidosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<IJuguetesAplicacion, JuguetesAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IEstantesAplicacion, EstantesAplicacion>();
            services.AddScoped<IDetallesVentaAplicacion, DetallesVentaAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();


        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }
    }
}
