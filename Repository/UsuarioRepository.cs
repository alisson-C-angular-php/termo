using Dapper;
using entity.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace entity.Repository
{
    public class UsuarioRepository
    {

        private readonly string configuration;
        public UsuarioRepository(Configuration connecion)
        {
            configuration = connecion.ConnectionString;
        }

        public void insertUsuario(Usuario usuario)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"INSERT INTO tb_cad_usuario (nome, email, data_criacao, ativo)
                            VALUES (@nome, @email, @data_criacao, @ativo)";
                conn.Execute(sql, usuario);
            }
        }

        public void updateUsuario(Usuario usuario)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"UPDATE tb_cad_usuario 
                    SET nome = @nome, email = @email, data_criacao = @data_criacao, ativo = @ativo 
                    WHERE codigo = @codigo";
                conn.Execute(sql, usuario);
            }
        }


    }
}
