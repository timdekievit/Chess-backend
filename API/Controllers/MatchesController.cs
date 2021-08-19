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
        public async Task<ActionResult<Match>> getMatch(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<Unit>> deleteMatch(Guid id)
        {
            return await Mediator.Send(new Delete.Command{Id = id});
        }
        
    }
}