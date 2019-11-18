using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umea_02
{
    public class Context : DbContext
    {
        public Context() : base("name = DefaultConnection") {

            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<UncertaintyBudget> UncertaintyBudgets { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Pdf> Pdf { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Page> Pages { get; set; }

    }
}
