using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Business.Models
{
    [Table("transacao")]
    public class TransactionModel : Entity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("id")]
        //public long Id { get; set; }

        [Column("data")]
        public DateTime Date { get; set; }

        [Column("valor")]
        public decimal Value { get; set; }

        [Column("tipo")]
        public string? Type { get; set; }

        [Column("historico")]
        public string? History { get; set; }
        
        [Column("plano_contas_id")]
        public long AccountPlanId { get; set; }


        //[NotMapped]
        //public string? AccountPlanDescription { get; set; }
    }
}
