using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsimSozlugu
{
    public class NameDataContext: DataContext
    {
        public const string ConnectionString = @"Data Source=isostore:/IsimSozlugu.sdf";
        public NameDataContext(string connectionString)
            : base(connectionString) { }
        public Table<Male> MaleNames;
        public Table<Female> FemaleNames;
        public Table<Unisex> UnisexNames;
        public Table<All> AllNames;
        public Table<Favourite> Favourites;
        public Table<MyUpdate> MyUpdates;
        public Table<AppSettings> AppSettings;
    }
}
