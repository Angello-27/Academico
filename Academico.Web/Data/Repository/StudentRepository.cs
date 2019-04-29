namespace Academico.Web.Data.Repository
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DataContext context;

        public StudentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Students.Include(s => s.User);
        }
    }
}
