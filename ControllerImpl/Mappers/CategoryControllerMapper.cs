using ControllerContracts.DTO;
using ControllerImpl.Mappers;
using Model.Contracts.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class CategoryControllerMapper : MapperBase<CategoryDTO, CategoryDbModel>
    {
        public override CategoryDbModel MapperT1T2(CategoryDTO input)
        {
            return new CategoryDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CategoryDbModel> MapperT1T2(IEnumerable<CategoryDTO> input)
        {
            IList<CategoryDbModel> list = new List<CategoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override CategoryDTO MapperT2T1(CategoryDbModel input)
        {
            return new CategoryDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<CategoryDTO> MapperT2T1(IEnumerable<CategoryDbModel> input)
        {
            IList<CategoryDTO> list = new List<CategoryDTO>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
