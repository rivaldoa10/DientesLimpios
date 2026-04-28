using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Exepciones
{
    public class ExcepcionDeReglaDeNegocio : Exception
    {
        public ExcepcionDeReglaDeNegocio(string mensaje) : base(mensaje)
        {
            
        }
    }
}
