using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CourseProject.Model
{
    public class OffenceContext : DbContext
    {
        public OffenceContext(): base("DefaultConnection")
        {

        }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Policeman> Policemen { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Offence> Offences { get; set; }
        public DbSet<ProtocoledOffence> ProtocoledOffences { get; set; }
    }
}
