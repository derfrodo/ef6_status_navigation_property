using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ef6Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Status status = null;

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            using (var db = new MyContext())
            {
                db.Database.Initialize(force: true);
                var statusList = db.StatusTable.ToList().Where(s => s.Message == "Test");
                 status = statusList.FirstOrDefault();


                if (status == null)
                {
                    status = new Status { Message = "Test" };
                    db.StatusTable.Add(status);
                    db.SaveChanges();
                }
            //}

            //using (var db = new MyContext())
            //{
            //    db.Set<Status>().Attach(status);

                var request = new Request { Message = "someRequest", Status = status };
                db.RequestTable.Add(request);
                db.SaveChanges();

                // Display all Blogs from the database 
                var requests = (from r in db.RequestTable
                                orderby r.RequestId
                                select r).ToList();

                Console.WriteLine("All requests in the database:");
                foreach (var item in requests)
                {
                    Console.WriteLine(item.Message);
                }

                // Display all Statuses from the database 
                var statuses = (from r in db.StatusTable
                                orderby r.StatusId
                                select r).ToList();

                Console.WriteLine("All statuses in the database:");

                foreach (var item in statuses)
                {
                    Console.WriteLine(item.Message);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USR");
        }
        public DbSet<Status> StatusTable { get; set; }
        public DbSet<Request> RequestTable { get; set; }
    }

    public class Status
    {
        public int StatusId { get; set; }
        public String Message { get; set; }
    }

    public class Request
    {
        public int RequestId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public String Message { get; set; }

    }
}
