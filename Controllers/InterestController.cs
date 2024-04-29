using Labb3APIv2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersoModels;
using System.Linq.Expressions;

namespace Labb3APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IHobbyRepository<Interest> _repo;

        public InterestController(IHobbyRepository<Interest> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Interest>> GetAllInterest()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retieve data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetOneInterest(int id)
        {
            try
            {
                var result = await _repo.GetSingel(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }catch(Exception){

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retieve data from database.");
            }
        }
        [HttpGet("person/{id:int}")]
        public async Task<ActionResult<Interest>> GetSpecificPersons(int personId)
        {
            try
            {
                var result = await _repo.GetSpecificPersonInfo(personId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error to retrive data from database");
            }
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Interest>> Search(string name)
        {
            try
            {
                var result = await _repo.Search(name);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from database");
            }
        }



        [HttpDelete("{id:int}")]
        public async  Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var personToDelete = await _repo.GetSingel(id);
                if(personToDelete == null)
                {
                    return NotFound($"Interest with Id {id} not found to delete.");
                }
                return await _repo.Ddelete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest interest)
        {
            try
            {
                if(interest == null)
                {
                    return BadRequest();
                }
                var result = await _repo.Add(interest);
                return CreatedAtAction(nameof(GetOneInterest),
                    new { id = result.InterestId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error to create data in the Database.");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if(id != interest.InterestId)
                {
                    return BadRequest("Id does not match");
                }
                var interestToUpdate = await _repo.GetSingel(id);
                if(interestToUpdate == null)
                {
                    return NotFound($"Interest with ID {id} not founded to update.");
                }
                return await _repo.Update(interest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update data into Database.");
            }
        }

    }
}
