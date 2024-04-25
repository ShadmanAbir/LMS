using Microsoft.AspNetCore.Mvc;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksViewModel>>> Get()
        {
            var data =_bookService.Get();
            return Ok(data);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksViewModel>> Get(int id)
        {
            var data = _bookService.GetByID(id);
            return Ok(data);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<int>> Post(BooksViewModel BooksVM)
        {
            var data = _bookService.Add(BooksVM);
            return Ok(data);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public async Task<ActionResult<int>> Put(BooksViewModel BooksVM)
        {
            var data = _bookService.Update(BooksVM);
            return Ok(data);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var data = _bookService.Delete(id);
            return Ok(data);
        }
    }
}
