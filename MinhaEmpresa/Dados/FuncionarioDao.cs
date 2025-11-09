using MinhaEmpresa.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaEmpresa.Dados
{
    public class FuncionarioDao
    {

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (var conexao = Conexao.GetConnectionString())
            {
                try
                {
                    conexao.Open();
                    var comando = conexao.CreateCommand();
                    comando.CommandText = "INSERT INTO Funcionario (Nome, Cargo, Salario, DataContratacao, Departamento) VALUES (@Nome, @Cargo, @Salario, @DataContratacao, @Departamento)";
                    comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                    comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    comando.Parameters.AddWithValue("@DataContratacao", funcionario.DataContratacao);
                    comando.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
               
            }
        }

        public List<Funcionario> ListarFuncionarios()
        {
            var funcionarios = new List<Funcionario>();
            using (var conn = Conexao.GetConnectionString())
            {
                try
                {
                    conn.Open();
                    var comando = conn.CreateCommand();
                    comando.CommandText = "SELECT Id, Nome, Cargo, Salario, DataContratacao, Departamento FROM Funcionario";
                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var funcionario = new Funcionario
                            {
                                ID = dataReader.GetInt32(0),
                                Nome = dataReader.GetString(1),
                                Cargo = dataReader.GetString(2),
                                Salario = dataReader.GetDecimal(3),
                                DataContratacao = dataReader.GetDateTime(4),
                                Departamento = dataReader.GetString(5)
                            };
                            funcionarios.Add(funcionario);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return funcionarios;
        }

        public void RemoverFuncionario(int funcionarioId)
        {
            using (var conn = Conexao.GetConnectionString())
            {
                try
                {
                    conn.Open();
                    var comando = conn.CreateCommand();
                    comando.CommandText = "DELETE FROM Funcionario WHERE ID = @Id";
                    comando.Parameters.AddWithValue("@Id", funcionarioId);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Funcionário removido!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível remover o Funcionário!");
                    throw new Exception(ex.Message);
                }

            }
            
        }



        public void EditaFuncionario(Funcionario funcionario)
        {
            using (var conn = Conexao.GetConnectionString())
            {
                try
                {
                    conn.Open();
                    var comando = conn.CreateCommand();
                    comando.CommandText = "UPDATE Funcionario SET Nome = @Nome, Cargo = @Cargo, Salario = @Salario, DataContratacao = @DataContratacao, Departamento = @Departamento WHERE ID = @Id";
                    comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                    comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    comando.Parameters.AddWithValue("@DataContratacao", funcionario.DataContratacao);
                    comando.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                    comando.Parameters.AddWithValue("@Id", funcionario.ID);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Funcionário atualizado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar o usuário!");
                    throw new Exception(ex.Message);
                }

            }

        }
    }
}
