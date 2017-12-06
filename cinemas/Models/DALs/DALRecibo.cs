using cinemas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace cinemas.Models.DALs
{
    public class DALRecibo
    {
        public static List<Recibo> Listar()
        {
            var recibos = new List<Recibo>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM recibo", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var recibo = new Recibo
                            {
                                ReciboId = Convert.ToInt32(dr["Id"]),
                                id_pe_ho= Convert.ToInt32(dr["id_pe_ho"]),
                                fechaPelicula = dr["fechaPelicula"].ToString(),
                                fechaNow = dr["fechaNow"].ToString(),
                                cliente = dr["cliente"].ToString(),
                                asiento = dr["asiento"].ToString(),
                                codigo = dr["codigo"].ToString(),
                                correo = dr["correoCliente"].ToString()
                            };

                            // Agregamos el usuario a la lista genreica
                            recibos.Add(recibo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return recibos;
        }

        public static bool Add(Recibo recibo)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    var query = new SqlCommand("INSERT INTO recibo(id, id_sa,id_pe_ho, fechaPelicula, fechaNow, cliente,asiento, codigo, correoCliente) values (NULL,@id_sa,@id_pe_ho,@fechaPelicula,@fechaNow, @cliente, @asiento, @codigo, @correo)", con);
                    query.Parameters.AddWithValue("@id_pe_ho", recibo.id_pe_ho);
                    query.Parameters.AddWithValue("@fechaPelicula", recibo.fechaPelicula);
                    query.Parameters.AddWithValue("@fechaNow", recibo.fechaNow);
                    query.Parameters.AddWithValue("@cliente", recibo.cliente);
                    query.Parameters.AddWithValue("@asiento", recibo.asiento);
                    query.Parameters.AddWithValue("@codigo", recibo.codigo);
                    query.Parameters.AddWithValue("@correo", recibo.correo);
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
        public static Recibo Find(int id)
        {
            Recibo recibo= null;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                {
                    var query = new SqlCommand("SELECT * FROM recibo WHERE Id = @Id", con);
                    query.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            recibo = new Recibo
                            {
                                ReciboId = Convert.ToInt32(dr["Id"]),
                                id_pe_ho = Convert.ToInt32(dr["id_pe_ho"]),
                                fechaPelicula = dr["fechaPelicula"].ToString(),
                                fechaNow = dr["fechaNow"].ToString(),
                                cliente = dr["cliente"].ToString(),
                                asiento = dr["asiento"].ToString(),
                                codigo = dr["codigo"].ToString(),
                                correo = dr["correoCliente"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return recibo;
        }
    }
}