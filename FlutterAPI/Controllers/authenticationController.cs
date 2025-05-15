
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context,
            UserManager<Users> UserManager, SignInManager<Users> SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _context = context;
        }

        //Register Controller
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserModel UserModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //user instance
            var users = new Users
            {
                UserName = UserModel.UserEmail,
                Email = UserModel.UserEmail,
                UMID = UserModel.UMID,
            };

            //hasher
            var hasher = await _userManager.CreateAsync(users, UserModel.UserPassword);

            //Conditional statement for the hasher
            if(!hasher.Succeeded)
                return BadRequest(hasher.Errors);
           

            //ActionLog instance
            string message = $"{UserModel.UserEmail} has registered";
            var actionlog = ActionLogController.
                ActionLogInput(message, UserModel.UserEmail, UserModel.UserType, 
                UserModel.UserID);

            _context.ActionLog.Add(actionlog);
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }

        //Log-in Controller
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel UsersModel)
        {
            //Query for the hasher and user
             var result = await _signInManager.PasswordSignInAsync(
            UsersModel.UserEmail, UsersModel.UserPassword, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Invalid Username and Password");

            //Action Log instance
            string message = $"{UsersModel.UserEmail} has logged in";
            var actionlog = ActionLogController.ActionLogInput(message, UsersModel.UserEmail, UsersModel.UserType, UsersModel.UserID);

            //Add action log to the databases
            _context.ActionLog.Add(actionlog);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Login successful",
                username = UsersModel.UserEmail
            });
        }
    }
}
