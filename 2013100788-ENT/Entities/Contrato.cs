﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public string desc { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
