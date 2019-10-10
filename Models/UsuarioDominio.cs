using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class UsuarioDominio
    {   
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nome { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string email { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string senha { get; set; }
    }
}
