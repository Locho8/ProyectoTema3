using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;
using ProyectoTema3.Models;

namespace ProyectoTema3.Controllers
{
    [Authorize]
    public class ArticulosController : Controller
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ProyectoTema3Conexion"].ConnectionString;

        // GET: Articulos
        public ActionResult Index()
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");

            List<Articulo> articulos = new List<Articulo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT IdArticulo, Nombre, Descripcion, Precio, Stock, Categoria, FechaCreacion FROM Articulos WHERE Activo = 1 ORDER BY FechaCreacion DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        articulos.Add(new Articulo
                        {
                            IdArticulo = (int)reader["IdArticulo"],
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Precio = (decimal)reader["Precio"],
                            Stock = (int)reader["Stock"],
                            Categoria = reader["Categoria"].ToString(),
                            FechaCreacion = (DateTime)reader["FechaCreacion"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar artículos: " + ex.Message;
            }

            return View(articulos);
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo articulo)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        string query = "INSERT INTO Articulos (Nombre, Descripcion, Precio, Stock, Categoria, FechaCreacion, FechaActualizacion, Activo) VALUES (@nombre, @descripcion, @precio, @stock, @categoria, GETDATE(), GETDATE(), 1)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                        cmd.Parameters.AddWithValue("@stock", articulo.Stock);
                        cmd.Parameters.AddWithValue("@categoria", articulo.Categoria ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear artículo: " + ex.Message);
                }
            }
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");

            Articulo articulo = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT * FROM Articulos WHERE IdArticulo = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        articulo = new Articulo
                        {
                            IdArticulo = (int)reader["IdArticulo"],
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Precio = (decimal)reader["Precio"],
                            Stock = (int)reader["Stock"],
                            Categoria = reader["Categoria"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
            }

            if (articulo == null)
                return HttpNotFound();

            return View(articulo);
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Articulo articulo)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");

            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conexion))
                    {
                        conn.Open();
                        string query = "UPDATE Articulos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Stock = @stock, Categoria = @categoria, FechaActualizacion = GETDATE() WHERE IdArticulo = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                        cmd.Parameters.AddWithValue("@stock", articulo.Stock);
                        cmd.Parameters.AddWithValue("@categoria", articulo.Categoria ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar: " + ex.Message);
                }
            }
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UsuarioLogueado"] == null)
                return RedirectToAction("Index", "Login");

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "UPDATE Articulos SET Activo = 0 WHERE IdArticulo = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar: " + ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
