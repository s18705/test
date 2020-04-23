using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Perscription_Medicament
    {
        public int IdMedicament { get; set; }

        public int IdPerscription { get; set; }

        public int Dose { get; set; }

        public string Details { get; set; }
    }
}
