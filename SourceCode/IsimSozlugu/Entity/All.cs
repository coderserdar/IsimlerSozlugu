﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsimSozlugu
{
    [Table]
    public class All
    {
        [Column(IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false)]
        public int AllId { get; set; }

        [Column]
        public string AllName { get; set; }

        [Column]
        public string AllMeaning { get; set; }

        [Column]
        public string AllNameMeaning { get; set; }

        [Column]
        public string AllGender { get; set; }
    }
}
