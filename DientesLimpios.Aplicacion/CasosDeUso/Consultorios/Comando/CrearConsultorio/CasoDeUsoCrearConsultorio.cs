using DientesLimpios.Aplicacion.Contratos.Exepciones;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comando.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio
    {
        private readonly IRepositorioConsultorio repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;
        private readonly IValidator<ComandoCrearConsultorio> validator;

        public CasoDeUsoCrearConsultorio(IRepositorioConsultorio repositorio, IUnidadDeTrabajo unidadDeTrabajo, IValidator<ComandoCrearConsultorio> validator)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
            this.validator = validator;
        }
        public async Task<Guid> Handle(ComandoCrearConsultorio comando)
        {
            var resultadoValidacion = await validator.ValidateAsync(comando);

            if (!resultadoValidacion.IsValid)
            {
                throw new ExcepcionDeValidacion(resultadoValidacion);
            }

            try
            {
                var consultorio = new Consultorio(comando.Nombre);
                var respuesta = await repositorio.Agregar(consultorio);
                await unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
            
        }
    }
}
