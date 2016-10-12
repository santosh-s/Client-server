﻿using ExercisesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExercisesWebsite
{
    public class EmployeeController : ApiController
    {
         [Route("api/employees/{name}")]   
         public IHttpActionResult Get(string name)
        {
            try
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                emp.Lastname = name;
                emp.GetByLastname();
                return Ok(emp);
            }
            catch(Exception ex)
            {
                return BadRequest("Retrieve failed - " + ex.Message);
            }
        }


        [Route("api/employees")]
        public IHttpActionResult Put(EmployeeViewModel emp)
        {
            try
            {
                int retVal = emp.Update();
                switch(retVal)
                {
                    case 1:
                        return Ok("Employee " + emp.Lastname + " updated!");
                    case -1:
                        return Ok("Employee " + emp.Lastname + " not updated!");
                    case -2:
                        return Ok("Data is stale for " + emp.Lastname + ", Employee not updated!");
                    default:
                        return Ok("Employee " + emp.Lastname + " not updated!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Update failed - " + ex.Message);
            }
        }
    }


}
