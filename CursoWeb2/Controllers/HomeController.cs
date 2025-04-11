using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoWeb2.Models;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Registrar()
        {

            return View();
        }

        public ActionResult login3()
        {

            return View();
        }

        public ActionResult ViewOptions()
        {

            return View();
        }







        [HttpGet] // Protocolo para obtener  información a los servidores 
        public ActionResult Usuarios()
        {
            {
                DBCARRITOEntities oDatos = new DBCARRITOEntities();

                return View(oDatos.USUARIO.ToList());

            }
        }
        [HttpGet]
        public ActionResult CrearUsuario()
        {
            return View();

        }

        public ActionResult EliminarUsuario(int id)

        {
            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())

            {
                var usuario = oDatos.USUARIO.FirstOrDefault(u => u.IdUsuario == id);

                if (usuario == null)
                {
                    return HttpNotFound();
                }

                return View(usuario);

            }
        }
        
        [HttpPost]
        public ActionResult EliminarUsuario(USUARIO usuario)
        {
            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())
            {
                var usuarioEliminar = oDatos.USUARIO.FirstOrDefault(u => u.IdUsuario == usuario.IdUsuario);

                if (usuarioEliminar == null)
                {
                    return HttpNotFound();
                }

                oDatos.USUARIO.Remove(usuarioEliminar); 
                oDatos.SaveChanges(); 
            }

            return RedirectToAction("Usuarios", "Home"); 
        }

        public ActionResult ActualizarUsuario()
        {
            return View();

        }

        public ActionResult EditarUsuario(int id)

        {

            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())
            {
                var usuario = oDatos.USUARIO.FirstOrDefault(u => u.IdUsuario == id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
        }
        [HttpPost]
        public ActionResult ActualizarUsuario(USUARIO perfil)
        {
            using (DBCARRITOEntities oDatos = new DBCARRITOEntities())
            {
                var usuario = oDatos.USUARIO.FirstOrDefault(u => u.IdUsuario == perfil.IdUsuario);
                if (usuario == null)
                {
                    return HttpNotFound();
                }

                usuario.Nombre = perfil.Nombre;
                usuario.Apellido = perfil.Apellido;
                usuario.Correo = perfil.Correo;
                usuario.Contraseña = perfil.Contraseña;
                usuario.Activo = perfil.Activo;

                oDatos.SaveChanges();
            }
            return RedirectToAction("Usuarios", "Home");
        }







        [HttpPost]// Protocolo para enviar información al servidor 

        public ActionResult CrearUsuario(USUARIO perfil)
        {

            DBCARRITOEntities oDatos = new DBCARRITOEntities();

            //Verificacion de Datos usuarios
            var verify = oDatos.USUARIO.FirstOrDefault(m => m.IdUsuario == perfil.IdUsuario);// esto verifica que no sean replicados en la base de datos 

            // m=>m arrow funtion(funcion de flecha) esto significa que por cada uno en este caso usuario en "Usuarios", que verifique todos lo usuarios a ver si hay alguno que se parece al dato que le enviamos por parametro

            if (verify != null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Se toman los datos del fomulario y se asignan a la tabla
            USUARIO nuevoUsuario = new USUARIO();
            nuevoUsuario.Nombre = perfil.Nombre;
            nuevoUsuario.Apellido = perfil.Apellido;
            nuevoUsuario.Correo = perfil.Correo;
            nuevoUsuario.Contraseña = perfil.Contraseña;
            nuevoUsuario.Activo = perfil.Activo;

            //Se guarda en la base de datos
            oDatos.USUARIO.Add(nuevoUsuario);
            oDatos.SaveChanges();

            return RedirectToAction("Usuarios", "Home");
        }


    
    }
}