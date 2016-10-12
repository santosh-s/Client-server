using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesDAL
{
    public class DepartmentDAO
    {
        public Department GetById(string id)
        {
            Department emp = new Department();
            try
            {
                DbContext ctx = new DbContext();
                var filter = Builders<Department>.Filter.Eq("Id", new ObjectId(id));
                emp = ctx.Departments.Find(filter).SingleOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in DepartmentDAO.GetById " + ex.Message);
            }
            return emp;
        }
    }
}
