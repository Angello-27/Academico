namespace Academico.Web.Data
{
    using Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Repository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.OrderBy(s => s.Name);
        }

        public Student GetStudent(int id)
        {
            return this.context.Students.Find(id);
        }

        public void AddStudent(Student student)
        {
            this.context.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            this.context.Students.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            this.context.Students.Remove(student);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool StudentExists(int id)
        {
            return this.context.Students.Any(s => s.Id == id);
        }

    }
}
