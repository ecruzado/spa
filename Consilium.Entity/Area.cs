﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Descripcion { get; set; }
        public bool EsOpcional { get; set; }
        public string NombreAlternativo { get; set; }
        public int ColegioId { get; set; }
    }
}
