using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Model
{
    [Table("tb_cad_termo_item_aceite_usuario_historico")]
    public class CadTermoItemAceiteUsuarioHistorico
    {
        [Column("codigo")]
        public int codigo { get; set; }

        [ForeignKey("codigo")]

        [Key]
        [Column(Order = 0)]
        public int usuario_codigo { get; set; }

        [ForeignKey("termo_codigo")]
        public Termo Termo { get; set; }
        public DateTime data_aceite { get; set; }

        public DateTime data_alteracao { get; set; }

      
        public ICollection<CadTermoItemAceite> Aceites { get; set; }
    }
}
