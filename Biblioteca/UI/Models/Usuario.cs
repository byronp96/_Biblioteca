using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Usuario
    {
        public int usu_codigo { get; set; }

        public string usu_identificacion { get; set; }

        public string usu_nombre { get; set; }

        public string usu_apellido { get; set; }
        [EmailAddress(ErrorMessage = "Debe ser un correo valido")]
        public string usu_correo { get; set; }

        public DateTime usu_fecha_nacimiento { get; set; }

        public string usu_telefono { get; set; }

        public string usu_clave { get; set; }
    }
}