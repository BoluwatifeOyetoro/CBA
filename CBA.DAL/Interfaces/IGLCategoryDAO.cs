using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface IGLCategoryDAO
    {
        IEnumerable<GLCategory> GetAllGLCategories();
        GLCategory GetGLCategory(int id);
        GLCategory Add(GLCategory glCategory);
        GLCategory Update(GLCategory glCategory);

    }
}
