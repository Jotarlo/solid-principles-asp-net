
using Model.Contracts.DbModel;
using ModelImpl.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerImpl.Mappers
{
    public class ProductModelMapper : MapperBase<PRODUCT, ProductDbModel>
    {
        public override ProductDbModel MapperT1T2(PRODUCT input)
        {
            return new ProductDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                CategoryId = input.CATEGORY_ID,
                Photo = input.PHOTO,
                Price = input.PRICE,
                Stock = input.STOCK,
                CategoryName = input.CATEGORY.NAME
            };
        }

        public override IEnumerable<ProductDbModel> MapperT1T2(IEnumerable<PRODUCT> input)
        {
            IList<ProductDbModel> list = new List<ProductDbModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override PRODUCT MapperT2T1(ProductDbModel input)
        {
            return new PRODUCT()
            {
                ID = input.Id,
                NAME = input.Name,
                CATEGORY_ID = input.CategoryId,
                PHOTO = input.Photo,
                PRICE = input.Price,
                STOCK = input.Stock,
            };
        }

        public override IEnumerable<PRODUCT> MapperT2T1(IEnumerable<ProductDbModel> input)
        {
            IList<PRODUCT> list = new List<PRODUCT>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
