﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.Entities
{
    public class CentroAtencion
    {
        public int CenAteId { get; set; }
        public string desc { get; set; }
        public int DirId { get; set; }
        public Direccion Direccion { get; set; }

    }
}
