using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _icategorydal;

        public CategoryManager(ICategoryDal icategorydal)
        {
            _icategorydal = icategorydal;
        }

        // iş kodları
        public List<Category> GetAll()
        {
            return _icategorydal.GetAll();
        }

        public Category GetById(int id)
        {
            return _icategorydal.Get(p => p.CategoryID == id);
        }
    }
}
