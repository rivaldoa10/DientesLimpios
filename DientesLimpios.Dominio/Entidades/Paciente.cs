using DientesLimpios.Dominio.Exepciones;
using DientesLimpios.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Entidades
{
    public class Paciente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Paciente(string nombre, Email email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExepcionDeReglaDeNegocio($"El campo {nameof(nombre)} es obligatorio");
            }

            if (email is null)
            {
                throw new ExepcionDeReglaDeNegocio($"El campo {nameof(email)} es obligatorio");
            }

            Nombre = nombre;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
