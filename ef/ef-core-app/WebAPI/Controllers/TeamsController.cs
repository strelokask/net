using Data;
using Domain;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models.Team;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly FootballLeageDbContext _context;

        public TeamsController(FootballLeageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TeamDto>), 200)]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            return await _context.Teams
                .ProjectToType<TeamDto>()
                //.Select(x => new TeamDto()
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //    CoachName = x.Coach.Name
                //})
                .ToListAsync();
        }
    }
}
