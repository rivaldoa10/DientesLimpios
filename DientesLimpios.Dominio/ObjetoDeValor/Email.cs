using DientesLimpios.Dominio.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.ObjetoDeValor
{
    public record Email
    {
        public string Valor { get; } = null!;

        private Email()
        {
            
        }
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            }

            if (!email.Contains("@"))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} no es valido");
            }
            Valor = email;
        }
    }
}
