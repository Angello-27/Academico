namespace Academico.Web.Data
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;

        public SeedDb(DataContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Students.Any())
            {
                this.AddStudent("Miguel", "Escobar");
                this.AddStudent("Perla", "Saire");
                this.AddStudent("Abigael", "Alvarez");
                this.AddStudent("Wuendy", "Collado");
                this.AddStudent("Alejandra", "Montero");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddStudent(string name, string lastName)
        {
            this.context.Students.Add(new Student
            {
                Name = name,
                LastName = lastName,
                ImageUrl = null,
                IsAvailable = true
            });
        }
    }
}
