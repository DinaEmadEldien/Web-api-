using ApiProjectTest.Models;
using System.Collections.Generic;

namespace ApiProjectTest.Repository
{
    public interface IProduct: IRepository<Product>
    {
       List<Product> GetByCatogeryID(int CatogeryID);
    }
}
