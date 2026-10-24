using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RACEDAY_PART3_.Data;
using RACEDAY_PART3_.Models;
using RACEDAY_PART3_.Models.Entites;
using System.ComponentModel.DataAnnotations;

namespace RACEDAY_PART3_.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public UserController(ApplicationDBContext dBContext )
        {
            this.dBContext = dBContext;
        }

        //Adding a new user
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Adding a new user
        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel viewModel)
        {
            var users = new Users
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                PasswordHash = viewModel.PasswordHash,
                Role = viewModel.Role
            };

            await dBContext.Users.AddAsync(users);

            //It saves all the changes in the database
            await dBContext.SaveChangesAsync();

            return View();
        }
    }
}
