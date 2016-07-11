using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Map.Business
{
    public class User
    {
        public ICollection<Tool> Tools
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ICollection<Map> Maps
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Id
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ICollection<Lend> BorrowedTools
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string Surname
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string Email
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string Pseudo
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string Password
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Address Address
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Rating
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ICollection<Lend> LendedTools
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}