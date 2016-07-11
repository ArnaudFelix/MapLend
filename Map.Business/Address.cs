using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Address
    {
        public int Id { get; set; }

        public string ZipCode
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string City
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string AddressLine1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string AddressLine2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// ??? utilité ????
        /// </summary>
        public string Country
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