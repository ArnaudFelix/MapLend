using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Address : ICloneable
    {
        public int Id { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}