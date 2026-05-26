namespace clinica.Models
{
    public class ResumenDia
    {
        public List<Paciente> Pacientes { get; set; } = new();

        public int TotalPacientes => Pacientes.Count;
        public int TotalRecaudado => Pacientes.Sum(p => p.CostoFinal);
        public int TotalDescuentos => Pacientes.Sum(p => p.Descuento);
        public int ConPrevision => Pacientes.Count(p => p.TienePrevision);
        public int SinPrevision => Pacientes.Count(p => !p.TienePrevision);
        public int ConsultasGenerales => Pacientes.Count(p => p.TipoAtencion == TipoAtencion.ConsultaGeneral);
        public int Urgencias => Pacientes.Count(p => p.TipoAtencion == TipoAtencion.Urgencia);
        public int Examenes => Pacientes.Count(p => p.TipoAtencion == TipoAtencion.Examen);
    }
}