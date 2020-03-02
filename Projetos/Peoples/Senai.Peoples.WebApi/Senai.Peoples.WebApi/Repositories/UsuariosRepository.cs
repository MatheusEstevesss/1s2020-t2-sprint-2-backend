using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        string connectionString = "Data Source=DSK-PCH-HD_0001\\MSSQLSERVER01; initial catalog=M_Peoples; Integrated Security= true;";
        //string connectionString = "Data Source=DEV12\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querySelectAll = "SELECT Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, TipoUsuarios.IdTipoUsuario, TipoUsuarios.Titulo FROM Usuarios INNER JOIN TipoUsuarios ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr[1].ToString(),

                            Senha = rdr[2].ToString(),

                            IdTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[0]),

                                Titulo = rdr[1].ToString()
                            }
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public void Cadastrar(UsuarioDomain usuarios)
        {
            using (SqlConnection con = new SqlConnection (connectionString))
            {
                string queryPost = "INSERT INTO Usuarios (Email,Senha,IdTipoUsuario) VALUES (@Email,@Senha,@IdTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryPost, con))
                {
                    cmd.Parameters.AddWithValue("@Email", usuarios.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuarios.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuarios.IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryGetById = "SELECT Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, TipoUsuarios.IdTipoUsuario, TipoUsuarios.Titulo FROM Usuarios INNER JOIN TipoUsuarios ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuario WHERE IdUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand (queryGetById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr[1].ToString(),

                            Senha = rdr[2].ToString(),

                            IdTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[0]),

                                Titulo = rdr[1].ToString()
                            }
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, UsuarioDomain usuarios)
        {
            throw new NotImplementedException();
        }       
    }
}
