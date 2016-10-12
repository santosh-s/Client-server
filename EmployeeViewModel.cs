using ExercisesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesViewModel
{
    public class EmployeeViewModel
    {
        private EmployeeDAO _dao;
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public int Version { get; set; }
        public string DepartmentId { get; set; }
        public string Id { get; set; }

        //constructor

        public EmployeeViewModel()
        {
            _dao = new EmployeeDAO();
        }


        //find employee using Lastname property
        public void GetByLastname()
        {
            try
            {
                Employee emp = _dao.GetByLastname(Lastname);
                Title = emp.Title;
                Firstname = emp.Firstname;
                Lastname = emp.Lastname;
                Phoneno = emp.Phoneno;
                Email = emp.Email;
                //Id = emp.Id.ToString();
                Id = emp.GetIdAsString();
                //DepartmentId = emp.DepartmentId.ToString();
                DepartmentId = emp.GetDepartmentIdAsString();
                Version = emp.Version;
            }
            catch(Exception ex)
            {
                Lastname = "not found";
                Console.WriteLine("Error in EmployeeViewModel.GetByLastName -" + ex.Message);
            }
        }

        //add method update()
        public int Update()
        {
            UpdateStatus opStatus;

            try
            {
                Employee emp = new Employee();
                emp.SetIdFromString(Id);
                emp.SetDepartmentIdFromString(DepartmentId);
                emp.Title = Title;
                emp.Firstname = Firstname;
                emp.Lastname = Lastname;
                emp.Phoneno = Phoneno;
                emp.Email = Email;
                emp.Version = Version;
                opStatus = _dao.UpdateWithRepo(emp);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                opStatus = UpdateStatus.Failed;
            }

            return Convert.ToInt16(opStatus);//Web layer won't know about the enum
        }

    }
 }
