using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{version:apiVersion}/villaAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _villaRepository;

        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db, IMapper mapper, IVillaRepository villaRepository)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _villaRepository = villaRepository;
            this._response = new();

        }

        [HttpGet]
        [ResponseCache(Duration =(60))]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<APIResponse>> GetVillas([FromQuery(Name = "filterOccupancy")] int? occupancy, [FromQuery] string? search,int pageSize=4,int pageNumber=3)
        {
            try
            {
                _logger.LogInformation("Getting all Villas");
                IEnumerable<Villa> villaList;

                if (occupancy > 0)
                {
                    villaList = await _villaRepository.GetAllAsync(occupancy);
                }
                else
                {
                    villaList = await _villaRepository.GetAllAsync(occupancy);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    // Perform case-insensitive search by converting both search and villa name to lowercase
                    string searchTerm = search.ToLower();
                    villaList = villaList.Where(u => u.Amenity.ToLower().Contains(searchTerm));
                }
                Pagination pagination = new() { PageNmber = pageNumber ,PageSize=pageSize};

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }


        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogError($"Invalid Id: {id}");
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villa = await _villaRepository.GetAsync(u => u.VillaId == id);

                if (villa == null )
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                } 
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.IsSuccess=true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("Villas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {
            try
            {
                Villa model = await _villaRepository.CreateVillaAsync(villaCreateDTO);
                // Assuming you have a route named "GetVilla" defined in your route configuration
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<VillaDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = model.VillaId }, _response);

            }
            catch (Exception ex)
            {
                LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }


        private void LogException(Exception ex)
        {
            // Implement your logging logic here
            _logger.LogError(ex, "An exception occurred.");

        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="custom")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.VillaId == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            _response.Result = _mapper.Map<VillaDTO>(villa);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);

        }


        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaDTO villaUpdateDTO)
        {
            try
            {
                if (villaUpdateDTO == null || id != villaUpdateDTO.VillaId)
                {
                    return BadRequest();
                }

                Villa model = _mapper.Map<Villa>(villaUpdateDTO);

                await _villaRepository.UpdateAsync(model);
                await _db.SaveChangesAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return NoContent();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpPatch("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var villa = _villaRepository.GetAsync(c => c.VillaId == id);
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            if (villa == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = _mapper.Map<Villa>(villaDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _villaRepository.UpdateAsync(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }



    }
}
