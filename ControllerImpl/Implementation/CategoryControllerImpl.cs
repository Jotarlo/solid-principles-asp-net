using ControllerContracts;
using ControllerContracts.DTO;
using ControllerImpl.Mappers;
using Model.Contracts;
using Model.Contracts.DbModel;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerImpl.Implementation
{
    public class CategoryControllerImpl: ICategoryController
    {
        private ICategoryRepository _repository;
        public CategoryControllerImpl(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<CategoryDTO> getCategoryList()
        {
            IEnumerable<CategoryDbModel> list = this._repository.getCategoryList();
            CategoryControllerMapper mapper = new CategoryControllerMapper();
            return mapper.MapperT2T1(list);
        }
        /*
        public CategoryDTO getCategoryById(int id)
        {
            CATEGORY record = this._repository.getCategoryById(id);
            CategoryControllerMapper mapper = new CategoryControllerMapper();
            return mapper.MapperT2T1(record);
        }

        public bool saveCategory(CategoryDTO record)
        {
            CategoryControllerMapper mapper = new CategoryControllerMapper();
            CATEGORY p = mapper.MapperT1T2(record);
            bool response = this._repository.saveCategory(p);
            return response;
        }

        public bool editCategory(CategoryDTO record)
        {
            CategoryControllerMapper mapper = new CategoryControllerMapper();
            CATEGORY p = mapper.MapperT1T2(record);
            bool response = this._repository.editCategory(p);
            return response;
        }

        public bool deleteCategory(int id)
        {
            bool response = this._repository.deleteCategory(id);
            return response;
        }*/

    }
}
