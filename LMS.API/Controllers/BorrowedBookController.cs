using Microsoft.AspNetCore.Mvc;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowedbookService;
        public BorrowedBookController(IBorrowedBookService borrowedbookService)
        {
            _borrowedbookService = borrowedbookService;
        }
        // GET: api/<BorrowedBookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowedBooksViewModel>>> Get()
        {
            var data =_borrowedbookService.Get();
            return Ok(data);
        }

        // GET api/<BorrowedBookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowedBooksViewModel>> Get(int id)
        {
            var data = _borrowedbookService.GetByID(id);
            return Ok(data);
        }

        // POST api/<BorrowedBookController>
        [HttpPost]
        public async Task<ActionResult<int>> Post(BorrowedBooksViewModel BorrowedBooksVM)
        {
            var data = _borrowedbookService.Add(BorrowedBooksVM);
            return Ok(data);
        }

        // PUT api/<BorrowedBookController>/5
        [HttpPut]
        public async Task<ActionResult<int>> Put(BorrowedBooksViewModel BorrowedBooksVM)
        {
            var data = _borrowedbookService.Update(BorrowedBooksVM);
            return Ok(data);
        }

        // DELETE api/<BorrowedBookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var data = _borrowedbookService.Delete(id);
            return Ok(data);
        }
    }
}
