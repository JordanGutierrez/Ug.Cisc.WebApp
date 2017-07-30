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
    public class Carrera
    {
        [Required]
        [DisplayName("Código")]
        public int CarreraID { get; set; }

        [Required(ErrorMessage = "La facultad es requerida")]
        [DisplayName("Facultad")]
        public int FacultadID { get; set; }

        [DisplayName("Facultad")]
        public string FacultadNombre { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DisplayName("Nombre")]
        [RegularExpression(@"^[A-Za-zÑñáéíóúÁÉÍÓÚ ]*$", ErrorMessage = "El nombre solo acepta caracteres alfabéticos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [DisplayName("Activo")]
        public bool Estado { get; set; }

        public static Carrera CreateCarreraFromDataRecord(IDataRecord dr)
        {
            Carrera carrera = new Carrera();

            carrera.CarreraID = int.Parse(dr["CarreraID"].ToString());
            carrera.FacultadID = int.Parse(dr["FacultadID"].ToString());
            carrera.FacultadNombre = dr["FacultadNombre"].ToString();
            carrera.Nombre = dr["Nombre"].ToString();
            carrera.Estado = bool.Parse(dr["Estado"].ToString());

            return carrera;
        }

    }
}
