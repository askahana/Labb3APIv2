using Labb3APIv2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersoModels;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Labb3APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //private IHobbyRepository<Person> _repo;
        //public PersonController(IHobbyRepository<Person> repo)
        //{
        //    _repo = repo;
        //}

        private IPerson _repo;
        public PersonController(IPerson repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetAllPeople()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database");
            }
        }


      
        [HttpGet("limited/{num}")]

        public async Task<IActionResult> GetLimitedNum(int num)
        {
            try
            {
                return Ok(await _repo.GetLimitedNum(num));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database");
            }
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult<Person>> GetOnePerson(int id)
        {
            try
            {
                var result = await _repo.GetSingelPerson(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrieve data from database");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Person>> SearchPerson(string name)
        {
            try
            {
                var result = await _repo.Serach(name);
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
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _repo.GetSingelPerson(id);
                if(personToDelete == null)
                {
                    return NotFound($"Person with Id {id} wan not found to delete.");
                }
                return await _repo.Ddelete(id);


            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to delete data from Database.");
            }
        }

        [HttpPost]
        public async Task <ActionResult<Person>> CreateNewPerson(Person newPerson)
        {
            try
            {
                if(newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _repo.Add(newPerson);
                return CreatedAtAction(nameof(GetOnePerson),
                    new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to create data in the Database");
            }
        }


      

        [HttpPut("addInterest/{id:int}")]
        public async Task<ActionResult<Person>> UpdatePersonInterest(int id, Interest interest)
        {
            try
            {
                var personToUpdate = await _repo.GetSingelPerson(id);
            
                if(personToUpdate == null)
                {
                    return NotFound($"ID {id} not founded to update.");
                }
                return await _repo.AddInterestToPerson(id, interest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to update data into Database.");
            }
        }

        [HttpPut("person/{id:int}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest("ID doesnt match.");
                }
                var personToUpdate = await _repo.GetSingelPerson(id);
                if (personToUpdate == null)
                {
                    return NotFound($"ID {id} not founded to update.");
                }
                return await _repo.Update(person);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to update data into Database.");
            }
        }





    }
}
