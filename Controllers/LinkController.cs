using Labb3APIv2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersoModels;

namespace Labb3APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private IHobbyRepository<Link> _repo;
        public LinkController(IHobbyRepository<Link> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<Link>> GetAllLinks()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retirbe data from database.");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Link>> GetOneLink(int id)
        {
            try
            {
                var result = await _repo.GetSingel(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);  

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retirbe data from database.");
            }
        }
        
        [HttpGet("{name}")]
        public async Task<ActionResult<Link>> SearchLink(string name)
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
        public async Task<ActionResult<Link>> DeleteLink(int id)
        {
            try
            {
                var linkToDelete = await _repo.GetSingel(id);
                if(linkToDelete == null)
                {
                    return NotFound($"Link with Id {id} was not found to delete.");
                }
                return await _repo.Ddelete(id);

            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from database.");
            }
        }

        [HttpPost]

        public async Task<ActionResult<Link>> CreateNewLink(Link newLink)
        {
            try
            {
                if(newLink == null)
                {
                    return BadRequest();
                }
                var createLink = await _repo.Add(newLink);
                return CreatedAtAction(nameof(GetOneLink),
                    new { id = createLink.LinkId }, createLink);
            }catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to crate data into database.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Link>> UpdateLink(int id, Link link)
        {
            try
            {
                if (id != link.LinkId)
                {
                    return BadRequest("The ID does not match.");
                }
                var linkToUpdate = await _repo.GetSingel(id);
                if (linkToUpdate == null)
                {
                    return NotFound($"Link with Id {id} was not found to update.");
                }
                return await _repo.Update(link);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to update data into Database.");
            }
        }
    }
}
