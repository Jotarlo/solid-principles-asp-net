using Model.Contracts.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<ProductDbModel> getProductList();
        ProductDbModel getProductById(int id);
        bool saveProduct(ProductDbModel record);
        bool editProduct(ProductDbModel record);
        bool deleteProduct(int id);
    }
}
