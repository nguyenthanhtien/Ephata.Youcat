using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Command;
using Ephata.YouCat.DomainLayer.Model.YouCatDaily.Query;
using Ephata.YouCat.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ephata.YouCat.WebAPI.Controllers
{
    [ApiController]
    [Route("youcat-daily")]
    public class YouCatDailyController : ControllerBase
    {
        private readonly IYouCatDailyService _youCatDailyService;
        public YouCatDailyController(IYouCatDailyService youCatDailyService)
        {
            _youCatDailyService = youCatDailyService;
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> GetYouCatDailyById(Guid id)
        {
            var result = await _youCatDailyService.GetYouCatDailyById(new GetYouCatDailyByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost("filter")]
        public async Task<ActionResult> Filter(GetMultiYouCatDailyQuery query)
        {
            var result = await _youCatDailyService.GetYouCatDailies(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateYouCatDailyCommand command)
        {
            var result = await _youCatDailyService.AddYouCatDaily(command);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update(UpdateYouCatDailyCommand command)
        {
            var result = await _youCatDailyService.UpdateYouCatDaily(command);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(RemoveYouCatDailyCommand command)
        {
            var result = await _youCatDailyService.RemoveYouCatDaily(command);
            return Ok(result);
        }
    }
}
