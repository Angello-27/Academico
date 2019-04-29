namespace Academico.Web.Data.Repository
{
    using Entities;
    using System.Linq;

    public interface IStudentRepository : IGenericRepository<Student>
    {
        IQueryable GetAllWithUsers();
    }
}
