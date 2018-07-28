using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DATA
{
    public class Permiso
    {
        [AutoIncrement]
        public int per_codigo { get; set; }

        public string per_descripcion { get; set; }

        public string per_valor { get; set; }
    }
}
