using DataAccess.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product {ProductId = 1, CategoryId = 1,ProductName = "Glass", UnitPrice = 15, UnitsInStock = 123},
                new Product {ProductId = 2, CategoryId = 1,ProductName = "Camera", UnitPrice = 150, UnitsInStock = 50},
                new Product {ProductId = 3, CategoryId = 2,ProductName = "Phone", UnitPrice = 50, UnitsInStock = 15},
                new Product {ProductId = 4, CategoryId = 2,ProductName = "Pencil", UnitPrice = 2, UnitsInStock = 2},
                new Product {ProductId = 5, CategoryId = 3,ProductName = "Mouse", UnitPrice = 500, UnitsInStock = 23}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(product);
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if(productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            }
        }
    }
}
