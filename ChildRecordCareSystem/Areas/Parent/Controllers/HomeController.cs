using ChildRecordCareSystem.Areas.Identity.Data;
using ChildRecordCareSystem.Filters;
using ChildRecordCareSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChildRecordCareSystem.Areas.Parent.Controllers
{
    [Area("Parent")]
    [AuthenticationFilter]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ChildRecordCareSystemContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ChildRecordCareSystemUser> _userManager;

        public HomeController(IWebHostEnvironment webHostEnvironment, ChildRecordCareSystemContext context, IHttpContextAccessor httpContextAccessor, UserManager<ChildRecordCareSystemUser> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Account()
        {
            return View();
        }
        public async Task<IActionResult> Dashboard()
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(currentUser))
            {
                var user = await _userManager.FindByIdAsync(currentUser);

                if (user != null)
                {
                    ViewBag.FullName = user.FullName;
                }
            }
            else
            {
                 return RedirectToAction("Login", "Account", new { area = "" });
            }

            // Fetch children where UserId matches the current user
            var children = await _context.Children
                .Where(c => c.UserId == currentUser)
                .ToListAsync();

            return View(children);  
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var child = await _context.Children.FindAsync(id);
                if (child == null)
                {
                    return NotFound();
                }

                _context.Children.Remove(child);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }


        public IActionResult ChildRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ChildVM model)
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            string uniqueFileName = null;

            try
            {
                if (model.ChildProfilePath != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "childimage");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ChildProfilePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ChildProfilePath.CopyToAsync(fileStream);
                    }
                }

 
                var child = new Child
                {
                    UserId = currentUser,
                    FullName = model.FullName,
                    DOB = model.DOB,
                    Gender = model.Gender,
                    City = model.City,
                    Country = model.Country,
                    PhoneNumber = model.PhoneNumber,
                    ChildProfilePath = uniqueFileName,
                    Email = model.Email
                };

                _context.Children.Add(child);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard", "Home", new { area = "Parent" });
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError(string.Empty, "An error occurred while creating the child. Please try again.");

                // Optionally, you might want to return the same view with the model to allow the user to correct input
                return View(model);
            }
        }
        public IActionResult ChildRecord()
        {
            return View();
        }

    }
}
