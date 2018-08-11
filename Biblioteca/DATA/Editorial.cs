using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Editorial
    {
        [AutoIncrement]
        public int edi_codigo { get; set; }
        public string edi_nombre { get; set; }
    }
}
