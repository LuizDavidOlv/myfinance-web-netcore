using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Business.Models 
{
    [Table("plano_contas")]
    public class AccountPlanModel : Entity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("id")]
        //public int Id { get; set; }

        [Column("descricao")]
        public string? Description { get; set; }
        

        [Column("tipo")]
        public string? Type { get; set; }
    }
}
