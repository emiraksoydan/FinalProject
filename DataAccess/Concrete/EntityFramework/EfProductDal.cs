using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext northwindcontext = new NorthwindContext())
            {
                var result = from p in northwindcontext.Products
                             join c in northwindcontext.Categories
                              on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto { ProductId = p.ProductID, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock, CategoryName = c.CategoryName };
                return result.ToList();
            }
        }
    }
}
