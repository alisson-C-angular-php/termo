using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Model
{
    [Table("tb_cad_termo")]
    public class Termo
    {
        [Key]
        [Column("codigo")]
        public int codigo { get; set; }

        [ForeignKey("Usuario")]
        [Column("usuario_codigo")]
        public int usuario_codigo { get; set; }

        public Usuario usuario { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }
        
        [Column("data_criacao")]
        public DateTime dataCriacao { get; set; }

        public Termo termo { get; set; }

        public string versao { get; set; }

        public ICollection<CadTermoItemAceiteUsuarioHistorico> Historicos { get; set; }
    }
}
