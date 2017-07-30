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
    public class Facultad
    {
        [Required]
        [DisplayName("Código")]
        public int FacultadID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DisplayName("Nombre")]
        [RegularExpression(@"^[A-Za-zÑñáéíóúÁÉÍÓÚ ]*$", ErrorMessage = "El nombre solo acepta caracteres alfabéticos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [DisplayName("Activo")]
        public bool Estado { get; set; }

        public static Facultad CreateFacultadFromDataRecord(IDataRecord dr)
        {
            Facultad facultad = new Facultad();

            facultad.FacultadID = int.Parse(dr["FacultadID"].ToString());
            facultad.Nombre = dr["Nombre"].ToString();
            facultad.Estado = bool.Parse(dr["Estado"].ToString());

            return facultad;
        }
    }
}
