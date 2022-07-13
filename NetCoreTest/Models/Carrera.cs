﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public Sede objSede { get; set; }
        public string Nombre { get; set; }

        public Carrera()
        {
            this.objSede = new Sede();
        }

    }
}
