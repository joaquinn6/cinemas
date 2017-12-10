using cinemas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace cinemas.Models.DALs
{
    public class DALRegistro
    {
        public static List<Registro> Listar()
        {
            var registros = new List<Registro>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();
                    var i = 1;
                    var query = new SqlCommand("SELECT * FROM recibo, horario, pe_ho, pelicula where pelicula.Id = pe_ho.id_pe and pe_ho.id_ho=horario.Id and recibo.id_pe_ho=pe_ho.Id", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var registro = new Registro
                            {
                                recibos = new Recibo {
                                    
                                    id_pe_ho = Convert.ToInt32(dr["id_pe_ho"]),
                                    fechaPelicula = dr["fechaPelicula"].ToString(),
                                    fechaNow = dr["fechaNow"].ToString(),
                                    cliente = dr["cliente"].ToString(),
                                    asiento = dr["asiento"].ToString(),
                                    codigo = dr["codigo"].ToString(),
                                    ReciboId = Convert.ToInt32(dr["Id"]),
                                    correo = dr["correoCliente"].ToString()
                                },
                                peliculas = new Pelicula
                                {
                                    PeliculaId = Convert.ToInt32(dr["Id"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Sinopsis = dr["Sinopsis"].ToString(),
                                    Poster = dr["Poster"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    Trailer = dr["Trailer"].ToString()
                                },
                                horarios = new Horario
                                {
                                    HorarioId = Convert.ToInt32(dr["Id"]),
                                    horaFin = dr["horaFin"].ToString(),
                                    horaInicio = dr["horaInicio"].ToString(),
                                },
                                RegistroId = i
                            };
                            // Agregamos el usuario a la lista genreica
                            registros.Add(registro);
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return registros;
        }










        public static Registro Detalles(int id)
        {
            var registro = new Registro();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM recibo, horario, pe_ho, pelicula where pelicula.Id = pe_ho.id_pe and pe_ho.id_ho=horario.Id and recibo.id_pe_ho=pe_ho.Id and recibo.id=@Id", con);
                    query.Parameters.AddWithValue("@Id", id.ToString());
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            registro = new Registro
                            {
                                recibos = new Recibo
                                {

                                    id_pe_ho = Convert.ToInt32(dr["id_pe_ho"]),
                                    fechaPelicula = dr["fechaPelicula"].ToString(),
                                    fechaNow = dr["fechaNow"].ToString(),
                                    cliente = dr["cliente"].ToString(),
                                    asiento = dr["asiento"].ToString(),
                                    codigo = dr["codigo"].ToString(),
                                    ReciboId = Convert.ToInt32(dr["Id"]),
                                    correo = dr["correoCliente"].ToString()
                                },
                                peliculas = new Pelicula
                                {
                                    PeliculaId = Convert.ToInt32(dr["Id"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Sinopsis = dr["Sinopsis"].ToString(),
                                    Poster = dr["Poster"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    Trailer = dr["Trailer"].ToString()
                                },
                                horarios = new Horario
                                {
                                    HorarioId = Convert.ToInt32(dr["Id"]),
                                    horaFin = dr["horaFin"].ToString(),
                                    horaInicio = dr["horaInicio"].ToString(),
                                },
                                RegistroId = 0
                            };
                            // Agregamos el usuario a la lista genreica
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return registro;
        }
    }
}