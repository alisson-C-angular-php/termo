using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Model
{
    [Table("tb_cad_termo_item")]
    public class CadTermoItem
    {
        [Key]
        public int codigo { get; set; }

        public int termo_codigo { get; set; }


        [ForeignKey(nameof(termo_codigo))]

        public Termo Termo { get; set; }

        public string descricao { get; set; }
        public bool obrigatorio { get; set; }

        public ICollection<CadTermoItemAceite> Aceites { get; set; }

    }
}
