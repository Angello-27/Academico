using Academico.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academico.Web.Data
{    
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

    }

}
