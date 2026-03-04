using DientesLimpios.Aplicacion.Contratos.Excepciones;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consulta.ObtenerDetalleConsultorio
{
    public class CasoDeUsoObtenerDetalleConsultorio : IRequestHandler<ConsultaObtenerDetalleConsultorio,
                                                        ConsultorioDetalleDTO>
    {
        private readonly IRepositorioConsultorio repositorio;

        public CasoDeUsoObtenerDetalleConsultorio(IRepositorioConsultorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<ConsultorioDetalleDTO> Handle(ConsultaObtenerDetalleConsultorio request)
        {
            var consultorio = await repositorio.ObtenerPorId(request.Id);

            if (consultorio is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return consultorio.ADto();
        }
    }
}
