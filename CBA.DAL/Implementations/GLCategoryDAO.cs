using System;
using System.Collections.Generic;
using System.Linq;
using CBA.DAL.Interfaces;
using System.Text;
using System.Threading.Tasks;
using CBA.Core.Models;

namespace CBA.DAL.Implementations
{
    public class GLCategoryDAO : IGLCategoryDAO
    {
        private List<GLCategory> _glCategoryList;
        public GLCategoryDAO()
        {
            _glCategoryList = new List<GLCategory>()
            {
                new GLCategory() { Id = 1, Name = "Revenue", State = true, Description = "Income"}
            };
        }
        public GLCategory Add(GLCategory category)
        {
            category.Id = _glCategoryList.Max(e => e.Id) + 1;
            _glCategoryList.Add(category);
            return category;
        }

        public IEnumerable<GLCategory> GetAllGLCategories()
        {
            return _glCategoryList;
        }

        public GLCategory GetGLCategory(int Id)
        {
            return _glCategoryList.FirstOrDefault(x => x.Id == Id);
        }

        public GLCategory Update(GLCategory categoryChanges)
        {
            GLCategory category = _glCategoryList.FirstOrDefault(e => e.Id == categoryChanges.Id);
            if (category == null)
            {
                category.Id = categoryChanges.Id;
                category.Name = categoryChanges.Name;
                category.State = categoryChanges.State;
                category.Description = categoryChanges.Description;
            }
            return category;
        }
    }
}
