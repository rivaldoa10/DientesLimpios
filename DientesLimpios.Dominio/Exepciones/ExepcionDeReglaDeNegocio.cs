using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Exepciones
{
    public class ExepcionDeReglaDeNegocio : Exception
    {
        public ExepcionDeReglaDeNegocio(string mensaje) : base(mensaje)
        {
            
        }
    }
}
