using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Libro
    {
        public int lib_codigo { get; set; }
        public string lib_titulo { get; set; }
        public DateTime lib_fecha_publicacion { get; set; }
        public string lib_idioma { get; set; }
        public int lib_paginas { get; set; }
        public string lib_sinopsis { get; set; }
        public byte[] lib_portada { get; set; }
        public string _lib_portada { get; set; }
        public bool lib_estado { get; set; }
        public int lib_cantidad { get; set; }
    }
}
