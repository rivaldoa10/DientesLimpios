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
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ExepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            }

            if (!email.Contains("@"))
            {
                throw new ExepcionDeReglaDeNegocio($"El {nameof(email)} no es valido");
            }
            Valor = email;
        }
    }
}
