using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    
    [Route("api/v{version:apiVersion}/villaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<VillaNumberAPIController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _villaNumberRepository;

        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger, ApplicationDbContext db, IMapper mapper, IVillaNumberRepository villaRepository)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _villaNumberRepository = villaRepository;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                _logger.LogInformation("Getting all VillaNumbers");
                IEnumerable<VillaNumber> villaList = await _villaNumberRepository.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogError($"Invalid Id: {id}");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villa = await _villaNumberRepository.GetAsync(u => u.VillaNo == id);

                if (villa == null )
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villa);
                _response.IsSuccess = true;
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

        [HttpPost("VillaNumbers")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO villaNumberCreateDTO)
        {
            try
            {
                VillaNumber model = await _villaNumberRepository.CreateVillaNumberAsync(villaNumberCreateDTO);
            
                // Assuming you have a route named "GetVilla" defined in your route configuration
                _response.Result = _mapper.Map<VillaNumberDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetVillaNumber", new { id = model.VillaNo }, _response);

        }
            catch (Exception ex)
            {
                LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
    }
}


        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.VillaNumber.FirstOrDefaultAsync(u => u.VillaNo == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.VillaNumber.Remove(villa);
            await _db.SaveChangesAsync();

            //_response.Result = _mapper.Map<VillaNumberDTO>(villa);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);

        }

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberDTO villaNumberUpdateDTO)
        {
            try
            {
                if (villaNumberUpdateDTO == null || id != villaNumberUpdateDTO.VillaNo)
                {
                    return BadRequest();
                }

                VillaNumber model = _mapper.Map<VillaNumber>(villaNumberUpdateDTO);

                await _villaNumberRepository.UpdateAsync(model);
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


        [HttpPatch("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var villa = _villaNumberRepository.GetAsync(c => c.VillaNo == id);
            VillaNumberUpdateDTO villaDTO = _mapper.Map<VillaNumberUpdateDTO>(villa);

            if (villa == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(villaDTO, ModelState);
            VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _villaNumberRepository.UpdateAsync(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }
        private void LogException(Exception ex)
        {
            // Implement your logging logic here
            _logger.LogError(ex, "An exception occurred.");

        }

    }
}
