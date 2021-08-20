using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Matches
{
    public class Create
    {
        public class Command : IRequest
        {
            public Match Match { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext _context { get; }
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Matches.Add(request.Match);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("problem saving changes");

            }
        }
    }
}