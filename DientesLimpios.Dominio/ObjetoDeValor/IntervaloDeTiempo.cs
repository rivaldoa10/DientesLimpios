using DientesLimpios.Dominio.Exepciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.ObjetoDeValor
{
    public record IntervaloDeTiempo
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }

        private IntervaloDeTiempo()
        {
            
        }

        public IntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            if (inicio >= fin)
            {
                throw new ExcepcionDeReglaDeNegocio($"La fecha de inicio no puede ser posterior a la fecha fin");
            }

            Inicio = inicio;
            Fin = fin;
        }
    }
}
