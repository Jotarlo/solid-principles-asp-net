using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerContracts.DTO
{
    public class ProductDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private String photo;

        public String Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }


        private String categoryName;

        public String CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

    }
}
