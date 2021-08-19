using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Matches
{
    public class List
    {
        public class Query : IRequest<List<Match>> { }

        public class Handler : IRequestHandler<Query, List<Match>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Match>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Matches.ToListAsync();
            }
        }
    }
}