
using ControllerImpl.Mappers;
using Model.Contracts.DbModel;
using ModelImpl.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class CategoryModelMapper : MapperBase<CATEGORY, CategoryDbModel>
    {
        public override CategoryDbModel MapperT1T2(CATEGORY input)
        {
            return new CategoryDbModel()
            {
                Id = input.ID,
                Name = input.NAME
            };
        }

        public override IEnumerable<CategoryDbModel> MapperT1T2(IEnumerable<CATEGORY> input)
        {
            IList<CategoryDbModel> list = new List<CategoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override CATEGORY MapperT2T1(CategoryDbModel input)
        {
            return new CATEGORY()
            {
                ID = input.Id,
                NAME = input.Name
            };
        }

        public override IEnumerable<CATEGORY> MapperT2T1(IEnumerable<CategoryDbModel> input)
        {
            IList<CATEGORY> list = new List<CATEGORY>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
