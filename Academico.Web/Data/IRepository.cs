namespace Academico.Web.Data
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository
    {
        void AddStudent(Student student);

        Student GetStudent(int id);

        IEnumerable<Student> GetStudents();

        void RemoveStudent(Student student);

        Task<bool> SaveAllAsync();

        bool StudentExists(int id);

        void UpdateStudent(Student student);
    }
}