namespace Academico.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("miguel.k2705@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Miguel Angel",
                    LastName = "Escobar Lazcano",
                    Email = "miguel.k2705@gmail.com",
                    UserName = "miguel.k2705@gmail.com",
                    PhoneNumber = "75505343"
                };
            }

            var result = await this.userManager.CreateAsync(user, "123456");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user in seeder");
            }

            if (!this.context.Students.Any())
            {
                this.AddStudent("Miguel", "Escobar", user);
                this.AddStudent("Perla", "Saire", user);
                this.AddStudent("Abigael", "Alvarez", user);
                this.AddStudent("Wuendy", "Collado", user);
                this.AddStudent("Alejandra", "Montero", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddStudent(string name, string lastName, User user)
        {
            this.context.Students.Add(new Student
            {
                Name = name,
                LastName = lastName,
                ImageUrl = null,
                IsAvailable = true,
                User = user
            });
        }
    }
}
