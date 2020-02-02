using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataDisplay.Api.WebApi.Extension;
using DataDisplay.Api.WebApi.Service.Contract;
using DataDisplay.Application.Contract.Service;

namespace DataDisplay.Api.WebApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        protected readonly ILogger<AuthenticateController> Logger;
        protected readonly UserManager<IdentityUser> UserManager;
        protected readonly SignInManager<IdentityUser> SignInManager;
        protected readonly IUserService UserService;
        protected readonly IJwtTokenService JwtTokenService;
        protected readonly ITokenLoginService TokenLoginService;

        public AuthenticateController(ILogger<AuthenticateController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserService userService, IJwtTokenService jwtTokenService, ITokenLoginService tokenLoginService)
        {
            Logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
            UserService = userService;
            JwtTokenService = jwtTokenService;
            TokenLoginService = tokenLoginService;
        }

        [HttpPost("register", Name = "Register")]
        public async Task<IActionResult> Register(RegisterModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = model.Username ?? model.Email, 
                Email = model.Email
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(error => ModelState.AddModelError(string.Empty, error.Description));

                return BadRequest(ModelState);
            }

            var userFound = await UserManager.FindByEmailAsync(model.Email);
            await UserService.Create(userFound.Id, cancellationToken);

            Logger.LogInformation("User created a new account with password.");
            
            var jwtToken = await JwtTokenService.Generate(user.Id);

            return Ok(jwtToken);
        }
        
        [HttpPost]
        [Route("login/{token}")]
        public async Task<IActionResult> Signin([FromRoute] Guid token, CancellationToken cancellationToken)
        {
            var loginToken = await TokenLoginService.RecoverLoginToken(token);
            if (loginToken == null) return Unauthorized();

            var user = await UserManager.FindByIdAsync(loginToken.IdentityUserId);
            if (user == null) return Unauthorized();
    
            var jwtToken = await JwtTokenService.Generate(user.Id);

            return Ok(jwtToken);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }

            var user = await UserManager.FindByNameAsync(model.Username) ??
                       await UserManager.FindByEmailAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }

            var result = await UserManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }

            Logger.LogInformation("User logged in.");

            var jwtToken = await JwtTokenService.Generate(user.Id);

            return Ok(jwtToken);
        }

        [Authorize]
        [HttpGet("test")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            var user = User;

            var id = User.GetId();

            return Ok(user.Claims.ToList());
        }
    }

    public class LoginModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
    
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}