using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ResidenceController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residence>>> GetResidence()
        {
            var residence = await context.Residences
                            .Include(x => x.Immeubles)
                            .ToListAsync();
            return residence;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult> GetDashboard()
        {  
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(id == 0) return BadRequest("No User was found");
            Console.WriteLine(id);

            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id);

            var residence = await context.Residences
                            .Include(x => x.Immeubles)
                            .ThenInclude(x => x.Appartements)
                            .FirstOrDefaultAsync(x => x.ManagerId == id);

            if(residence == null) return BadRequest("No Residence was found");
            
            return Ok(new
            {
                ResidenceName = residence.Name,
                ImmeubleCount = residence.Immeubles.Count,
                AppartementCount = residence.Immeubles.Sum(i => i.Appartements.Count)
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<Residence>> CreateResidence(ResidenceDto residenceDto)
        {
            //if (await IsManager()!) return BadRequest("You are not the manager");
            var res = new Residence
            {
                Name = residenceDto.Name,
                ManagerId = residenceDto.ManagerId
            };

            context.Residences.Add(res);
            await context.SaveChangesAsync();

            return res;
        }

        [HttpPost("addimmeuble")]
        public async Task<ActionResult<Immeuble>> CreateImmeuble(ImmeubleDto immeubleDto)
        {
            //if (await IsManager()!) return BadRequest("You are not the manager")
            var imm = new Immeuble
            {
                Name = immeubleDto.Name,
                ResidenceId = immeubleDto.ResidenceId
            };

            context.Immeubles.Add(imm);
            await context.SaveChangesAsync();

            return imm;
        }

        [HttpGet("immeublelist/{id:int}")]
        public async Task<ActionResult<IEnumerable<Immeuble>>> ListImmeubleByResidenceId(int id)
        {
            var immeubles = await context.Immeubles
                .Where(x => x.ResidenceId == id)
                .Include(x => x.Appartements)
                .ToListAsync();
            return immeubles;
        }

        [HttpPost("addappartement")]
        public async Task<ActionResult<Appartement>> CreateAppartement(AppartementDto appartementDto)
        {
            //if (await IsManager()!) return BadRequest("You are not the manager");
            var numberExist = await context.Appartements
                                .Where(x => x.ImmeubleId == appartementDto.ImmeubleId)
                                .AnyAsync(x => x.Number == appartementDto.Number);
            if(numberExist) return BadRequest("This Appartement already exist");

            var app = new Appartement
            {
                Number = appartementDto.Number,
                ImmeubleId = appartementDto.ImmeubleId
            };

            context.Appartements.Add(app);
            await context.SaveChangesAsync();

            return app;
        }

        [HttpGet("appartlist/{id:int}")]
        public async Task<ActionResult<IEnumerable<Appartement>>> ListAppartementByResidenceId(int id)
        {
            var appart = await context.Appartements.Where(x => x.ImmeubleId == id).ToListAsync();
            return appart;
        }


        private async Task<bool> IsManager()
        {
            var user = await context.Users.AnyAsync(x => x.RoleId == 2);
            return user;
        }
    }
}