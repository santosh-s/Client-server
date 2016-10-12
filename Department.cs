using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesDAL
{
    public class Department:HelpdeskEntity
    {
        //public ObjectId Id {get; set; }

        public string DepartmentName { get; set; }

        //public int Version { get; set; }

    }
}
