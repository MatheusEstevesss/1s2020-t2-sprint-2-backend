using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        string connectionString = "Data Source=DEV12\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";        

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            
                            Nome = rdr[1].ToString(),

                            Sobrenome=rdr[2].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;
                }
            }
        }

        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryPost = "INSERT INTO Funcionarios (Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";

                using (SqlCommand cmd = new SqlCommand(queryPost, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryGetById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr[1].ToString(),

                            Sobrenome = rdr[2].ToString()
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(int id, FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryPut = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryPut, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
