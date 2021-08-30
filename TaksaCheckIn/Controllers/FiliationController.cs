using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaksaCheckIn.Controllers.Base;

namespace TaksaCheckIn.Controllers
{
    public class FiliationController : ApiControllerBase
    {
        private IDataRepository<Filiation> _repository;
        public FiliationController(IDataRepository<Filiation> repository, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filiations = await _repository.GetAllAsync();
            return Ok(filiations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Filiation filiation = await _repository.GetAsync(id);
            if (filiation == null) return NotFound("The Filiation record couldn't be found.");

            return Ok(filiation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Filiation filiation)
        {
            if (filiation == null) return BadRequest("Filiation is null.");

            await _repository.AddAsync(filiation);
            return CreatedAtRoute("Get", new { Id = filiation.ID }, filiation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Filiation filiation)
        {
            if (filiation == null) return BadRequest("Filiation is null.");

            Filiation filiationToUpdate = await _repository.GetAsync(id);
            if (filiationToUpdate == null) return NotFound("Filiation could not be found.");

            await _repository.ChangeAsync(filiationToUpdate, filiation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Filiation filiation = await _repository.GetAsync(id);
            if (filiation == null) return BadRequest("Filiation is not found");

            await _repository.DeleteAsync(filiation);
            return NoContent();
        }
    }
}
