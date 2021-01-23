//carContext.cs 是資料庫內容類型, 用來實現EF對SQL資料庫的作業, 跟car.cs屬模型類別不同

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jan17Pratice.Models
{
    public class carContext : DbContext   //Manage entity framework database
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public carContext() : base("name=carContext")
        {
            DbSet<car> cars;  
        }

        public System.Data.Entity.DbSet<Jan17Pratice.Models.car> cars { get; set; }
    }
}
