using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Lend
    {
        public int Id { get; set; }

        public virtual User Lender { get; set; }

        public virtual User Borrower { get; set; }

        public virtual Tool Tool { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public LendStatus Status { get; set; }

        public int? Rating { get; set; }
    }
}