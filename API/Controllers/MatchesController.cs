using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Matches;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MatchesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Match>>> GetMatches()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(Match match)
        {
            return Ok(await Mediator.Send(new Create.Command { Match = match }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Match match)
        {
            match.Id = id;
            return Ok(await Mediator.Send(new Edit.Command {Match = match}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}