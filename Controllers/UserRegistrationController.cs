using Microsoft.AspNetCore.Mvc;
using RegistrationForm.DAL;
//using Microsoft.Data;
//using Microsoft.SqlClientl;
using RegistrationForm.Models;


namespace RegistrationForm.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly UserDal _userDal;

        public UserRegistrationController(UserDal userDal)
        {
            _userDal = userDal;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserRegistration Reg)
        {
            if (ModelState.IsValid)
            {
                // Call the UserInsert method of UserDal to insert user data
                int rowsAffected = _userDal.UserInsert(Reg);
                if (rowsAffected > 0)
                {
                    ViewData["Message"] = "New Employee data saved";
                   
                }
                else
                {
                    ViewData["ErrorMessage"] = "Failed to save employee data";
                }
            }
            // If model state is not valid, return to the same view with validation errors
            return View(Reg);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Emaild, string Password)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected = _userDal.UserValid(Emaild, Password);
                if (rowsAffected > 0)
                {
                    ViewData["SuccessMessage"] = "Login Successful";
                }
                else
                {
                    ViewData["ErrorMessage"] = "Invalid Credentials";
                }
            }
            // If model state is not valid, return to the same view with validation errors
            return View();
        }


    }
}
