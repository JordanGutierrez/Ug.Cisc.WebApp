using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Administracion
{
    public class Persona
    {
        [Required]
        [DisplayName("Código")]
        public int PersonaID { get; set; }

        public int TipoPersona { get; set; }

        [Required]
        [DisplayName("Tipo de Identificación")]
        public int IdentificacionID { get; set; }

        [Required]
        [DisplayName("Número de identificación")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El número de identificación solo acepta caracteres numéricos")]
        public string NumeroIdentificacion { get; set; }

        [Required]
        [DisplayName("Primer Nombre")]
        [RegularExpression(@"^[a-zA-ZÑñ]*$", ErrorMessage = "Solo acepta caracteres alafabéticos")]
        [MaxLength(50, ErrorMessage ="Máximo 25 caracteres")]
        public string PrimerNombre { get; set; }

        [Required]
        [DisplayName("Segundo Nombre")]
        [RegularExpression(@"^[a-zA-ZÑñ]*$", ErrorMessage = "Solo acepta caracteres alafabéticos")]
        [MaxLength(50, ErrorMessage = "Máximo 25 caracteres")]
        public string SegundoNombre { get; set; }

        [Required]
        [DisplayName("Apellido Paterno")]
        [RegularExpression(@"^[a-zA-ZÑñ]*$", ErrorMessage = "Solo acepta caracteres alafabéticos")]
        [MaxLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [DisplayName("Apellido Materno")]
        [RegularExpression(@"^[a-zA-ZÑñ]*$", ErrorMessage = "Solo acepta caracteres alafabéticos")]
        [MaxLength(50, ErrorMessage = "Máximo 25 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimineto { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [DisplayName("Correo")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Debe ingresar un Email válido")]
        public string Correo { get; set; }

        [DisplayName("Célular")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El número de celular debe tener 10 dígitos")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "La Fecha de Registro es requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Inicio Pasantías")]
        public Nullable<DateTime> FechaInicioPasantias { get; set; }

        [Required(ErrorMessage = "La Fecha de Registro es requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Fin de Pasantías")]
        public Nullable<DateTime> FechaFinPasantias { get; set; }

        [DisplayName("Tutor")]
        public Nullable<int> TutorID { get; set; }

        [DisplayName("Carrera")]
        public Nullable<int> CarreraID { get; set; }

        [DisplayName("Supervisor")]
        public Nullable<int> SupervisorID { get; set; }

        [DisplayName("Cargo")]
        [RegularExpression(@"^[a-zA-ZÑñ ]*$", ErrorMessage = "El cargo solo acepta caracteres alafabéticos")]
        [MaxLength(50, ErrorMessage = "Máximo 25 caracteres")]
        public string Cargo { get; set; }

        [DisplayName("Departamento")]
        public string Departamento { get; set; }

        [DisplayName("Institucion")]
        public Nullable<int> InstitucionID { get; set; }

        [Required]
        [DisplayName("Estado")]
        public bool Estado { get; set; }

        public static Persona CreatePersonaFromDataRecord(IDataRecord dr)
        {
            Persona persona = new Persona();

            persona.PersonaID = int.Parse(dr["PersonaId"].ToString());
            persona.TipoPersona = int.Parse(dr["PersonaId"].ToString());
            persona.IdentificacionID = int.Parse(dr["Identificacion"].ToString());
            persona.NumeroIdentificacion = dr["NumeroIdentificacion"].ToString();
            persona.PrimerNombre = dr["PrimerNombre"].ToString();
            persona.SegundoNombre = dr["SegundoNombre"].ToString();
            persona.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
            persona.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
            persona.FechaNacimineto = DateTime.Parse(dr["FechaNacimiento"].ToString());
            persona.Celular = dr["Celular"].ToString();
            persona.Correo = dr["Correo"].ToString();
            persona.FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
            if(dr["FechaInicioPasantias"] != DBNull.Value)
                persona.FechaInicioPasantias =  DateTime.Parse(dr["FechaInicioPasantias"].ToString());
            if (dr["FechaFinPasantias"] != DBNull.Value)
                persona.FechaFinPasantias = DateTime.Parse(dr["FechaFinPasantias"].ToString());
            if (dr["TutorID"] != DBNull.Value)
                persona.TutorID = int.Parse(dr["TutorID"].ToString());
            if (dr["CarreraID"] != DBNull.Value)
                persona.CarreraID = int.Parse(dr["CarreraID"].ToString());
            if (dr["SupervisorID"] != DBNull.Value)
                persona.SupervisorID = int.Parse(dr["SupervisorID"].ToString());
            persona.Cargo = dr["Cargo"].ToString();
            persona.Departamento = dr["Departamento"].ToString();
            if (dr["InstitucionID"] != DBNull.Value)
                persona.InstitucionID = int.Parse(dr["InstitucionID"].ToString());
            persona.Estado = bool.Parse(dr["Estado"].ToString());

            return persona;
        }
    }
}
