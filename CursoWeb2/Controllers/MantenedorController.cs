using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoWeb2.Models;
namespace CursoWeb2.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            DBCARRITOEntities oDatos = new DBCARRITOEntities();

            return View(oDatos.CATEGORIA.ToList());
        }

        public ActionResult Marca()
        {


            return View();
        }

        [HttpGet]
        public ActionResult Producto()
        {
            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())
            {
                return View(oDatos.PRODUCTO.ToList());
            }
        }
        

        [HttpGet]
        public ActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(PRODUCTO producto)
        {
            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())
            {
                var verify = oDatos.PRODUCTO.FirstOrDefault(p => p.IdProducto == producto.IdProducto);
                if (verify != null)
                {
                    return RedirectToAction("Productos", "Producto");
                }

                PRODUCTO nuevoProducto = new PRODUCTO
                {
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Marca = producto.Marca,
                    IdCategoria = producto.IdCategoria,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    Activo=producto.Activo
                    
                };

                oDatos.PRODUCTO.Add(nuevoProducto);
                oDatos.SaveChanges();
            }
            return RedirectToAction("Productos", "Producto");
        }
    }
}
