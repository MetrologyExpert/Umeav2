using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umea_02
{
    public class Page
    {   
        [Key]
        public int pageNumber { get; set; }
        public int ubId { get; set; }
    }
}
