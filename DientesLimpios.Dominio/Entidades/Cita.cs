using DientesLimpios.Dominio.Enum;
using DientesLimpios.Dominio.Exepciones;
using DientesLimpios.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Entidades
{
    public class Cita
    {
        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; }
        public Guid DentistaId { get; private set; }
        public Guid ConsultorioId { get; private set; }
        public EstadoCita Estado { get; private set; }
        public IntervaloDeTiempo IntervaloDeTiempo { get; private set; }
        public Paciente? Paciente { get; private set; }
        public Dentista? Dentista { get; private set; }
        public Consultorio? Consultorio { get; private set; }

        public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, IntervaloDeTiempo intervaloDeTiempo)
        {
            if (intervaloDeTiempo.Inicio < DateTime.UtcNow)
            {
                throw new ExepcionDeReglaDeNegocio($"La fecha de inicio no puede ser anterior a la fecha actual");
            }

            PacienteId = pacienteId;
            DentistaId = dentistaId;
            ConsultorioId = consultorioId;
            Estado = EstadoCita.Programada;
            IntervaloDeTiempo = intervaloDeTiempo;
            Id = Guid.CreateVersion7();
        }

        public void Cancelar()
        {
            if (Estado.ToString() == EstadoCita.Cancelada.ToString())
            {
                throw new ExepcionDeReglaDeNegocio($"Solo se pueden cancelar citas programadas");
            }
            Estado = EstadoCita.Cancelada;
        }

        public void Completa()
        {
            if (Estado != EstadoCita.Completada)
            {
                throw new ExepcionDeReglaDeNegocio($"Solo se pueden completar citas programadas");
            }
            Estado = EstadoCita.Completada;
        }
    }
}
