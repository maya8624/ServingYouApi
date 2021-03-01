using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServingyouApi.Data;
using ServingyouApi.Dtos;
using ServingyouApi.Models;
using Newtonsoft.Json;

namespace ServingyouApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderApiRepo repository;
        private readonly IMemberApiRepo memberApiRepo;
        private readonly IMapper mapper;

        public OrderApiController(IMemberApiRepo memberApiRepo, IOrderApiRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.memberApiRepo = memberApiRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
        {
            var orders = await repository.GetAllAsync();

            return Ok(mapper.Map<IEnumerable<OrderReadDto>>(orders));
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            var order = await repository.GetOrderAsync(id);

            if (order != null)
            {
                return Ok(mapper.Map<OrderReadDto>(order));
            }

            return NotFound();
        }

        // POST api/orders
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> PostOrder(OrderCreateDto orderCreateDto)
        {
            var order = mapper.Map<Order>(orderCreateDto);
            
            // get member Id
            var member = await memberApiRepo.GetMemberByEmailAsync(orderCreateDto.Email);
            if (member == null)
            {
                return NotFound("Member is not found.");
            }

            order.MemberId = member.Id;

            await repository.PostOrderAsync(order);
            await repository.SaveChangesAsync();
                        
            var orderMenus = orderCreateDto.OrderMenus;

            foreach (var item in orderMenus)
            {
                var orderMenu = new OrderMenu
                {
                    OrderId = order.Id,
                    MenuId = item.MenuId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    DateCreated = DateTime.Now
                };

                // add order details
                await repository.AddOrderMenuAsync(orderMenu);
                await repository.SaveChangesAsync();
            }

            var orderReadDto = mapper.Map<OrderReadDto>(order);

            return CreatedAtAction(nameof(GetOrder), new { id = orderReadDto.Id }, orderReadDto);            
        }
    }
}
