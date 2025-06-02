using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages.Ventanas
{
    public class DetallesVentasModel : PageModel
    {
        private IDetallesVentaPresentacion? iPresentacion = null;
        private IVentasPresentacion? iVentasPresentacion = null;
        private IJuguetesPresentacion? iJuguetesPresentacion = null;

        public DetallesVentasModel(IDetallesVentaPresentacion iDetallesVentaPresentacion, IVentasPresentacion iVentasPresentacion, IJuguetesPresentacion iJuguetesPresentacion)
        {
            try
            {
                this.iPresentacion = iDetallesVentaPresentacion;
                this.iVentasPresentacion = iVentasPresentacion;
                this.iJuguetesPresentacion = iJuguetesPresentacion;
                Filtro = new DetallesVenta();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public DetallesVenta? Actual { get; set; }
        [BindProperty] public DetallesVenta? Filtro { get; set; }
        [BindProperty] public List<DetallesVenta>? Lista { get; set; }
        [BindProperty] public List<Ventas>? Venta { get; set; }
        [BindProperty] public List<Juguetes>? Juguete { get; set; }




        public async Task OnGetAsync()
        {
            ViewData["BodyClass"] = "detallesventa-background";
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

                // Replace the following line:  
                // Filtro!.Cantidad = Filtro!.Cantidad ?? "";  

                // With this corrected line:  
                Filtro!.Cantidad = Filtro!.Cantidad == 0 ? 0 : Filtro!.Cantidad;


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
        private void CargarCombox()
        {
            try
            {
                // Cargar Juguetes
                var taskJuguetes = this.iJuguetesPresentacion!.Listar();
                taskJuguetes.Wait(); // Espera a que la tarea de juguetes termine
                Juguete = taskJuguetes.Result; // Asigna el resultado a la propiedad Juguete

                // Cargar Ventas
                // Asumiendo que tienes una interfaz iVentasPresentacion y una propiedad Venta
                var taskVentas = this.iVentasPresentacion!.Listar();
                taskVentas.Wait(); // Espera a que la tarea de ventas termine
                Venta = taskVentas.Result; // Asigna el resultado a la propiedad Venta
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public async Task<IActionResult> OnPostBtNuevo()
        {

            Accion = Enumerables.Ventanas.Editar;
            Actual = new DetallesVenta();

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

            Task<DetallesVenta>? task = null;
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
