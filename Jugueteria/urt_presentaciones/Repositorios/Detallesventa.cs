using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Testing.Platform.Configurations;
using urt_presentaciones.Nucleo;


namespace urt_presentaciones.Repositorios
{
    [TestClass]
    public class DetallesVentaPrueba
    {
        private readonly IConexion? iConexion;
        private List<DetallesVenta>? lista;
        private DetallesVenta? entidad;
        public DetallesVentaPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.DetallesVenta!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.DetallesVenta()!;
            this.iConexion!.DetallesVenta!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {


            var entry = this.iConexion!.Entry<DetallesVenta>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }



        public bool Borrar()
        {
            this.iConexion!.DetallesVenta!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
