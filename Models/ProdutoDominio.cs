using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProdutoDominio
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nome { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string descricao { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public DateTime dataRegistro { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int quantidade { get; set; }
        [Column(TypeName = "float(10)")]
        public float valor { get; set; }


        //[ForeignKey("TipoCategoria")]
        //public Categoria idCategoria { get; set; }

        //[ForeignKey("Usuario")]
        //public UsuarioDominio idAnunciante { get; set; }




    }
}
