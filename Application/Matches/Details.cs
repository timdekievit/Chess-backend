using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Matches
{
    public class Details
    {
        public class Query : IRequest<Match>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Match>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Match> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Matches.FindAsync(request.Id);
            }
        }
    }
}