using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoWeb2.Models;

namespace CursoWeb2.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index(string marcaFiltro)
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
               
                var marcas = db.PRODUCTO
                    .Select(p => p.Marca)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                ViewBag.Marcas = new SelectList(marcas, marcaFiltro);

                
                var productos = db.PRODUCTO.AsQueryable();

                if (!string.IsNullOrEmpty(marcaFiltro))
                {
                    productos = productos.Where(p => p.Marca == marcaFiltro);
                }

                return View(productos.ToList());
            }
        }

        public ActionResult Agregar()
        {
           
            var producto = new PRODUCTO
            {
                Activo = true
            };
           
            var categorias = GetCategorias();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Descripcion");

            return View(producto);
        }



        [HttpPost]
        public ActionResult Agregar(PRODUCTO producto, HttpPostedFileBase ImagenFile)
        {
            if (ModelState.IsValid)
            {
                using (DBCARRITOEntities db = new DBCARRITOEntities())
                {
                    if (ImagenFile != null && ImagenFile.ContentLength > 0)
                    {
                       
                        string nombreImagen = Path.GetFileName(ImagenFile.FileName);

                        producto.RutaImagen = nombreImagen;
                        
                        using (var memoryStream = new MemoryStream())
                        {
                            ImagenFile.InputStream.CopyTo(memoryStream);
                            producto.Imagen = memoryStream.ToArray();
                        }
                    }

                   
                    producto.FechaRegistro = DateTime.Now;
                    db.PRODUCTO.Add(producto);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(GetCategorias(), "IdCategoria", "Descripcion", producto.IdCategoria);
            return View(producto);
        }



        public ActionResult Editar(int id)
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
                var producto = db.PRODUCTO.FirstOrDefault(p => p.IdProducto == id);
                if (producto == null)
                {
                    return HttpNotFound(); 
                }

                
                ViewBag.Categorias = new SelectList(GetCategorias(), "IdCategoria", "Descripcion", producto.IdCategoria);
                return View(producto);
            }
        }

        [HttpPost]
        public ActionResult Editar(PRODUCTO producto, HttpPostedFileBase ImagenFile)
        {
            if (ModelState.IsValid)
            {
                using (DBCARRITOEntities db = new DBCARRITOEntities())
                {
                    var productoDb = db.PRODUCTO.FirstOrDefault(p => p.IdProducto == producto.IdProducto);
                    if (productoDb != null)
                    {
                        
                        if (ImagenFile != null && ImagenFile.ContentLength > 0)
                        {
                            
                            string nombreImagen = Path.GetFileName(ImagenFile.FileName);

                          
                            productoDb.RutaImagen = nombreImagen;

                            using (var memoryStream = new MemoryStream())
                            {
                                ImagenFile.InputStream.CopyTo(memoryStream);
                                productoDb.Imagen = memoryStream.ToArray();
                            }
                        }

                        productoDb.Nombre = producto.Nombre;
                        productoDb.Descripcion = producto.Descripcion;
                        productoDb.Marca = producto.Marca;
                        productoDb.IdCategoria = producto.IdCategoria;
                        productoDb.Precio = producto.Precio;
                        productoDb.Stock = producto.Stock;
                        productoDb.NombreImagen = producto.NombreImagen;
                        productoDb.Activo = producto.Activo;

                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(GetCategorias(), "IdCategoria", "Descripcion", producto.IdCategoria);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
                var producto = db.PRODUCTO.FirstOrDefault(p => p.IdProducto == id);
                if (producto != null)
                {
                    db.PRODUCTO.Remove(producto);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
                var producto = db.PRODUCTO.Find(id);
                if (producto != null)
                {
                    db.PRODUCTO.Remove(producto);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        private List<CATEGORIA> GetCategorias()
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
                return db.CATEGORIA.Where(c => c.Activo == true).ToList();
            }
        }

        public ActionResult ObtenerImagen(int id)
        {
            using (DBCARRITOEntities db = new DBCARRITOEntities())
            {
                var producto = db.PRODUCTO.FirstOrDefault(p => p.IdProducto == id);
                if (producto != null && producto.Imagen != null)
                {
                   
                    return File(producto.Imagen, "image/jpeg");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        


    }
}