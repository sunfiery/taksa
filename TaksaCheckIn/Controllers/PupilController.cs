using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaksaCheckIn.Controllers.Base;

namespace TaksaCheckIn.Controllers
{
    public class PupilController : ApiControllerBase
    {
        private IDataRepository<Pupil> _repository;
        public PupilController(IDataRepository<Pupil> repository, IHttpContextAccessor httpContextAccessor)
             : base(httpContextAccessor)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Pupil> pupils = await _repository.GetAllAsync();
            return Ok(pupils);
        }

        [HttpGet("{id}", Name = "GetPupil")]
        public async Task<IActionResult> Get(int id)
        {
            Pupil pupil = await _repository.GetAsync(id);
            if (pupil == null) return NotFound("The Pupil record couldn't be found.");

            return Ok(pupil);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pupil pupil)
        {
            if (pupil == null) return BadRequest("Pupil is null.");

            await _repository.AddAsync(pupil);
            return CreatedAtRoute("GetPupil", new { Id = pupil.ID }, pupil);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pupil pupil)
        {
            if (pupil == null) return BadRequest("Pupil is null.");

            Pupil pupilToUpdate = await _repository.GetAsync(id);
            if (pupilToUpdate == null) return NotFound("Pupil could not be found.");

            await _repository.ChangeAsync(pupilToUpdate, pupil);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Pupil pupil = await _repository.GetAsync(id);
            if (pupil == null) return BadRequest("Pupil is not found.");

            await _repository.DeleteAsync(pupil);
            return NoContent();
        }
    }
}
