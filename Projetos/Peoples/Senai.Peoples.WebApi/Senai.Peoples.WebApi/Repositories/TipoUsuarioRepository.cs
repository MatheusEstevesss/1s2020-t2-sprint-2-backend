using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        string connectionString = "Data Source=DSK-PCH-HD_0001\\MSSQLSERVER01; initial catalog=M_Peoples; Integrated Security= true;";
        //string connectionString = "Data Source=DEV12\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tiposUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querySelectAll = "SELECT IdTipoUsuario,Titulo FROM TipoUsuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),

                            Titulo = rdr[1].ToString()
                        };
                        tiposUsuario.Add(tipoUsuario);
                    }                    
                }
            }
            return tiposUsuario;
        }

        public TipoUsuarioDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querySelectId = "SELECT IdTipoUsuario, Titulo FROM TipoUsuarios WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),

                            Titulo = rdr[1].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryPut = "UPDATE TipoUsuarios SET Titulo = @Titulo WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryPut, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", tipoUsuario.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryDelete = "DELETE FROM TipoUsuarios WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
