namespace Academico.Web.Controllers
{
    using Academico.Web.Hepers;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }
    }
}