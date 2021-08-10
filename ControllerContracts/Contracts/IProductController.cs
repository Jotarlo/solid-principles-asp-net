
using ControllerContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerContracts
{
    public interface IProductController
    {
        IEnumerable<ProductDTO> getProductList();
        ProductDTO getProductById(int id);
        bool saveProduct(ProductDTO record);
        bool editProduct(ProductDTO record);
        bool deleteProduct(int id);
    }
}
