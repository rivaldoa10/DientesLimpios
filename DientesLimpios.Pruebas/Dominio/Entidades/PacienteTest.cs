using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Exepciones;
using DientesLimpios.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class PacienteTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExepcionDeReglaDeNegocio))]
        public void Constructor_NombreNulo_LanzaExcepcion()
        {
            var email = new Email("Juan@casa.com");
            new Paciente(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ExepcionDeReglaDeNegocio))]
        public void Constructor_emailNulo_LanzaExcepcion()
        {
            new Paciente("Juan", null!);
        }
    }
}
