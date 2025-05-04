using System.Collections.Generic;
using System.Data;
using Testing.Models;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace Testing;

public class ProductRepository : IProductRepository
{
   private readonly IDbConnection _conn;
   public ProductRepository(IDbConnection conn)
   {
      _conn = conn;
   }

   public IEnumerable<Product> GetAllProducts()
   {
      return _conn.Query<Product>("SELECT * FROM Products");
   }

   public Product GetProduct(int id)
   {
      return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
   }

   public void updateProduct(Product product)
   {
      _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
         new {name = product.Name, price = product.Price, id = product.ProductId });
   }
}