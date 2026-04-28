using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ConsultorioTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaExcepcion()
        {
            new Consultorio(null!);
        }

        [TestMethod]
        public void Constructor_Nombre_NoLanzaExcepcion()
        {
            new Consultorio("Juan");
        }
    }
}
