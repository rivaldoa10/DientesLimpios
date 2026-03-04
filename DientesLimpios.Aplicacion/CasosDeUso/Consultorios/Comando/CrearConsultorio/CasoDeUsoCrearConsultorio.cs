using DientesLimpios.Aplicacion.Contratos.Exepciones;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comando.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio : IRequestHandler<ComandoCrearConsultorio, Guid>
    {
        private readonly IRepositorioConsultorio repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;
        private readonly IValidator<ComandoCrearConsultorio> validator;

        public CasoDeUsoCrearConsultorio(IRepositorioConsultorio repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task<Guid> Handle(ComandoCrearConsultorio comando)
        {
            var consultorio = new Consultorio(comando.Nombre);
            try
            {
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
