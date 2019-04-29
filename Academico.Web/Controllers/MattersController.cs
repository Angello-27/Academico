namespace Academico.Web.Controllers
{
    using Academico.Web.Data.Repository;
    using Academico.Web.Hepers;
    using Microsoft.AspNetCore.Mvc;
    public class MattersController : Controller
    {
        private readonly IMatterRepository repository;
        private readonly IUserHelper userHelper;

        public MattersController(IMatterRepository repository, IUserHelper userHelper)
        {
            this.repository = repository;
            this.userHelper = userHelper;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View(this.repository.GetAll());
        }
    }
}