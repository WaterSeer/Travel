using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Application.TourPackages.CreateTourPackage;
using Travel.Application.TourPackages.UpdateTourPackage;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]    
    public class TourPackagesController : ApiController
    {
        private readonly TravelDbContext _context;

        public TourPackagesController(TravelDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_context.TourPackages);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] TourPackage tourPackage)
        //{
        //    await _context.TourPackages.AddAsync(tourPackage);
        //    await _context.SaveChangesAsync();
        //    return Ok(tourPackage);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromBody] int id)
        //{
        //    var tourPackage = _context.TourPackages.SingleOrDefault(p => p.Id == id);
        //    if (tourPackage == null)
        //        return NotFound();
        //    _context.TourPackages.Remove(tourPackage);
        //    await _context.SaveChangesAsync();
        //    return Ok(tourPackage);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourPackage tourPackage)
        //{
        //    _context.Update(tourPackage);
        //    await _context.SaveChangesAsync();
        //    return Ok(tourPackage);
        //}





        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTourPackageCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTourPackageCommand command)
        {

            await Mediator.Send(command);
        }
       
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTourPackageCommand command)
        {

            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await Mediator.Send(new DeleteTourPackageCommand { Id = id });
        }


    }
}
