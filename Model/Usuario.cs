using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Model
{
    [Table("tb_cad_usuario")]
    public class Usuario
    {

        [Key]
        [Column("codigo")]
        public int codigo {  get; set; }

        public string nome { get; set; }

        public string email {  get; set; }

        public DateTime dataCriacao { get; set; }


        public ICollection<Usuario> usuarios { get; set; }


    }
}
