using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Exepciones
{
    public class ExcepcionDeMediador :Exception
    {
        public ExcepcionDeMediador(string mensaje) : base(mensaje)
        {
            
        }
    }
}
