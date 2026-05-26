using System.ComponentModel.DataAnnotations;

namespace clinica.Models
{
    public enum TipoAtencion { ConsultaGeneral, Urgencia, Examen }

    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "La edad debe ser entre 1 y 120")]
        public int Edad { get; set; }

        public string? Telefono { get; set; }
        public TipoAtencion TipoAtencion { get; set; }
        public bool TienePrevision { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string? Diagnostico { get; set; }

       
        public static int ObtenerCostoBase(TipoAtencion tipo) => tipo switch
        {
            TipoAtencion.ConsultaGeneral => 10000,
            TipoAtencion.Urgencia => 25000,
            TipoAtencion.Examen => 15000,
            _ => 0
        };

        public int CostoBase => ObtenerCostoBase(TipoAtencion);
        public int CostoFinal => TienePrevision ? (int)(CostoBase * 0.70) : CostoBase;
        public int Descuento => CostoBase - CostoFinal;
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}