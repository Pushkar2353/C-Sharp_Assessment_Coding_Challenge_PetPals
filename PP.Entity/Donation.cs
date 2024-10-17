using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public abstract class Donation
    {
        public string DonorName { get; set; }
        public decimal Amount { get; set; }

        protected Donation(string donorName, decimal amount)
        {
            DonorName = donorName;
            Amount = amount;
        }

        public abstract void RecordDonation();
    }
}


