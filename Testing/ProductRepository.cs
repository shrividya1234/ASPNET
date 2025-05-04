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
   public void InsertProduct(Product productToInsert)
   {
      _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
         new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.categoryID });
   }
   public IEnumerable<Category> GetCategories()
   {
      return _conn.Query<Category>("SELECT * FROM categories;");
   }
   public Product AssignCategory()
   {
      var categoryList = GetCategories();
      var product = new Product();
      product.Categories = categoryList;
      return product;
   }
}