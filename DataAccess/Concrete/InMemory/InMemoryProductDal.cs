﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Oracle,Sql
            _products = new List<Product>
            {
                new Product{ProductID=1, ProductName="Bardak",CategoryID = 1,UnitPrice = 15,UnitsInStock = 15},
                new Product{ProductID=2, ProductName="Kamera",CategoryID = 1,UnitPrice = 500,UnitsInStock = 3},
                new Product{ProductID=3, ProductName="Telefon",CategoryID = 2,UnitPrice = 1500,UnitsInStock = 2},
                new Product{ProductID=4, ProductName="Klavye",CategoryID = 2,UnitPrice = 150,UnitsInStock = 65},
                new Product{ProductID=5, ProductName="Mouse",CategoryID = 2,UnitPrice = 85,UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ - Language Integrated Query
          

            Product ProductToDelete = _products.SingleOrDefault(p=>p.ProductID == product.ProductID);
            _products.Remove(ProductToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
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
          return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // gönderdiğim ürün idsine sahip olan listedeki elemanı bul
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.CategoryID = product.CategoryID;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;

            
        }
    }
}
