//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ef6Test
//{
//    public class MyContext : DbContext
//    {
//        public DbSet<Status> StatusTable{ get; set; }
//        public DbSet<Request> RequestTable { get; set; }
//    }

//    public class Status
//    {
//        public int Id { get; set; }
//        public String Message { get; set; }
//    }

//    public class Request{
//        public int Id { get; set; }
//        public int StatusId { get; set; }
//        public virtual Status Status { get; set; }
//        public String Message{ get; set; }

//    }


//}
