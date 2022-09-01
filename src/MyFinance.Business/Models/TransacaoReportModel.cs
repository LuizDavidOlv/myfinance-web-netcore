using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Business.Models
{
    public class TransacaoReportModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<TransactionModel> Transacoes { get; set; }

        public TransacaoReportModel()
        {
            Transacoes = new List<TransactionModel>();
        }
    }
}
