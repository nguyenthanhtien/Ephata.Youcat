using Ephata.YouCat.DomainLayer.Model.Pray.Command;
using Ephata.YouCat.DomainLayer.Model.Pray.Query;
using Ephata.YouCat.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ephata.YouCat.WebAPI.Controllers
{
    [ApiController]
    [Route("pray")]
    public class PrayController : ControllerBase
    {
        private readonly IPrayService _prayService;
        public PrayController(IPrayService prayService)
        {
            _prayService = prayService;
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult> GetPrayById(GetPrayByIdQuery query)
        {
            var result = await _prayService.GetPrayById(query);
            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<ActionResult> Filter(GetMultiPrayQuery query)
        {
            var result = await _prayService.GetPrayers(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreatePrayCommand command)
        {
            var result = await _prayService.CreatePray(command);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update(UpdatePrayCommand command)
        {
            var result = await _prayService.UpdatePray(command);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(RemovePrayCommand command)
        {
            var result = await _prayService.RemovePray(command);
            return Ok(result);
        }


    }
}
