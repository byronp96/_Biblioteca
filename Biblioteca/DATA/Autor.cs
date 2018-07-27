﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class Autor
    {
        [AutoIncrement]
        public int aut_codigo { get; set; }
        public string aut_nombre { get; set; }
        public string aut_apellido { get; set; }
        public DateTime aut_fecha_nacimiento { get; set; }
        public string aut_nacionalidad { get; set; }
        public byte[] aut_foto { get; set; }
    }
}
