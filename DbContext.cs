using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesDAL
{
    public class DbContext
    {
        IMongoDatabase Db;

        public DbContext()
        {
            MongoClient client = new MongoClient();//connect to local host
            Db = client.GetDatabase("HelpdeskDB");

        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return this.Db.GetCollection<Employee>("employees");
            }
        }

        public IMongoCollection<Department> Departments
        {
            get
            {
                return this.Db.GetCollection<Department>("departments");
            }
        }

        public IMongoCollection<HelpdeskEntity> GetCollection<HelpdeskEntity>()
        {
            return Db.GetCollection<HelpdeskEntity>(typeof(HelpdeskEntity).Name.ToLower() + "s");
        }

    }
}
