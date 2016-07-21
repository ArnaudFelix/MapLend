using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MapLend.Business;

namespace MapLend.Mvc.Models
{
    public class LendViewModel
    {
        public LendViewModel()
        {
        }

        public LendViewModel(Lend lend)
        {
            Id = lend.Id;
            LenderId = lend.Lender.Id;
            LenderName = lend.Lender.Firstname + " " + lend.Lender.Surname;
            BorrowerId = lend.Borrower.Id;
            BorrowerName = lend.Borrower.Firstname + " " + lend.Borrower.Surname;
            BeginDate = lend.BeginDate;
            EndDate = lend.EndDate;
            Tool = new ToolViewModel(lend.Tool);
            Status = lend.Status;
            Rating = lend.Rating;
        }

        public int Id { get; set; }

        public int LenderId { get; set; }

        [Display(Name = "Prêteur")]
        public string LenderName { get; set; }

        public int BorrowerId { get; set; }

        [Display(Name = "Emprunteur")]
        public string BorrowerName { get; set; }

        public ToolViewModel Tool { get; set; }

        [Display(Name = "A partir du")]
        [DataType(DataType.Date)]
        public DateTime? BeginDate { get; set; }

        [Display(Name = "Jusqu'au")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Statut")]
        public LendStatus Status { get; set; }

        [Display(Name = "Note")]
        public int? Rating { get; set; }

    }
}