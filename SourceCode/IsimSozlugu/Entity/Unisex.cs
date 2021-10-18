using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsimSozlugu
{
    [Table]
    public class Unisex
    {
        [Column(IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false)]
        public int UnisexId { get; set; }

        [Column]
        public string UnisexName { get; set; }

        [Column]
        public string UnisexMeaning { get; set; }

    }
}
