using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CBA.Web.Controllers
{
    public class GLCategoryController : Controller
    {
        private readonly IGLCategoryDAO _glcategoryDAO;
        private readonly AppDbContext context;
        public GLCategoryController(AppDbContext context, IGLCategoryDAO category)
        {
            this.context = context;
            _glcategoryDAO = category;
        }
        public ViewResult Index()
        {
            // IEnumerable<GLCategory> objList = context.GLCategories;
            var model = _glcategoryDAO.GetAllGLCategories();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(GLCategory category)
        {
           
            GLCategory newGLCategory = _glcategoryDAO.Add(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            GLCategory category = _glcategoryDAO.GetGLCategory(id);
            GLCategory gLCategory = new GLCategory
            {
                Id = category.Id,
                Name = category.Name,
                State = category.State,
                Description = category.Description 
            };
            return View(gLCategory);
        }

        [HttpPost]
        public IActionResult Edit(GLCategory model)
        {
            if(ModelState.IsValid)
            {
                var category = _glcategoryDAO.GetGLCategory(model.Id);
                category.Name = model.Name;
                category.State = model.State;
                category.Description = model.Description;

                GLCategory updatedGLCategory = _glcategoryDAO.Update(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
