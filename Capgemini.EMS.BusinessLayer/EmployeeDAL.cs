using Capgemini.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.EMS.DataAccessLayer
{
    public class EmployeeDal
    {
        static List<Employee> list = new List<Employee>();
        //case 1
        //add employee
        public static bool Add(Employee emp)
        {
            list.Add(emp);
            return true;
        }

        //case 2
        //getting list
        public static List<Employee> GetList()
        {
            return list;
        }

       
        
        
        
        public static Employee GetById(int id)
        {
            
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            return emp;
        }

        public static bool Update(Employee emp)
        {
            var existingEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            existingEmp.Name = emp.Name;
            existingEmp.DateOfJoining = emp.DateOfJoining;

            return true;
        }

        public static bool Delete(Employee emp)
        {
            var deletableEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            bool v = list.Remove(deletableEmp);
           
            
            return true;

        }

        
    }
}
