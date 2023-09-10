using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{version:apiVersion}/UsersAuth")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;
        public UserAPIController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._response = new APIResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var LoginResponse = await _userRepo.Login(model);
            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess= false;
                _response.ErrorMessages.Add("username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode=HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = LoginResponse;
            return Ok(_response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool ifUserNameIsUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameIsUnique)
            {
            _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Username already exists");
            return BadRequest(_response);
            }
            var user = await _userRepo.Register(model);
            if(user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        
        
    }
}
