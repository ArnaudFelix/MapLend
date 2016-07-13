using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class User
    {
        public ICollection<Tool> Tools { get; set; }

        public ICollection<Map> Maps { get; set; }

        public int Id { get; set; }

        public ICollection<Lend> BorrowedTools { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public virtual Address Address { get; set; }

        public int Rating { get; set; }

        public ICollection<Lend> LendedTools { get; set; }

        public virtual UserPhoto Photo { get; set; }
    }
}