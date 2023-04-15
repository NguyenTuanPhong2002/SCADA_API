using Microsoft.EntityFrameworkCore;
using MyWebAPI_24_03.Model1;
using System.Collections.Generic;

namespace MyWebAPI_24_03.Data
{
    public class MyDataModel1DbContext : DbContext
    {
        public MyDataModel1DbContext(DbContextOptions<MyDataModel1DbContext> opt) : base(opt)
        {

        }
        #region DbSet
        public DbSet<APIConnect>? APIConnectDb { get; set; }
        public DbSet<APIData>? APIDataDb { get; set; }
        public DbSet<APINameClient>? APINameClientDb { get; set; }

        #endregion
    }

}
