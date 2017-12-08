using cinemas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace cinemas.Models.DALs
{
    public class DALPelicula
    {
        public static List<Pelicula> ListarEstrenos()
        {
            var peliculas = new List<Pelicula>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM pelicula where Estado='Estreno'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var pelicula = new Pelicula
                            {
                                PeliculaId = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Sinopsis = dr["Sinopsis"].ToString(),
                                Poster = dr["Poster"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Trailer = dr["Trailer"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            peliculas.Add(pelicula);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return peliculas;
        }


        public static List<Pelicula> ListarProximamente()
        {
            var peliculas = new List<Pelicula>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM pelicula where Estado='Proximamente'", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var pelicula = new Pelicula
                            {
                                PeliculaId = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Sinopsis = dr["Sinopsis"].ToString(),
                                Poster = dr["Poster"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Trailer = dr["Trailer"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            peliculas.Add(pelicula);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return peliculas;
        }




        public static bool Update(Pelicula pelicula)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    var query = new SqlCommand("UPDATE pelicula SET Nombre=@Nombre, Sinopsis=@Sinopsis, Poster=@Poster, Estado=@Estado, Trailer=@Trailer WHERE Id=@Id", con);
                    query.Parameters.AddWithValue("@Nombres", pelicula.Nombre);
                    query.Parameters.AddWithValue("@Apellidos", pelicula.Sinopsis);
                    query.Parameters.AddWithValue("@Inss", pelicula.Poster);
                    query.Parameters.AddWithValue("@Id", pelicula.PeliculaId);
                    query.Parameters.AddWithValue("@Estado", pelicula.Estado);
                    query.Parameters.AddWithValue("@Trailer", pelicula.Trailer);
                    con.Open();
                    int i = query.ExecuteNonQuery();

                    if (i >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static List<string> horas(string nombre)
        {
            List<string> horarios = new List<string>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();
                    
                    var query = new SqlCommand("SELECT horaInicio, horaFin FROM horario, pe_ho where id_pe=(select id from pelicula where Nombre=@nombre) and horario.id=id_ho", con);
                    query.Parameters.AddWithValue("@nombre", nombre);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            string hora = dr["horaInicio"].ToString() + "-" + dr["horaFin"].ToString();
                            // Agregamos el usuario a la lista genreica
                            horarios.Add(hora);                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return horarios;
        }


        public static List<Actores> actores(int id)
        {
            var actores = new List<Actores>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();

                    //var query = new SqlCommand("SELECT * FROM actores where Id=(select IdAct from pe_ac where IdPel=@id)", con);
                    var query = new SqlCommand("SELECT actores.* FROM actores, pe_ac where IdPel=@id and IdAct=Id", con);
                    query.Parameters.AddWithValue("@Id", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var actor = new Actores
                            {
                                ActoresId = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Nacionalidad = dr["Nacionalidad"].ToString(),
                                Nacimiento = dr["Nacimiento"].ToString(),
                                Perfil = dr["Perfil"].ToString(),
                            };

                            // Agregamos el usuario a la lista genreica
                            actores.Add(actor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return actores;
        }
    }
}