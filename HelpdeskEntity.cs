﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesDAL
{
    public class HelpdeskEntity

    {
        public ObjectId Id { get; set; }
        public int Version { get; set; }
        public string GetIdAsString()
        {
            return this.Id.ToString();
        }
        public void SetIdFromString(string id)
        {
            this.Id = new ObjectId(id);
        }
    }
}
