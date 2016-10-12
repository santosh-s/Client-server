using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercisesDAL;
using ExercisesViewModel;

namespace ExercisesTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [TestMethod]//signifies it is a test method
        public void EmployeeDAOReturnByLastnameShouldReturnEmployee()

        {
            EmployeeDAO dao = new EmployeeDAO();
            Employee someEmployee = dao.GetByLastname("Smartypants");
            Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        }

        [TestMethod]
        public void EmployeeDAOReturnByEmailShouldReturnEmployee()
        {
            EmployeeDAO dao = new EmployeeDAO();
            Employee someEmployee = dao.GetByEmail("s_shrestha@fanshaweonline.ca");
            Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        }

        [TestMethod]
        public void EmployeeViewModelMReturnBySurnameShouldLoadFirstname()

        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Smartypants";
            vm.GetByLastname();
            Assert.IsTrue(vm.Firstname.Length > 0);
        }

        [TestMethod]
        public void DepartmentDAOReturnByIdShouldReturnDepartment()
        {
            DepartmentDAO dao = new DepartmentDAO();
            Department deptName = dao.GetById("57d6e9dccf388f2f1c790944");
            Assert.IsNotNull(deptName.DepartmentName);
            Assert.IsInstanceOfType(deptName, typeof(Department));
        }

        [TestMethod]
        public void DepartmentViewModelReturnByIdShouldReturnDepartmentName()
        {
            DepartmentViewModel dvm = new DepartmentViewModel();
            dvm.Id = "57d6e9dccf388f2f1c790944";
            dvm.GetById();
            Assert.IsTrue(dvm.Id.Length > 0);
        }
        */

        [TestMethod]
        public void UpdateSameEmployeeTwiceInDALShouldBeStaleStatus()
        {
            EmployeeDAO dao = new EmployeeDAO();
            //simulate user 1 getting an employee
            Employee user1Employee = dao.GetByLastname("Shrestha");
            //simulate user 2 getting the same employee
            Employee user2Employee = dao.GetByLastname("Shrestha");
            //change phone# for user1
            user1Employee.Phoneno = "555-555-9999";
            //user1 makes update

            UpdateStatus status = dao.UpdateWithRepo(user1Employee);
            if(status==UpdateStatus.Ok)//should be ok for 1st update
            {
                //change phone# for user2
                user2Employee.Phoneno = "555-555-2222";
                //concurrency exception status should be stale
                status = dao.UpdateWithRepo(user2Employee);
            }
            Assert.IsTrue(status == UpdateStatus.Stale);
        }



        [TestMethod]
        public void UpdateSameEmployeeTwiceInVMShouldBeStaleInt()
        {
            int rowsUpdated = 0;
            EmployeeViewModel user1Vm = new EmployeeViewModel();
            //simulate user 1 getting an employee
            user1Vm.Lastname = "Shrestha";
            user1Vm.GetByLastname();

            EmployeeViewModel user2Vm = new EmployeeViewModel();
            //simulate user 1 getting an employee
            user2Vm.Lastname = "Shrestha";
            user2Vm.GetByLastname();

            //change phone# for user1
            user1Vm.Phoneno = "555-555-5551";
            //user1 makes update

            rowsUpdated = user1Vm.Update();
            if (rowsUpdated == 1)//if user 1 updated ok should be 1
            {
                //change phone# for user2
                user2Vm.Phoneno = "555-555-5552";
                //concurrency exception status should be stale
                rowsUpdated = user2Vm.Update();
            }
            Assert.IsTrue(rowsUpdated == -2);
        }



    }
}
