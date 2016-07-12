using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Lend
    {
        public int Id { get; set; }

        public User Lender { get; set; }

        public User Borrower { get; set; }

        public Tool Tool { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public LendStatus LendStatus { get; set; }
    }
}