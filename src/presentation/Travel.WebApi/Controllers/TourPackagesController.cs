﻿using Microsoft.AspNetCore.Mvc;
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
    public class TourPackagesController : ControllerBase
    {
        private readonly TravelDbContext _context;

        public TourPackagesController(TravelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourPackages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourPackage tourPackage)
        {
            await _context.TourPackages.AddAsync(tourPackage);
            await _context.SaveChangesAsync();
            return Ok(tourPackage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var tourPackage = _context.TourPackages.SingleOrDefault(p => p.Id == id);
            if (tourPackage == null)
                return NotFound();
            _context.TourPackages.Remove(tourPackage);
            await _context.SaveChangesAsync();
            return Ok(tourPackage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourPackage tourPackage)
        {
            _context.Update(tourPackage);
            await _context.SaveChangesAsync();
            return Ok(tourPackage);
        }
    }
}