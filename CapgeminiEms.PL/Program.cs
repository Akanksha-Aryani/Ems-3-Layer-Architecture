using Capgemini.EMS.BusinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace CapgeminiEms.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Add Employee 2.Employee List 3.update the employee 4.Delete Employee  5.Exit");
                Console.WriteLine("Enter your choice :");
                string input = Console.ReadLine();
               
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input");
                    return;

                }
                
                switch (choice)
                {
                    case 1:
                        AddEmployee();

                        break;
                    
                    case 2:
                        EmployeeList();

                        break;
                    case 3:
                        UpdateEmployee();
                       break;

                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        

        
        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();
            
            string input;
            int empId;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;

            do
            {

                Console.WriteLine("Enter employee name : ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmployee.Name = input;

            do
            {
                Console.WriteLine("Enter the date of joining :" );
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmployee.DateOfJoining = dateOfJoining;

            //call BL 
            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee Added Successfully");
                }
                else
                {
                    Console.WriteLine("Employee add failed ");
                }
            }
            catch (EMSException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

       
        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("Employee List : ");
            foreach (var emp in list)
            {
                Console.WriteLine(emp.ToString());
            }

        }

     
        private static void UpdateEmployee()
        {
            string input;
            int empId;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));

            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee does not exist");
                return;
            }

            Employee newEmp = new Employee();
            newEmp.Id = empId;
            do
            {

                Console.WriteLine("Enter employee name : ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmp.Name = input;

            do
            {
                Console.WriteLine("Enter the date of joining :");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmp.DateOfJoining = dateOfJoining;

            

            var isUpdated = EmployeeBL.Update(newEmp);
            if (isUpdated)
            {
                Console.WriteLine("Employee updated Successfully");
            }
            else
            {
                Console.WriteLine("Employee update failed ");
            }

        }

        

        private static void DeleteEmployee()
        {
            Employee newEmp = new Employee();
            //getting employee id to delete
            string input;
            int empId;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter employee Id: ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            newEmp.Id = empId;

            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee does not exist");
                return;
            }

           
           
            var isDeleted = EmployeeBL.Delete(newEmp);
            if (isDeleted)
            {
                Console.WriteLine("Deleted succesfully");
            }
            else
            {
                Console.WriteLine("failed to delete ");
            }

        }

    }
}
