using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoGrupal.Models
{
    public class ClsBank
    {
        public string fullNameCustomer { get; set; }
        public double amount { get; set; } = 0;
        public int typeOperation { get; set; }
        public double totalBalance { get; set; } = 0;
        public double totalDeposit { get; set; } = 0;
        public double totalWithdrawwal { get; set; } = 0;
        public List<double> depositHistory { get; set; } = new List<double>();
        public List<double> withdrawalHistory { get; set; } = new List<double>();
    }
}