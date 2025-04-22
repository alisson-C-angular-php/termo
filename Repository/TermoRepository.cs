using Dapper;
using entity.Model;
using Microsoft.Data.SqlClient;

namespace entity.Repository
{
    public class TermoRepository
    {
        private readonly string configuration;
        public TermoRepository(Configuration connecion)
        {
            configuration = connecion.ConnectionString;
        }

        public IEnumerable<CadTermoItemAceiteUsuarioHistorico> getTermo()
        {
            using (var conn = new SqlConnection(configuration))
            {
                return conn.Query<CadTermoItemAceiteUsuarioHistorico>("SELECT * FROM tb_cad_termo_item_aceite_usuario_historico;");
            }
        }

        public IEnumerable<CadTermoItemAceiteUsuarioHistorico> getTermoStatusByUser(int usuario_codigo)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"
                    SELECT 
                        u.nome AS usuario,
                        t.titulo AS termo,
                        i.descricao AS item,
                        a.aceito,
                        h.data_aceite
                    FROM tb_cad_termo_item_aceite_usuario_historico h
                    JOIN tb_cad_usuario u ON u.codigo = h.usuario_codigo
                    JOIN tb_cad_termo t ON t.codigo = h.termo_codigo
                    JOIN tb_cad_termo_item_aceite a ON a.termo_aceite_codigo = h.codigo
                    JOIN tb_cad_termo_item i ON i.codigo = a.termo_item_codigo
                    WHERE u.codigo = @usuario_codigo
                    ORDER BY h.data_aceite DESC;";

                return conn.Query<CadTermoItemAceiteUsuarioHistorico>(sql, new { usuario_codigo });
            }
        }

        public void insertTermo(Termo termo)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = "INSERT INTO tb_cad_termo(titulo,descricao,data_criacao,versao) VALUES (@titulo,@descricao,@data_criacao,@versao)";
                conn.Execute(sql, termo);
            }
        }

        public void insertTermoItem(CadTermoItem termoItem)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = "INSERT INTO tb_cad_termo_item(termo_codigo,descricao,obrigatorio) VALUES (@termo_codigo,@descricao,@obrigatorio)";
                conn.Execute(sql, termoItem);
            }
        }

        

        public void insertHistorico(CadTermoItemAceiteUsuarioHistorico historico)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"INSERT INTO tb_cad_termo_item_aceite_usuario_historico 
                            (usuario_codigo, termo_codigo, data_aceite, data_alteracao)
                            VALUES (@usuario_codigo, @termo_codigo, @data_aceite, @data_alteracao)";
                conn.Execute(sql, historico);
            }
        }

        public void insertAceite(CadTermoItemAceite aceite)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"INSERT INTO tb_cad_termo_item_aceite 
                            (termo_aceite_codigo, termo_item_codigo, aceito)
                            VALUES (@termo_aceite_codigo, @termo_item_codigo, @aceito)";
                conn.Execute(sql, aceite);
            }
        }

        public void updateTermo(Termo termo)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"UPDATE tb_cad_termo
                            SET titulo = @titulo,
                                descricao = @descricao,
                                data_criacao = @data_criacao,
                                versao = @versao
                            WHERE codigo = @codigo";
                conn.Execute(sql, termo);
            }
        }

        public void updateTermoItem(CadTermoItem item)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"UPDATE tb_cad_termo_item
                            SET descricao = @descricao,
                                obrigatorio = @obrigatorio
                            WHERE codigo = @codigo";
                conn.Execute(sql, item);
            }
        }

        public void updateAceite(CadTermoItemAceite aceite)
        {
            using (var conn = new SqlConnection(configuration))
            {
                var sql = @"UPDATE tb_cad_termo_item_aceite
                            SET aceito = @aceito
                            WHERE codigo = @codigo";
                conn.Execute(sql, aceite);
            }
        }
    }
}
