using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TempleteD.Data_Access_Layer.Entites;

namespace TempleteD.Data_Access_Layer
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Data Source=MOHAMEDZIDAN\\SQLEXPRESS;Initial Catalog=VirtualCompany;User ID=sa;Password=zmohamed684;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        protected override void OnModelCreating(ModelBuilder b)
        {
            #region PrimaryKay



            #endregion

            #region Relation

            #endregion

            b.Entity<IdentityUserLogin<string>>().HasNoKey();
            b.Entity<IdentityUserRole<string>>().HasNoKey();
            b.Entity<IdentityUserToken<string>>().HasNoKey();

        }
        public DbSet<Dep> departments { get; set; }
        public DbSet<Emp> employees { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Student> students { get; set; }




    }
}
