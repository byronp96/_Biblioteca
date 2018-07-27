using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Cliente
    {
        public int cli_codigo { get; set; }

        public string cli_identificacion { get; set; }

        public string cli_nombre { get; set; }

        public string cli_apellido { get; set; }

        public string cli_correo { get; set; }

        public DateTime cli_fecha_nacimiento { get; set; }

        public string cli_telefono { get; set; }

        public string cli_clave { get; set; }
    }
}