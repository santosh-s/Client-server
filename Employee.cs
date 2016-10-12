using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesDAL
{
    public class Employee:HelpdeskEntity//inherit properties from helpdeskentity
    {
        
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public ObjectId DepartmentId { get; set; }//could be a private
        public string GetDepartmentIdAsString()
        {
            return this.DepartmentId.ToString();
        }
        public void SetDepartmentIdFromString(string id)
        {
            this.DepartmentId = new ObjectId(id);
        }
    }
}
