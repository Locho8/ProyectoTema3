using System;
using System.Web.Mvc;
using ProyectoTema3.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoTema3.Controllers
{
    public class LoginController : Controller
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ProyectoTema3Conexion"].ConnectionString;

        // GET: Login
        public ActionResult Index()
        {
            // Si ya está logueado, redirigir al home
            if (Session["UsuarioLogueado"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        string query = "SELECT IdUsuario, NombreUsuario, NombreCompleto FROM Usuarios WHERE NombreUsuario = @usuario AND Contraseña = @contraseña AND Activo = 1";
                        
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@usuario", model.NombreUsuario);
                        cmd.Parameters.AddWithValue("@contraseña", model.Contraseña);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Session["UsuarioLogueado"] = reader["NombreUsuario"].ToString();
                            Session["NombreCompleto"] = reader["NombreCompleto"].ToString();
                            Session["IdUsuario"] = reader["IdUsuario"].ToString();

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Usuario o contraseña inválidos");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error en la base de datos: " + ex.Message);
                }
            }
            return View(model);
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
