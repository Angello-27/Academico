using Academico.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Web.Data
{
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
                await this.context.SaveChangesAsync();
            }
        }

        private void AddStudent(String name, String lastName)
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
