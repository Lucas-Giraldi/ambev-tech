using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string ZipCode { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
