using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class User
    {
        public ICollection<Tool> Tools { get; set; }

        public virtual ICollection<Map> Maps { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Lend> BorrowedTools { get; set; }

        public virtual ICollection<Lend> LendedTools { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public virtual Address Address { get; set; }

        public int Rating { get; set; }

        public virtual UserPhoto Photo { get; set; }

        public void EvaluateRatingValue()
        {
            int ratingSum = 0;
            int nbRating = 0;

            foreach (var lend in BorrowedTools)
            {
                if (lend.Rating != null)
                {
                    ratingSum += lend.Rating.Value;
                    nbRating++;
                }
            }

            if (nbRating == 0)
            {
                Rating = 0;
            }
            else
            {
                Rating = ratingSum / nbRating;
            }
        }
    }
}