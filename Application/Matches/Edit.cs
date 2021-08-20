using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Matches
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Match Match { get; set; }
        }

        // public class CommandValidator : AbstractValidator<Command>
        // {
        //     public CommandValidator()
        //     {
        //         RuleFor(x => x.Title).NotEmpty();
        //         RuleFor(x => x.Description).NotEmpty();
        //         RuleFor(x => x.Category).NotEmpty();
        //         RuleFor(x => x.Date).NotEmpty();
        //         RuleFor(x => x.City).NotEmpty();
        //         RuleFor(x => x.Venue).NotEmpty();
        //     }
        // }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext _context { get; }
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var match = await _context.Matches.FindAsync(request.Match.Id);

                _mapper.Map(request.Match, match);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("problem saving changes");
            }
        }
    }
}