using ExercisesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExercisesWebsite
{
    public class DepartmentController : ApiController
    {
        [Route("api/departments/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                DepartmentViewModel dept = new DepartmentViewModel();
                dept.Id = id;
                dept.GetById();
                return Ok(dept);
            }
            catch (Exception ex)
            {
                return BadRequest("Retrieve failed - " + ex.Message);
            }
        }
    }
}