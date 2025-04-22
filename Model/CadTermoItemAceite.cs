using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Model
{
    [Table("tb_cad_termo_item_aceite")]

    public class CadTermoItemAceite
    {

            [Key]
             public int codigo { get; set; }

            public int termo_aceite_codigo { get; set; }

            public int termo_item_codigo { get; set; }

            public bool aceite { get; set; }


            [ForeignKey("termo_aceite_codigo")]
            public CadTermoItemAceiteUsuarioHistorico TermoHistorico { get; set; }
    }
}
