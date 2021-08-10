using ControllerImpl.Mappers;
using Model.Contracts;
using Model.Contracts.DbModel;
using ModelImpl.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelImpl.Implementation
{
    public class ProductRepositoryImpl: IProductRepository
    {
        public IEnumerable<ProductDbModel> getProductList()
        {
            ProductModelMapper mapper = new ProductModelMapper();
            IList<ProductDbModel> list = new List<ProductDbModel>();
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                list = mapper.MapperT1T2(db.PRODUCT.ToList()).ToList();
            }
            return list;
        }

        public ProductDbModel getProductById(int id)
        {
            PRODUCT record = null;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                record = db.PRODUCT.Where(x => x.ID == id).FirstOrDefault();
            }
            ProductModelMapper mapper = new ProductModelMapper();
            return mapper.MapperT1T2(record);
        }

        public bool saveProduct(ProductDbModel record)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    ProductModelMapper mapper = new ProductModelMapper();
                    PRODUCT p = mapper.MapperT2T1(record);
                    db.PRODUCT.Add(p);
                    db.SaveChanges();
                    response = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return response;
        }



        public bool editProduct(ProductDbModel record)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    PRODUCT current = db.PRODUCT.Where(x => x.ID == record.Id).FirstOrDefault();
                    if (current == null)
                    {
                        return false;
                    }
                    current.NAME = record.Name;
                    current.PHOTO = record.Photo;
                    current.PRICE = record.Price;
                    current.STOCK = record.Stock;
                    db.SaveChanges();
                    response = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return response;
        }


        /// <summary>
        /// Eliminación de un registro
        /// </summary>
        /// <param name="id">Id del registro</param>
        /// <returns>True cuando se elimina y false cuando existe un fallo</returns>
        public bool deleteProduct(int id)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    PRODUCT current = db.PRODUCT.Where(x => x.ID == id).FirstOrDefault();
                    if (current == null)
                    {
                        return false;
                    }
                    db.PRODUCT.Remove(current);
                    db.SaveChanges();
                    response = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return response;
        }

    }
}
