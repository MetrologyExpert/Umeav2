using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Umea_02
{
    public class UncertaintyBudget
    {
        [Key]
        public int UbId { get; set; }

        //Navigation Properties

        //[ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //[ForeignKey("InstrumentId")]
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        //[ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Contribution> Contributions { get; set; }

      
    }
}
