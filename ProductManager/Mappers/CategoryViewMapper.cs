using ControllerContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class CategoryViewMapper : MapperBase<CategoryModel, CategoryDTO>
    {
        public override CategoryDTO MapperT1T2(CategoryModel input)
        {
            return new CategoryDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CategoryDTO> MapperT1T2(IEnumerable<CategoryModel> input)
        {
            IList<CategoryDTO> list = new List<CategoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override CategoryModel MapperT2T1(CategoryDTO input)
        {
            return new CategoryModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CategoryModel> MapperT2T1(IEnumerable<CategoryDTO> input)
        {
            IList<CategoryModel> list = new List<CategoryModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
