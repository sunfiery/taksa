using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaksaCheckIn.Controllers.Base;

namespace TaksaCheckIn.Controllers
{
    public class GroupController : ApiControllerBase
    {
        private IDataRepository<Group> _repository;
        public GroupController(IDataRepository<Group> repository, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _repository.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}", Name = "GetGroup")]
        public async Task<IActionResult> Get(int id)
        {
            Group group = await _repository.GetAsync(id);
            if (group == null) return NotFound("The Group record couldn't be found.");

            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Group group)
        {
            if (group == null) return BadRequest("Group is null.");

            await _repository.AddAsync(group);
            return CreatedAtRoute("GetGroup", new { Id = group.ID }, group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Group group)
        {
            if (group == null) return BadRequest("Group is null.");

            Group groupToUpdate = await _repository.GetAsync(id);
            if (groupToUpdate == null) return NotFound("Group could not be found.");

            await _repository.ChangeAsync(groupToUpdate, group);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Group group = await _repository.GetAsync(id);
            if (group == null) return BadRequest("Group is not found");

            await _repository.DeleteAsync(group);
            return NoContent();
        }
    }
}
