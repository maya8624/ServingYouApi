using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServingyouApi.Data;
using ServingyouApi.Dtos;
using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServingyouApi.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly IMemberApiRepo repository;
        private readonly IMapper mapper;

        public MemberApiController(IMemberApiRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberReadDto>>> GetAll()
        {
            var members = await repository.GetAllAsync();

            return Ok(mapper.Map<IEnumerable<MemberReadDto>>(members));
        }

        [HttpGet("{id}", Name = "GetMember")]
        public async Task<ActionResult<MemberReadDto>> GetMember(int id)
        {
            var member = await repository.GetMemberAsync(id);

            if (member != null)
            {
                return Ok(mapper.Map<MemberReadDto>(member));
            }

            return NotFound();
        }

        // POST api/members
        [HttpPost]
        public async Task<ActionResult<MemberReadDto>> PostMember(MemberCreateDto memberCreateDto)
        {
            var member = mapper.Map<Member>(memberCreateDto);
            member.DateRegistered = DateTime.Now;
            member.IsDeleted = false;

            await repository.PostMemberAsync(member);
            await repository.SaveChangesAsync();

            var memberReadDto = mapper.Map<MemberReadDto>(member);

            return CreatedAtAction(nameof(GetMember), new { id = memberReadDto.Id }, memberReadDto);
        }
    }
}