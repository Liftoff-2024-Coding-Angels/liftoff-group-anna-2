using LaunchCodeCapstone.Models.ViewModels;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace LaunchCodeCapstone.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly IUserRepository userRepository;

        public AdminController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

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

    }
}
