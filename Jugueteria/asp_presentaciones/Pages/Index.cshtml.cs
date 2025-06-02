using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages
{
    public class IndexModel : PageModel
    {


        public bool EstaLogueado = false;

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        public List<Juguetes> Juguetes { get; set; } = new();
        public List<DetallesVenta> DetallesVenta { get; set; } = new();
        public List<Ventas> Ventas { get; set; } = new();
        public List<Empleados> Empleados { get; set; } = new();
        public List<Estantes> Estantes { get; set; } = new();
        public List<Pedidos> Pedidos { get; set; } = new();
        public List<Permisos> Permisos { get; set; } = new();
        public List<Proveedores> Proveedores { get; set; } = new();
        public List<Usuarios> Usuarios { get; set; } = new();
        public List<Roles> Roles { get; set; } = new();

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }

                if ("admin.123" != Email + "." + Contrasena)
                {
                    OnPostBtClean();
                    return;
                }

                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;

                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
