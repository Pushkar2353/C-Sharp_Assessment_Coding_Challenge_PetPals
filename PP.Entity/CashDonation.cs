using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Entity
{
    public class CashDonation : Donation
    {
        public DateTime DonationDate { get; private set; }

        public CashDonation(string donorName, decimal amount)
            : base(donorName, amount)
        {
            DonationDate = DateTime.Now;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Cash Donation by {DonorName} of ₹{Amount:N2} on {DonationDate.ToShortDateString()}.");
        }
    }
}


