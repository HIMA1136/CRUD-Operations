using Category_Type_Project.Models;
using Category_Type_Project.Repositories;
using Category_Type_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Category_Type_Project.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ICategoryTypesRepository _categoryTypesRepository;
        private readonly UserManager<AppUser> _userManager;

        public CategoriesController(ApplicationDbContext context, IToastNotification toastNotification,
            ICategoriesRepository categoriesRepository, ICategoryTypesRepository categoryTypesRepository,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _toastNotification = toastNotification;
            _categoriesRepository = categoriesRepository;
            _categoryTypesRepository = categoryTypesRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _categoriesRepository.GetAllAsync (new[] { "Type" }) ;
          
            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ViewModel = new CategorisFormViewModel
            {
                Types = await _categoryTypesRepository.GetAllAsync()
            };

            return View(ViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategorisFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Types = await _categoryTypesRepository.GetAllAsync();
                return View("CategoryForm", model);
            }
          
       

            var category = new Category
            {
                Name = model.Name,
                TypeId = model.TypeId,
                CanScale = model.CanScale,
                CreatedBy = _userManager.GetUserId(HttpContext.User),

            };

            var addedCategory = await _categoriesRepository.AddAsync(category);

            _toastNotification.AddSuccessToastMessage("Category Created Successfauly");
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null) 
            { 
                return BadRequest(); 
            }

            var category = await _categoriesRepository.GetByIdAsync((int)id);

            if (category == null) 
            { 
                return NotFound(); 
            }
            
            var ViewModel = new CategorisFormViewModel
            {
                Name = category.Name,
                Id = category.Id,
                TypeId = category.TypeId,
                CanScale = category.CanScale,
                Types = await _categoryTypesRepository.GetAllAsync()
            };

            return View("Create", ViewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CategorisFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await _categoryTypesRepository.GetAllAsync();
                return View("Create", model);
            }

            var category = await _categoriesRepository.GetByIdAsync(model.Id);

            if (category == null) 
                return NotFound();

            category.Id = model.Id;
            category.CanScale = model.CanScale;
            category.Name = model.Name;
            category.TypeId = model.TypeId;

            _categoriesRepository.Update(category);
            
            _toastNotification.AddSuccessToastMessage("Category Edited Successfauly");
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
                return BadRequest();

            var category = await _categoriesRepository.GetByIdAsync((int) id);

            if (category == null)
                return NotFound();


            _categoriesRepository.Delete(category);

            return Ok();
        }




    }
}




