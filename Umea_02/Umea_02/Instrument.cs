using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umea_02
{
    public class Instrument
    {
        [Key]
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string MeasurementRange { get; set; }
        public double Resolution { get; set; }
        public double Temperature { get; set; }

        //Navigation Property

        public ICollection<UncertaintyBudget> UncertaintyBudgets { get; set; }

    }
}
