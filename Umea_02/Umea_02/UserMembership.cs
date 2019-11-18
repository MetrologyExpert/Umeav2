using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umea_02
{
    
    public class UserMembership
    {
        [Key]
        public int UserId { get; set; }
        public int MembershipTypeId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Membership Membership { get; set; }
    }
}
