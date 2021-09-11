using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ephata.YouCat.WebAPI.Controllers
{
    [ApiController]
    [Route("pray-comment")]
    public class PrayCommentController : ControllerBase
    {
        private readonly IPrayCommentService _prayCommentService;
        public PrayCommentController(IPrayCommentService prayCommentService)
        {
            _prayCommentService = prayCommentService;
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult> GetPrayCommentById(GetPrayCommentByIdQuery query)
        {
            var result = await _prayCommentService.GetPrayCommentById(query);
            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<ActionResult> Filter(GetPrayCommentQuery query)
        {
            var result = await _prayCommentService.GetPrayComments(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreatePrayCommentCommand command)
        {
            var result = await _prayCommentService.AddComment(command);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update(UpdatePrayCommentCommand command)
        {
            var result = await _prayCommentService.UpdateComment(command);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(RemovePrayCommentCommand command)
        {
            var result = await _prayCommentService.RemoveComment(command);
            return Ok(result);
        }
    }
}
