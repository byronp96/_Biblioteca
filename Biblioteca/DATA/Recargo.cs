using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DATA
{
    public class Recargo
    {
        [AutoIncrement]
        public int rec_codigo { get; set; }

        public string rec_descripcion { get; set; }

        public int rec_estado { get; set; }

        public int rec_monto { get; set; }
    }
}
