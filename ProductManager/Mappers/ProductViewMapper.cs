
using ControllerContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class ProductViewMapper : MapperBase<ProductModel, ProductDTO>
    {
        public override ProductDTO MapperT1T2(ProductModel input)
        {
            return new ProductDTO()
            {
                Id = input.Id,
                Name = input.Name,
                CategoryId = input.CategoryId,
                Photo = input.Photo,
                Price = input.Price,
                Stock = input.Stock
            };
        }

        public override IEnumerable<ProductDTO> MapperT1T2(IEnumerable<ProductModel> input)
        {
            IList<ProductDTO> list = new List<ProductDTO>();
            foreach (var item in input)
            {
                list.Add(this.MapperT1T2(item));
            }
            return list;
        }

        public override ProductModel MapperT2T1(ProductDTO input)
        {
            return new ProductModel()
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

        public override IEnumerable<ProductModel> MapperT2T1(IEnumerable<ProductDTO> input)
        {
            IList<ProductModel> list = new List<ProductModel>();
            foreach (var item in input)
            {
                list.Add(this.MapperT2T1(item));
            }
            return list;
        }
    }
}
