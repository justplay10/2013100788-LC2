﻿using _2013100788_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013100788_ENT.EntitiesDTO
{
    public class UbigeoDTO
    {
        public int UbigeoId { get; set; }
        public string desc { get; set; }
        public Departamento Departamento { get; set; }
        public Provincia Provincia { get; set; }
        public Distrito Distrito { get; set; }
    }
}
