using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ServingyouApi.Data;
using ServingyouApi.Dtos;
using ServingyouApi.Models;
using System.Threading.Tasks;

namespace ServingyouApi.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingApiRepo repository;
        private readonly IMapper mapper;

        public BookingsController(IBookingApiRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetAll()
        {
            var bookings = await repository.GetAllAsync();

            return Ok(mapper.Map<IEnumerable<BookingReadDto>>(bookings));
        }

        [HttpGet("{id}", Name = "GetBookingAsync")]
        public async Task<ActionResult<BookingReadDto>> GetBooking(int id)
        {
            var booking = await repository.GetBookingAsync(id);

            if (booking != null)
            {
                return Ok(mapper.Map<BookingReadDto>(booking));
            }

            return NotFound();
        }

        // POST api/bookings
        [HttpPost]
        public async Task<ActionResult<BookingReadDto>> PostBooking(BookingCreateDto bookingCreateDto)
        {
            var booking = mapper.Map<Booking>(bookingCreateDto);
            booking.DateCreated = DateTime.Now;            

            await repository.PostBookingAsync(booking);
            await repository.SaveChangesAsync();

            var bookingReadDto = mapper.Map<BookingReadDto>(booking);

            return CreatedAtAction(nameof(GetBooking), new { id = bookingReadDto.Id }, bookingReadDto);            
        }
    }
}
