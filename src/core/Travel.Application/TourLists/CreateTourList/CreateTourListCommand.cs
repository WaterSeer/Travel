using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Travel.Application.Common.Interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.CreateTourList
{
    public partial class CreateTourListCommand : IRequest<int>
    {
    }

    public class CreateTourListCommandHandler : IRequestHandler<CreateTourListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTourListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TourList { City = request.City };
            _context.TourLists.Add(entity);
            await _context.SaveChangeAsync(cancellationToken);
            return entity.Id;
        }
    }
}
