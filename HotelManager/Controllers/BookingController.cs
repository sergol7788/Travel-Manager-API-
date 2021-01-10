using HotelManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks; 
using System.Collections;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

     
      private readonly ApplicationDatabaseContext _appContext;

        public BookingController(ApplicationDatabaseContext appContext)
        {

            _appContext = appContext;
        }


       
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> AddEntry([FromBody] Booking booking)
        {
            _appContext.Add(booking);

            await _appContext.SaveChangesAsync();

            return Created($"api/Booking/{0} created!", booking.HotelName);
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public  ActionResult<IEnumerable> GetEntries(string hotelName)
        {
            var list = _appContext.Bookings.Where(d => d.HotelName.Contains(hotelName)).ToList();
             
                return  list;
        }
    }
}
