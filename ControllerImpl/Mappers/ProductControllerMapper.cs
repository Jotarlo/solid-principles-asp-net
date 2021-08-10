
using ControllerContracts.DTO;
using Model.Contracts.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerImpl.Mappers
{
    public class ProductControllerMapper : MapperBase<ProductDTO, ProductDbModel>
    {
        public override ProductDbModel MapperT1T2(ProductDTO input)
        {
            return new ProductDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                CategoryId = input.CategoryId,
                Photo = input.Photo,
                Price = input.Price,
                Stock = input.Stock
            };
        }

        public override IEnumerable<ProductDbModel> MapperT1T2(IEnumerable<ProductDTO> input)
        {
            IList<ProductDbModel> list = new List<ProductDbModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override ProductDTO MapperT2T1(ProductDbModel input)
        {
            return new ProductDTO()
            {
                Id = input.Id,
                Name = input.Name,
                CategoryId = input.CategoryId,
                Photo = input.Photo,
                Price = input.Price,
                Stock = input.Stock,
                CategoryName = input.CategoryName
            };
        }

        public override IEnumerable<ProductDTO> MapperT2T1(IEnumerable<ProductDbModel> input)
        {
            IList<ProductDTO> list = new List<ProductDTO>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
