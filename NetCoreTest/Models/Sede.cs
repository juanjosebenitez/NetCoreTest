using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest.Models
{
    public class Sede
    {
        [Key]
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
