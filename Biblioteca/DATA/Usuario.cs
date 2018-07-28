using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DATA
{
    public class Usuario
    {
        [AutoIncrement]
        public int usu_codigo { get; set; }

        public string usu_identificacion { get; set; }

        public string usu_nombre { get; set; }

        public string usu_apellido { get; set; }

        public string usu_correo { get; set; }

        public DateTime usu_fecha_nacimiento { get; set; }

        public string usu_telefono { get; set; }

        public string usu_clave { get; set; }
    }
}
