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
    public class Male
    {
        [Column(IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false)]
        public int MaleId { get; set; }

        [Column]
        public string MaleName { get; set; }

        [Column]
        public string MaleMeaning { get; set; }
    }
}
