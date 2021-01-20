using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BB.CodeTest.Models.Data
{
    public enum OrgSize
    {
        Large,
        Medium,
        Small
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrgSize Size { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
