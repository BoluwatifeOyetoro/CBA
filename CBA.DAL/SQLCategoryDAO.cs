using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL
{
    public class SQLCategoryDAO : IGLCategoryDAO 
    {
        private readonly AppDbContext context;

        public SQLCategoryDAO(AppDbContext context)
        {
            this.context = context;
        }

        public GLCategory Add(GLCategory glCategory)
        {
            context.GLCategories.Add(glCategory);
            context.SaveChanges();
            return glCategory;
        }

        public IEnumerable<GLCategory> GetAllGLCategories()
        {
            return context.GLCategories;
        }

        public GLCategory GetGLCategory(int id)
        {
            return context.GLCategories.Find(id);
        }

        public GLCategory Update(GLCategory categoryChanges)
        {
            var category = context.GLCategories.Attach(categoryChanges);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
