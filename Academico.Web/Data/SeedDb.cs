namespace Academico.Web.Data
{
    using Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            //Add User
            var user = await this.userHelper.GetUserByEmailAsync("miguel.k2705@gmail.com");
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

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            //Add Students
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
