using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CBA.Web.Controllers
{
    public class GLCategoryController : Controller
    {
        private readonly IGLCategoryDAO _glCategory;

        public GLCategoryController(IGLCategoryDAO glCategory)
        {
            _glCategory = glCategory;
        }


        public IActionResult Index()
        {
            var gLCategories = _glCategory.GetAllGLCategories();
            return View(gLCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GLCategory model)
        {
            if (ModelState.IsValid)
            {
                GLCategory newGLCategory = new()
                {
                    Id = model.Id,
                    CategoryName = model.CategoryName,
                    Status = model.Status,
                    CategoryDescription = model.CategoryDescription,
                    Categories = model.Categories,
                    //CategoryCode = _operations.CreateGlCategoryCode(gLCategory),
                    //GLCategoryAccount = model.GLCategoryAccount,
                };
                _glCategory.Save(newGLCategory);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "GLCategory", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var gLCategory = _glCategory.RetrieveById(id);
            GLCategory editUserViewModel = new GLCategory()
            {
                //GLCategoryId = gLCategory.GLCategoryId,
                CategoryName = gLCategory.CategoryName,
                Status = gLCategory.Status,
                CategoryCode = gLCategory.CategoryCode,
                CategoryDescription = gLCategory.CategoryDescription,
                Categories = gLCategory.Categories,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gLCategory = _glCategory.RetrieveById(id);
            GLCategory editUserViewModel = new GLCategory()
            {
                //GLCategoryId = gLCategory.GLCategoryId,
                CategoryName = gLCategory.CategoryName,
                Status = gLCategory.Status,
                CategoryDescription = gLCategory.CategoryDescription,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(GLCategory model)
        {
            if (ModelState.IsValid)
            {
                GLCategory gLCategory = _glCategory.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //gLCategory.GLCategoryId = model.GLCategoryId;
                gLCategory.CategoryName = model.CategoryName;
                gLCategory.Status = model.Status;
                gLCategory.CategoryDescription = model.CategoryDescription;

                GLCategory updatedGLCategory = _glCategory.UpdateGLCategory(gLCategory);

                return RedirectToAction("index", "GLCategory", new { area = "" });
            }

            return View(model);
        }
    }

}
