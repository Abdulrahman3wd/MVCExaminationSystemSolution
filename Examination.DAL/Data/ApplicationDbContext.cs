using Examination.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region DbStes

          public DbSet<ExamResults> ExamResults { get; set; }
        public DbSet<Exams>Exams { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<QnAs> QnAs { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get;}

        #endregion

      

    }
}
