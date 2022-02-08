using Microsoft.AspNetCore.Mvc;
using MyShop;

namespace RazorPage.Controllers;

public class ProductController : Controller
{
    private readonly ICatalog _catalog;

    public ProductController(ICatalog catalog)
    {
        _catalog = catalog;
    }
    // GET
    public IActionResult ListOfProduct()
    {
        var products = _catalog.GetProducts();
        return View(products);  
    }

    public IActionResult AddingProduct()
    {
        if (HttpContext.Request.Method == "POST")
        {
            var id = int.Parse(HttpContext.Request.Form["id"]);
            var name = HttpContext.Request.Form["name"].ToString();
            var price = int.Parse(HttpContext.Request.Form["price"]);
            _catalog.AddProduct(new Product(id, name, price, new Category("NewCategory")));
            //_product.Add(new Product(id, name, price));
        }
        
        return View();
    }

    public IActionResult ListOfCategories()
    {
        return View(_catalog.GetCategories());
    }
    
    public IActionResult AddingCategory()
    {
        if (HttpContext.Request.Method == "POST")
        {
            var name = HttpContext.Request.Form["name"].ToString();
            _catalog.AddCategory(new Category(name));
            //_product.Add(new Product(id, name, price));
        }
        
        return View();
    }
}