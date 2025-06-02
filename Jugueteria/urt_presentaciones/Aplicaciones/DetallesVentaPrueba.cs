using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;

using lib_repositorios.Interfaces;
using urt_presentaciones.Nucleo;


namespace urt_presentaciones.Aplicaciones
{
    [TestClass]
    public class DetallesVentaPrueba
    {
        private readonly IDetallesVentaAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<DetallesVenta>? lista;
        private DetallesVenta? entidad;
        public DetallesVentaPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new DetallesVentaAplicacion(iConexion);
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar() { this.lista = this.iAplicacion!.Listar(); return lista.Count > 0; }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.DetallesVenta()!;
            this.iAplicacion!.Guardar(this.entidad); return true;
        }
        public bool Modificar()
        {
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }
        public bool Borrar()
        {
            this.iAplicacion!.Borrar(this.entidad);
            return true;
        }
    }
}
