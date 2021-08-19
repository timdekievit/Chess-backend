using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Matches;
using Domain;
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
        public async Task<ActionResult<Match>> getMatch(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
    }
}