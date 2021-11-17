using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Application.TourLists.CreateTourList;
using Travel.Application.TourLists.DeleteTourList;
using Travel.Application.TourLists.Queries.ExportTours;
using Travel.Application.TourLists.Queries.GetTours;
using Travel.Application.TourLists.UpdateTourList;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourListController : ApiController
    {
        //    private readonly TravelDbContext _context;
        //    public TourListController(TravelDbContext travelDbContext)
        //    {
        //        _context = travelDbContext;
        //    }

        //    [HttpGet]
        //    public IActionResult Get()
        //    {
        //        return Ok(_context.TourLists);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Create([FromBody] TourList tourList)
        //    {
        //        await _context.TourLists.AddAsync(tourList);
        //        await _context.SaveChangesAsync();
        //        return Ok(tourList);
        //    }

        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> Delete([FromBody] int id)
        //    {
        //        var tourList = _context.TourLists.SingleOrDefault(p => p.Id == id);
        //        if (tourList == null)
        //            return NotFound();
        //        _context.TourLists.Remove(tourList);
        //        await _context.SaveChangesAsync();
        //        return Ok(tourList);
        //    }

        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
        //    {
        //        _context.Update(tourList);
        //        await _context.SaveChangesAsync();
        //        return Ok(tourList);
        //    }
        [HttpGet]
        public async Task<ActionResult<ToursVm>> Get()
        {
            return await Mediator.Send(new GetToursQuery());
        }
        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportToursQuery { ListId = id });
            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTourListCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTourListCommand command)
        {
            await Mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTourListCommand { Id = id });
        }





        
    }
}
