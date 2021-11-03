using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourListController : ControllerBase
    {
        private readonly TravelDbContext _context;
        public TourListController(TravelDbContext travelDbContext)
        {
            _context = travelDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourLists);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourList tourList)
        {
            await _context.TourLists.AddAsync(tourList);
            await _context.SaveChangesAsync();
            return Ok(tourList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var tourList = _context.TourLists.SingleOrDefault(p => p.Id == id);
            if (tourList == null)
                return NotFound();
            _context.TourLists.Remove(tourList);
            await _context.SaveChangesAsync();
            return Ok(tourList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
        {
            _context.Update(tourList);
            await _context.SaveChangesAsync();
            return Ok(tourList);
        }
        
    }
}
