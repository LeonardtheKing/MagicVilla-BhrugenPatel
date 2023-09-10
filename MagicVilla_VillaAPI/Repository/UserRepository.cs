using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;


        public UserRepository(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        //public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        //{
        //    var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() );
        //    bool isValid = await _usermanager.CheckPasswordAsync(user, loginRequestDTO.Password);
        //    if (user == null || isValid==false)
        //    {
        //        return new LoginResponseDTO()
        //        {
        //            Token = "",
        //            User = null
        //        };
        //    }
        //    //If user was found generate JWT Token
        //    var roles = await _usermanager.GetRolesAsync(user);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(secretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString()),
        //            new Claim(ClaimTypes.Role, roles.FirstOrDefault()),

        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
        //    {
        //        Token = tokenHandler.WriteToken(token),
        //        User = _mapper.Map<UserDTO>(user),
        //        Role=roles.FirstOrDefault(),
        //    };
        //    return loginResponseDTO;

        //}
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            // Find the user by username (case-insensitive)
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            //var user = await _usermanager.FindByNameAsync(loginRequestDTO.UserName);

            if (user == null)
            {
                // User not found
                return new LoginResponseDTO
                {
                    Token = "",
                    User = null
                };
            }

            // Verify the password
            var isPasswordValid = await _usermanager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (!isPasswordValid)
            {
                // Password is incorrect
                return new LoginResponseDTO
                {
                    Token = "",
                    User = null
                };
            }

            // If user was found and password is correct, generate JWT Token
            var roles = await _usermanager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            // Add all roles to claims (if there are multiple)
            new Claim(ClaimTypes.Role, string.Join(",", roles)),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginResponseDTO = new LoginResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),
                Role = roles.FirstOrDefault()
            };

            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Email = registrationRequestDTO.UserName,
                NormalizedEmail = registrationRequestDTO.UserName.ToUpper()
                //PasswordHash = registrationRequestDTO.Password,  
            };
            try
            {
                var result = await _usermanager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    if (!_rolemanager.RoleExistsAsync("admin").GetAwaiter().GetResult()) 
                    {
                        await _rolemanager.CreateAsync(new IdentityRole("admin"));
                        await _rolemanager.CreateAsync(new IdentityRole("customer"));
                    }
                    //await _usermanager.AddToRoleAsync(user, "admin");
                    var userToReturn = _db.ApplicationUsers
                      .FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
                    //return _mapper.Map<UserDTO>(userToReturn);
                    return new UserDTO()
                    {
                        ID = userToReturn.Id,
                        UserName = userToReturn.UserName,
                        Name = userToReturn.Name
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return new UserDTO();
        }


        //public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        //{
        //    // Validate registrationRequestDTO
        //    var validationResult = ValidateRegistrationRequest(registrationRequestDTO);
        //    if (!validationResult.IsValid)
        //    {
        //        // Handle validation errors (e.g., return error messages)
        //        return new UserDTO { ErrorMessage = validationResult.ErrorMessage };
        //    }

        //    ApplicationUser user = new()
        //    {
        //        UserName = registrationRequestDTO.UserName,
        //        Name = registrationRequestDTO.Name,
        //        Email = registrationRequestDTO.UserName,
        //        NormalizedEmail = registrationRequestDTO.UserName.ToUpper()
        //    };

        //    try
        //    {
        //        var result = await _usermanager.CreateAsync(user, registrationRequestDTO.Password);

        //        if (result.Succeeded)
        //        {
        //            await _usermanager.AddToRoleAsync(user, "admin");

        //            // Retrieve the user from the database after creation
        //            var userToReturn = await _usermanager.FindByNameAsync(registrationRequestDTO.UserName);

        //            return _mapper.Map<UserDTO>(userToReturn);
        //        }
        //        else
        //        {
        //            // Handle registration failure (e.g., return error messages)
        //            return new UserDTO { ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description)) };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions (e.g., log the error)
        //        return new UserDTO { ErrorMessage = "An error occurred during user registration." };
        //    }
        //}

        //private RegistrationValidationResult ValidateRegistrationRequest(RegistrationRequestDTO registrationRequestDTO)
        //{
        //    var validationResult = new RegistrationValidationResult();

        //    // Add validation rules here
        //    if (string.IsNullOrEmpty(registrationRequestDTO.UserName))
        //    {
        //        validationResult.IsValid = false;
        //        validationResult.ErrorMessage = "Username is required.";
        //    }

        //    if (string.IsNullOrEmpty(registrationRequestDTO.Name))
        //    {
        //        validationResult.IsValid = false;
        //        validationResult.ErrorMessage = "Name is required.";
        //    }

        //    if (string.IsNullOrEmpty(registrationRequestDTO.Password))
        //    {
        //        validationResult.IsValid = false;
        //        validationResult.ErrorMessage = "Password is required.";
        //    }

        //    // Add more validation rules as needed

        //    return validationResult;
        //}



    }
}
