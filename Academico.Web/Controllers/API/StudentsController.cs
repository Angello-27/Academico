namespace Academico.Web.Controllers.API
{
    using Data.Repository;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
