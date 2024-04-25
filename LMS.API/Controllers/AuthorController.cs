using Microsoft.AspNetCore.Mvc;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorsViewModel>>> Get()
        {
            var data = _authorService.Get();
            return Ok(data);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorsViewModel>> Get(int id)
        {
            var data = _authorService.GetByID(id);
            return Ok(data);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<int>> Post(AuthorsViewModel authorsVM)
        {
            var data = _authorService.Add(authorsVM);
            return Ok(data);
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public async Task<ActionResult<int>> Put(AuthorsViewModel authorsVM)
        {
            var data = _authorService.Update(authorsVM);
            return Ok(data);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var data = _authorService.Delete(id);
            return Ok(data);
        }
    }
}
