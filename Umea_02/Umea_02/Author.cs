using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Umea_02
{
    public class Author

    {   [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        //Navigation Properties
        public ICollection<UncertaintyBudget> UncertaintyBudgets { get; set; }
    }
}
