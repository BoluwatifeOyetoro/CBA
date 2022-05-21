using CBA.Core.Enums;
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
        private readonly GLCategory glCategory;
        private readonly GLCategory categoryChanges;

        public SQLCategoryDAO(GLCategory glCategory, AppDbContext context, GLCategory categoryChanges)
        {
            this.context = context;
            this.glCategory = glCategory;
            //this.glCategoryChanges = glCategoryChanges;
            this.categoryChanges = categoryChanges;
        }
        public GLCategory Delete(long id)
        {
            context.GLCategories.Remove(glCategory);
            context.SaveChanges();
            return glCategory;
        }

        public IEnumerable<GLCategory> GetAllGLCategories()
        {
            return context.GLCategories;
        }

        public GLCategory GetRoles(GLCategory user)
        {
            throw new NotImplementedException();
        }

        public GLCategory RetrieveById(int id)
        {
            return context.GLCategories.Find(id);
        }

        public GLCategory Save(GLCategory item)
        {
            context.GLCategories.Add(glCategory);
            context.SaveChanges();
            return glCategory;
        }

        public GLCategory UpdateGLCategory(GLCategory userChanges)
        {
            var category = context.GLCategories.Attach(categoryChanges);
            //category.Status = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
