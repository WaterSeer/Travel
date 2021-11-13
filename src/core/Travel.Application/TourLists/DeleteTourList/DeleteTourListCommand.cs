using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.DeleteTourList
{
    public class DeleteTourListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTourListCommandHandler : IRequestHandler<DeleteTourListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTourListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeleteTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists.Where(l => l.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            _context.TourLists.Remove(entity);
            await _context.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
