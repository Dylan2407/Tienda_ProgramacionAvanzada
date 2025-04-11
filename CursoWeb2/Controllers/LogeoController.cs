using CursoWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CursoWeb2.Controllers
{
    public class LogeoController : Controller
    {
        public ActionResult Logeo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Logeo(Login login)
        {
            DBCARRITOEntities entidad = new DBCARRITOEntities();
            USUARIO user = entidad.USUARIO.FirstOrDefault(u => u.Correo == login.Correo);

            if (this.verificar(login.Correo, login.Contraseña))
            {
                //if (user.u_rol_id == 1)
                //{
                //    Session["u_estado"] = "A";
                //    Session["u_rol_id"] = "1";

                //}
                //if (user.u_rol_id == 2)
                //{
                //    Session["u_estado"] = "A";
                //    Session["u_rol_id"] = "2";

                //}
                //if (user.u_rol_id == 3)
                //{
                //    Session["u_estado"] = "A";
                //    Session["u_rol_id"] = "3";

                //}
                //if (user.u_rol_id == 4)
                //{
                //    Session["u_estado"] = "A";
                //    Session["u_rol_id"] = "4";

                //}
                //if (user.u_rol_id == 5)
                //{
                //    Session["u_estado"] = "A";
                //    Session["u_rol_id"] = "5";


                FormsAuthentication.SetAuthCookie(user.Nombre, login.Recordar);

                //recuperar el ID
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, user.Nombre, DateTime.Now, DateTime.Now.AddMinutes(15), true, user.IdUsuario.ToString());
                HttpCookie myTiket = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                HttpContext.Response.Cookies.Add(myTiket);
                HttpCookie authCookie = HttpContext.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
                System.Web.Security.FormsAuthenticationTicket authTicket = System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);
                string ID = authTicket.UserData;

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Logeo","Logeo");
          

        }
        private bool verificar(string email, string pass)
        {
            bool autorizar = false;
            DBCARRITOEntities entidad = new DBCARRITOEntities();
            USUARIO user = entidad.USUARIO.FirstOrDefault(m => m.Correo == email);
            if (user != null)
            {
                if (user.Contraseña.Equals(pass))
                {
                    autorizar = true;
                }
            }
            return autorizar;
        }
        public ActionResult salida()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logeo", "Logeo");
        }
    }
}



