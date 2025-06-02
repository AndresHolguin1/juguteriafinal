using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages.Ventanas
{
    public class RolesModel : PageModel
    {
        private IRolesPresentacion? iPresentacion = null;
        public RolesModel(IRolesPresentacion iPresentacion) { try { this.iPresentacion = iPresentacion; Filtro = new Roles(); } catch (Exception ex) { LogConversor.Log(ex, ViewData!); } }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Roles? Actual { get; set; }
        [BindProperty] public Roles? Filtro { get; set; }
        [BindProperty] public List<Roles>? Lista { get; set; }
        public async Task OnGetAsync()
        {
            ViewData["BodyClass"] = "roles-background";
            await OnPostBtRefrescar();
        }

        public async Task OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                Filtro!.Nombre = Filtro!.Nombre ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Listar();
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        public async Task<IActionResult> OnPostBtNuevo()
        {

            Accion = Enumerables.Ventanas.Editar;
            Actual = new Roles();
            return Page();
        }

        public async Task<IActionResult> OnPostBtModificar(string data)
        {
            await OnPostBtRefrescar();

            Accion = Enumerables.Ventanas.Editar;
            Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            return Page();
        }

        public async Task<IActionResult> OnPostBtGuardar()
        {

            Accion = Enumerables.Ventanas.Editar;

            Task<Roles>? task = null;
            if (Actual!.Id == 0)
                task = this.iPresentacion!.Guardar(Actual!)!;
            else
                task = this.iPresentacion!.Modificar(Actual!)!;


            Accion = Enumerables.Ventanas.Listas;
            await OnPostBtRefrescar();
            return Page();
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        public async Task<IActionResult> OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);

                Actual = task.Result;
                await OnPostBtRefrescar();
                return Page();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }

        public async Task<IActionResult> OnPostBtCancelar()
        {

            Accion = Enumerables.Ventanas.Listas;
            await OnPostBtRefrescar();
            return Page();
        }

        public async Task<IActionResult> OnPostBtCerrar()
        {
            try
            {

                if (Accion == Enumerables.Ventanas.Listas)
                    await OnPostBtRefrescar();
                return Page();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }
    }
}
