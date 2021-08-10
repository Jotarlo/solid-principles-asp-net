using Model.Contracts.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDbModel> getCategoryList();
        /*CategoryDbModel getCategoryById(int id);
        bool saveCategory(CategoryDbModel record);
        bool editCategory(CategoryDbModel record);
        bool deleteCategory(int id);*/
    }
}
