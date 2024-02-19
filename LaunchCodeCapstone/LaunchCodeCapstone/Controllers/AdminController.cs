using LaunchCodeCapstone.Models.ViewModels;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace LaunchCodeCapstone.Controllers
{
    //if you want to test the functionality of this, just comment out the authorize decoration and run. willl continue to work on it.
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;
        public AdminController(IUserRepository userRepository,
            UserManager<IdentityUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        [HttpGet]
         public async Task<IActionResult> List()
        {
            //get a list of all user in the database from the repo
            var users = await userRepository.GetAll();

            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();
            foreach (var user in users)
            {
                usersViewModel.Users.Add(new Models.ViewModels.User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    EmailAddress = user.Email
                }
                );
            }

            return View(usersViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            
            if(user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if(result != null && result.Succeeded)
                {
                    return RedirectToAction("List", "Admin");
                }
            }
            return View();
        }
    }
}
