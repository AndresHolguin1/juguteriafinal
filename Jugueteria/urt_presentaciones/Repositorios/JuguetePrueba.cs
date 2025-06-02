using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Testing.Platform.Configurations;
using urt_presentaciones.Nucleo;



namespace urt_presentaciones.Repositorios
{
    [TestClass]
    public class JuguetesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Juguetes>? lista;
        private Juguetes? entidad;
        public JuguetesPrueba()
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
            this.lista = this.iConexion!.juguetes!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Juguetes()!;
            this.iConexion!.juguetes!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {


            var entry = this.iConexion!.Entry<Juguetes>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }



        public bool Borrar()
        {
            this.iConexion!.juguetes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}

