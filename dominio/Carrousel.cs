﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrousel
    {
        public int idCarrousel { get; set; }
        public string Texto { get; set; }
        public override string ToString()
        {
            return Texto;     
        }
    }
}
