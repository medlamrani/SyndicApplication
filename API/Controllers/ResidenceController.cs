using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ResidenceController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residence>>> GetResidence()
        {
            var residence = await context.Residences.ToListAsync();
            return residence;
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

        [HttpPost("addappartement")]
        public async Task<ActionResult<Appartement>> CreateAppartement(AppartementDto appartementDto)
        {
            //if (await IsManager()!) return BadRequest("You are not the manager");
            var app = new Appartement
            {
                Number = appartementDto.Number,
                ImmeubleId = appartementDto.ImmeubleId
            };

            context.Appartements.Add(app);
            await context.SaveChangesAsync();

            return app;
        }


        private async Task<bool> IsManager()
        {
            var user = await context.Users.AnyAsync(x => x.RoleId == 2);
            return user;
        }
    }
}