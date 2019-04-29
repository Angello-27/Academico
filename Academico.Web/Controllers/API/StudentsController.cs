namespace Academico.Web.Controllers.API
{
    using Academico.Web.Data.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository stundentRepository;

        public StudentsController(IStudentRepository stundentRepository)
        {
            this.stundentRepository = stundentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(this.stundentRepository.GetAllWithUsers());
        }
    }
}
