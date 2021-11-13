using MediatR;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class ExportToursQuery : IRequest<ExportToursVm>
    {
        public int ListId { get; set; }
    }

    public class   ExportToursQueryHandler : IRequestHandler<ExportToursQuery, ExportToursVm>
    {
        public async Task<ExportToursVm> Handle(ExportToursQuery exportToursQuery, CancellationToken cancellationToken)
        {
            var vm = new ExportToursVm();

            vm.ContentType = "text/csv";
            vm.FileName = "TourPackage.csv";
            return await Task.FromResult(vm);
        }
    }
}
