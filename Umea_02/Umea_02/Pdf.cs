using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Umea_02
{
    public class Pdf
    {
        [Key]
        public int PdfId { get; set; }
        public string PdfName { get; set; }
        public double PdfCoefficient { get; set; }

        //Navigation Properties
        public UncertaintyBudget UncertaintyBudget { get; set; }



    }
}
