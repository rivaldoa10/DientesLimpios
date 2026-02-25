using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comando.CrearConsultorio
{
    public class ValidandoComandoCrearConsultorio : AbstractValidator<ComandoCrearConsultorio>
    {
        public ValidandoComandoCrearConsultorio()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
