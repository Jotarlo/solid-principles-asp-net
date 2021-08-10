using Model.Contracts;
using Model.Contracts.DbModel;
using ModelImpl.ModelDB;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelImpl.Implementation
{
    public class CategoryRepositoryImpl: ICategoryRepository
    {
        public IEnumerable<CategoryDbModel> getCategoryList()
        {
            IList<CategoryDbModel> list = new List<CategoryDbModel>();
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                CategoryModelMapper mapper = new CategoryModelMapper();
                list = mapper.MapperT1T2(db.CATEGORY.ToList()).ToList();
            }
            return list;
        }
        /*
        public CATEGORY getCategoryById(int id)
        {
            CATEGORY record = null;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                record = db.CATEGORY.Where(x => x.ID == id).FirstOrDefault();
            }
            return record;
        }

        public bool saveCategory(CATEGORY record)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    db.CATEGORY.Add(record);
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



        public bool editCategory(CATEGORY record)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    CATEGORY current = this.getCategoryById(record.ID);
                    if(current == null)
                    {
                        return false;
                    }
                    current.NAME = record.NAME;
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



        public bool deleteCategory(int id)
        {
            bool response = false;
            using (ProductsDBEntities db = new ProductsDBEntities())
            {
                try
                {
                    CATEGORY current = this.getCategoryById(id);
                    if (current == null)
                    {
                        return false;
                    }
                    db.CATEGORY.Remove(current);
                    db.SaveChanges();
                    response = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return response;
        }*/

    }
}
