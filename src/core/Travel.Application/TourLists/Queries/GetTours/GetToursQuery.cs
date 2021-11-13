using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Dtos;

namespace Travel.Application.TourLists.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm> { }
    
    public class GetToursQueryHandler : IRequestHandler<GetToursQuery, ToursVm>
    {
        private DbContext _context = new DbContext
        public async Task<ToursVm> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            return new ToursVm
            {
                Lists = await _context.TourLists.ProjectTo<TourListDto>(IMapper.ConfigurationProvider).OrderBy(t => t.City).ToListAsync(cancellationToken)
            }
        }

       
}
