using Microsoft.AspNetCore.Mvc;
using MovieStoreMVC.Models.DTO;
using MovieStoreMVC.Repositories.Abstract;

namespace MovieStoreMVC.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationServices authService;
        public UserAuthenticationController(IUserAuthenticationServices authService)
        {
            this.authService = authService;
        }
        //We will create a user with admin rights.after that we are going to comment this method 
        //because we need onlyone user in this application
        public async Task<IActionResult>  Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Name = "Kyaw",
                Password = "Admin@123",
                PasswordConfirm = "Admin@123",
                Role = "Admin"
            };
            var result = await authService.RegisterAsync(model);
           
            return Ok(result.Message);
        }
    }
}
