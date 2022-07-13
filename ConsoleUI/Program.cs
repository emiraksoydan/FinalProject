

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


// SOLID
// Open ClOSED Principle = bir durum eklendiğinde ana yapı bozulmaz

ProductMethod();
//IoC
//Data Transformation Object
//CategoryMethod();

static void ProductMethod()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductDetails();

    if(result.Success == true)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.CategoryName
                + " " + item.ProductName);
        }
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
   
}

static void CategoryMethod()
{
    CategoryManager category = new CategoryManager(new EfCategoryDal());

    foreach (var item in category.GetAll())
    {
        Console.WriteLine(item.CategoryName);
    }
}