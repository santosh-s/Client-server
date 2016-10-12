using ExercisesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesViewModel
{
    public class DepartmentViewModel
    {
        private DepartmentDAO _ddao;
       
        public string DepartmentName { get; set; }
        public int Version { get; set; }
        public string Id { get; set; }

    

    //constructor
    public DepartmentViewModel()
    {
        _ddao = new DepartmentDAO();
    }

    public void GetById()
        {
            try
            {
                Department dept = _ddao.GetById(Id);
                Id = dept.GetIdAsString();
                DepartmentName = dept.DepartmentName;
            }
            catch(Exception ex)
            {
                DepartmentName = "not found";
                Console.WriteLine("error in DepartmentViewModel.GetById - " + ex.Message);
            }
        }

    }
}
