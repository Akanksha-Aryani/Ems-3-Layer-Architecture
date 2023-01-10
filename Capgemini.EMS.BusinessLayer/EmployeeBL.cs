using System;
using System.Collections.Generic;
using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;

namespace Capgemini.EMS.BusinessLayer
{
    public class EmployeeBL
    {
        
        public static bool Add(Employee emp)
        {
            
            
            if (emp.Id <= 0)
            {
                throw new EMSException("Employee id should be greater than zero ");

            }
            bool isAdded = EmployeeDal.Add(emp);
            return isAdded;
        }

        
        public static List<Employee> GetList()
        {
            var list = EmployeeDal.GetList();
            return list;

        }

       
        
        public static Employee GetById(int id)
        {
            var emp = EmployeeDal.GetById(id);
            return emp;
        }

        public static bool Update(Employee emp)
        {
            bool isUpdated = EmployeeDal.Update(emp);
            return isUpdated;
        }

        
        public static bool Delete(Employee emp)
        {
            bool isDeleted = EmployeeDal.Delete(emp);
            return isDeleted;
        }
    }
    
}
