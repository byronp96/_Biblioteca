using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Categoria
    {
        [AutoIncrement]
        public int cat_codigo { get; set; }
        public string cat_descripcion { get; set; }
    }
}
