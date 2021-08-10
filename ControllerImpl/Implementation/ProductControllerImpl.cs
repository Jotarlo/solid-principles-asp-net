
using ControllerContracts;
using ControllerContracts.DTO;
using ControllerImpl.Mappers;
using Model.Contracts;
using Model.Contracts.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerImpl.Implementation
{
    public class ProductControllerImpl: IProductController
    {
        private IProductRepository _repository;
        public ProductControllerImpl(IProductRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<ProductDTO> getProductList()
        {
            IEnumerable<ProductDbModel> list = this._repository.getProductList();
            ProductControllerMapper mapper = new ProductControllerMapper();
            return mapper.MapperT2T1(list);
        }

        public ProductDTO getProductById(int id)
        {
            ProductDbModel record = this._repository.getProductById(id);
            ProductControllerMapper mapper = new ProductControllerMapper();
            return mapper.MapperT2T1(record);
        }

        public bool saveProduct(ProductDTO record)
        {
            ProductControllerMapper mapper = new ProductControllerMapper();
            ProductDbModel p = mapper.MapperT1T2(record);
            bool response = this._repository.saveProduct(p);
            return response;
        }

        public bool editProduct(ProductDTO record)
        {
            ProductControllerMapper mapper = new ProductControllerMapper();
            ProductDbModel p = mapper.MapperT1T2(record);
            bool response = this._repository.editProduct(p);
            return response;
        }

        public bool deleteProduct(int id)
        {
            bool response = this._repository.deleteProduct(id);
            return response;
        }

    }
}
