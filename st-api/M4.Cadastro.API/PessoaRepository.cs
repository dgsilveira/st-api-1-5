using M4.Cadastro.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace M4.Cadastro.API
{
    public class PessoaRepository : IPessoaRepository
    {
        private string connectionString = "Data Source=DELL_DOUG;Initial Catalog=EstudyDB;User ID=sa;Password=sa1234;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public IEnumerable<Pessoa> ListarPessoas()
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "SELECT * FROM PESSOAS";

            SqlCommand command = new SqlCommand(sql, conexao);

            using SqlDataReader reader = command.ExecuteReader();

            var pessoas = new List<Pessoa>();

            while (reader.Read())
            {
                bool ativo = Convert.ToBoolean(reader["IDC_ATIVO"]);
                DateTime dataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"]);
                DateTime dataModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"]);
                string genero = Convert.ToString(value: reader["GENERO"]).Trim();
                int id = Convert.ToInt32(reader["ID"]);
                string nome = Convert.ToString(reader["NOME"]).Trim();

                pessoas.Add(new Pessoa
                {
                    Ativo = ativo,
                    DataNascimento = dataNascimento,
                    DataModificacao = dataModificacao,
                    Genero = genero,
                    Id = id,
                    Nome = nome
                });
            }

            return pessoas;
        }

        public Pessoa BuscarPorId(int id)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "SELECT * FROM PESSOAS WHERE ID = @id";

            SqlCommand command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            bool ativo = Convert.ToBoolean(reader["IDC_ATIVO"]);
            DateTime dataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"]);
            DateTime dataModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"]);
            string genero = Convert.ToString(reader["GENERO"]).Trim();
            string nome = Convert.ToString(reader["NOME"]).Trim();


            var pessoa = new Pessoa
            {
                Ativo = ativo,
                DataNascimento = dataNascimento,
                DataModificacao = dataModificacao,
                Genero = genero,
                Id = id,
                Nome = nome
            };

            return pessoa;
        }

        public void Inserir(PessoaInsert pessoa)
        {
            using var conexao = new SqlConnection(connectionString);

            conexao.Open();

            string sql = "INSERT INTO PESSOAS (" +
                            "NOME, " +
                            "GENERO, " +
                            "DATA_NASCIMENTO, " +
                            "IDC_ATIVO, " +
                            "DATA_MODIFICACAO" +

                            ") VALUES (" +
                            "@nome, " +
                            "@genero, " +
                            "@dataNascimento, " +
                            "@ativo, " +
                            "@dataModificacao" +
                            ")";

            SqlCommand command = new SqlCommand(sql, conexao);


            command.Parameters.AddWithValue("@nome", pessoa.Nome);
            command.Parameters.AddWithValue("@genero", pessoa.Genero);
            command.Parameters.AddWithValue("@dataNascimento", pessoa.DataNascimento);
            command.Parameters.AddWithValue("@dataModificacao", DateTime.Now);
            command.Parameters.AddWithValue("@ativo", true);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "DELETE FROM PESSOAS WHERE ID = @id";

            SqlCommand command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public void Atualizar(int id, PessoaUpdate pessoa)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "UPDATE PESSOAS SET ";
            SqlCommand command = new SqlCommand(sql, conexao);

            List<string> parametros = new List<string>();

            if (pessoa.Nome != default)
            {
                parametros.Add("NOME = @nome");
                command.Parameters.AddWithValue("@nome", pessoa.Nome);
            }

            if (pessoa.Genero != default)
            {
                parametros.Add("GENERO = @genero");
                command.Parameters.AddWithValue("@genero", pessoa.Genero);
            }

            if (pessoa.DataNascimento != null)
            {
                parametros.Add("DATA_NASCIMENTO = @dataNascimento");
                command.Parameters.AddWithValue("@dataNascimento", pessoa.DataNascimento);
            }

            if (pessoa.Ativo != null)
            {
                parametros.Add("IDC_ATIVO = @ativo");
                command.Parameters.AddWithValue("@ativo", pessoa.Ativo);
            }

            parametros.Add("DATA_MODIFICACAO = @dataModificacao");
            command.Parameters.AddWithValue("@dataModificacao", DateTime.Now);

            sql = $"{sql}{string.Join(", ", parametros)} WHERE ID = @id";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }
    }
}
