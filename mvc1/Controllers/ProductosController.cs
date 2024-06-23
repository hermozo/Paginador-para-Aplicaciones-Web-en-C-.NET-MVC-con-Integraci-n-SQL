using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc1.Helpers;
using mvc1.Interfaces;
using mvc1.Models;

namespace mvc1.Controllers
{
    
    [Route("[controller]")]
    public class ProductosController : Controller
    {
      /*  private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("index")]
        public ActionResult Index(int page = 1, string nombre = "")
        {
            var viewModel = _productoService.GetProductosViewModel(page, nombre);
            return View("index", viewModel);
        }*/



         private readonly AppDBContext _appDbContext;
         public ProductosController(AppDBContext appDbContext)
         {
             _appDbContext = appDbContext;
         }

         [HttpGet()]
         public ActionResult Index(int page = 1, string nombre = "")
         {
             IQueryable<Productos> query = _appDbContext.Productos;
             if (!string.IsNullOrEmpty(nombre))
             {
                 query = query.Where(p => p.Nombre.Contains(nombre));
             }
             int totalProductos = query.Count();
             Paginacion pagination = new Paginacion(page, totalProductos);
             List<Productos> productos = query
                 .Skip(pagination.StartIndex)
                 .Take(pagination.ItemsPerPage)
                 .ToList();
             ViewBag.pagination = pagination;
             ViewBag.Nombre = nombre;
             return View("index", productos);
         }

         [HttpGet("{id}")]
         public ActionResult View(int id)
         {
             Productos producto = _appDbContext.Productos.Find(id)!;
             if (producto == null)
             {
                 return NotFound();
             }
             ViewBag.Data = 45;
             return View("view", producto);
         }

         #region Create
         [HttpGet("create")]
         public ActionResult Create()
         {
             Productos model = new Productos();
             return View("create", model);
         }

         [HttpPost("create")]
         public ActionResult Create(Productos model)
         {
             if (ModelState.IsValid)
             {
                 _appDbContext.Productos.Add(model);
                 _appDbContext.SaveChanges();
                 return RedirectToAction("index");
             }
             return View("create", model);
         }

         #endregion

         #region Edit
         [HttpGet("update/{id}")]
         public ActionResult Update(int id)
         {
             Productos producto = _appDbContext.Productos.Find(id);
             if (producto == null)
             {
                 return NotFound();
             }
             return View("update", producto);
         }

         [HttpPost("update/{id}")]
         public ActionResult Update(Productos productos)
         {
             if (ModelState.IsValid)
             {
                 _appDbContext.Entry(productos).State = EntityState.Modified;
                 _appDbContext.SaveChanges();
                 return RedirectToAction("index");
             }
             return View("update", productos);
         }
         #endregion

         public ActionResult Delete(int id)
         {
             Productos productos = new Productos { Id = id };
             _appDbContext.Productos.Remove(productos);
             _appDbContext.SaveChanges();
             return RedirectToAction("index");
         }

    }
}
