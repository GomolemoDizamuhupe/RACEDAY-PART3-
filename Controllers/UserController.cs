using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RACEDAY_PART3_.Data;
using RACEDAY_PART3_.Models;
using RACEDAY_PART3_.Models.Entites;
using System.ComponentModel.DataAnnotations;

namespace RACEDAY_PART3_.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public UserController(ApplicationDBContext dBContext)
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await dBContext.Users.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id) 
        {
            var user = await dBContext.Users.FindAsync(Id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users viewModel) 
        {
            var user = await dBContext.Users.FindAsync(viewModel.UserId);

            if (user is not null) 
            { 
                user.Name = viewModel.Name;
                user.Surname = viewModel.Surname;
                user.Email = viewModel.Email;
                user.PasswordHash = viewModel.PasswordHash;
                user.Role = viewModel.Role;

                await dBContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Users viewModel) 
        {
            var user = await dBContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == viewModel.UserId);

            if (user is not null) 
            {
                dBContext.Users.Remove(viewModel);
                await dBContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "User");
        }

    }
}
