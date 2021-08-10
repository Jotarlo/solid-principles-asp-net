using ControllerContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerContracts
{
    public interface ICategoryController
    {
        IEnumerable<CategoryDTO> getCategoryList();
       /* CategoryDTO getCategoryById(int id);
        bool saveCategory(CategoryDTO record);
        bool editCategory(CategoryDTO record);
        bool deleteCategory(int id);*/
    }
}
