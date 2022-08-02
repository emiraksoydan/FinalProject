using Business.Abstract;
using Core.Utilities.Results;
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
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_icategorydal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_icategorydal.Get(p => p.CategoryID == id));
        }
    }
}
