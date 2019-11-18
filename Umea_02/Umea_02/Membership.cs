using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umea_02
{
    public class Membership
    {
        [Key]
        public int MembershipTypeId { get; set; }
        public string MembershipType { get; set; }

        //Navigation Properties
        //public UserMembership UserMembership { get; set; }


    }
}
