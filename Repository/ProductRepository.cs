using ApiProjectTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjectTest.Repository
{
    public class ProductRepository:IProduct
    {

        EcommerceDB ecommerceDB;
        public ProductRepository(EcommerceDB ecommerceDB)
        {
            this.ecommerceDB = ecommerceDB;
        }

        public List<Product> GetAll()
        {
            return ecommerceDB.Product.ToList();
        }

        public int insert(Product product)
        {

            ecommerceDB.Product.Add(product);
            return ecommerceDB.SaveChanges();
        }

        public Product GetById(int id)
        {
            return ecommerceDB.Product.FirstOrDefault(x => x.id == id);
        }

        public int update(int id, Product product)
        {
            Product oldproduct = GetById(id);
            if (oldproduct != null)
            {
                //oldproduct.id = product.id;
                oldproduct.name = product.name;
                oldproduct.price = product.price;
                oldproduct.quantity = product.quantity;
                oldproduct.img = product.img;
                oldproduct.CategoryID = product.CategoryID;

                return ecommerceDB.SaveChanges();
            }
            return 0;
        }

        public int delete(int prodectID)
        {

            Product oldproduct = GetById(prodectID);
            ecommerceDB.Product.Remove(oldproduct);
            return ecommerceDB.SaveChanges();
        }

        public List<Product> GetByCatogeryID(int CategoryID)
        {
            return ecommerceDB.Product.Where(p => p.category.id == CategoryID).ToList();

        }

        
    }
}
