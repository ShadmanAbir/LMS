using Microsoft.AspNetCore.Mvc;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembersViewModel>>> Get()
        {
            var data =_memberService.Get();
            return Ok(data);
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembersViewModel>> Get(int id)
        {
            var data = _memberService.GetByID(id);
            return Ok(data);
        }

        // POST api/<MemberController>
        [HttpPost]
        public async Task<ActionResult<int>> Post(MembersViewModel MembersVM)
        {
            var data = _memberService.Add(MembersVM);
            return Ok(data);
        }

        // PUT api/<MemberController>/5
        [HttpPut]
        public async Task<ActionResult<int>> Put(MembersViewModel MembersVM)
        {
            var data = _memberService.Update(MembersVM);
            return Ok(data);
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var data = _memberService.Delete(id);
            return Ok(data);
        }
    }
}
