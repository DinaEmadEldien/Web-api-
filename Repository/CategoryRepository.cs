using ApiProjectTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjectTest.Repository
{
    public class CategoryRepository:ICategory
    {
        EcommerceDB ecommerceDB;
        public CategoryRepository(EcommerceDB ecommerceDB)
        {
            this.ecommerceDB = ecommerceDB;
        }

        public List<Category> GetAll()
        {
            return ecommerceDB.Category.ToList();
        }

        public int insert(Category category)
        {

            ecommerceDB.Category.Add(category);
            return ecommerceDB.SaveChanges();
        }

        public Category GetById(int id)
        {
            return ecommerceDB.Category.FirstOrDefault(x => x.id == id);
        }

        public int update(int id, Category category)
        {
            Category oldcategory = GetById(id);
            if (oldcategory != null)
            {
                //oldcategory.id = category.id;
                oldcategory.name = category.name;
               
                return ecommerceDB.SaveChanges();
            }
            return 0;
        }

        public int delete(int catID)
        {

            Category oldcategory = GetById(catID);
            ecommerceDB.Category.Remove(oldcategory);
            return ecommerceDB.SaveChanges();
        }
    }
}
