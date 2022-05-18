using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlaBlaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlaBlaController : ControllerBase
    {
        private readonly DataContext _context;
        public BlaBlaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlaBla>>> Get()
        {
            return Ok(await _context.BlaBlas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<BlaBla>>> Get(int id)
        {
            var bla = await _context.BlaBlas.FindAsync(id);
            if (bla == null)
                return BadRequest("Nix da junge");
            return Ok(bla);
        }

        [HttpPost]
        public async Task<ActionResult<List<BlaBla>>> AddBla(BlaBla bla)
        {
            _context.BlaBlas.Add(bla);
            await _context.SaveChangesAsync();

            return Ok(await _context.BlaBlas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BlaBla>>> ChangeBla(BlaBla request)
        {
            var bla = await _context.BlaBlas.FindAsync(request.ID);
            if (bla == null)
                return BadRequest("Nix da junge");

            bla.Name = request.Name;
            bla.FirstName = request.FirstName;
            bla.LastName = request.LastName;
            bla.Place = request.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.BlaBlas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BlaBla>>> Delete(int id)
        {
            var bla = await _context.BlaBlas.FindAsync(id);
            if (bla == null)
                return BadRequest("Nix da junge");
            _context.BlaBlas.Remove(bla);
            await _context.SaveChangesAsync();
            return Ok(await _context.BlaBlas.ToListAsync());
        }

    }
}
