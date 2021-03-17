using System;
using System.Collections.Generic;
using System.Linq;

namespace Exceptions
{
    class Program
    {

        class Employee
        {
            private readonly uint ID;
            private static uint counter;
            private uint salary;
            string name;
            string surname;
            static Employee()
            {
                counter = 0;
            }
            void checkName(string name)
            {
                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new NameException("Name is null or whitespace");
                }
                if (name.All(char.IsDigit))
                {
                    throw new NameException("Name must be only letters");
                }
            }
            void checkSurname(string name)
            {
                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new SurnameException("Surname is null or whitespace");
                }
                if (name.All(char.IsDigit))
                {
                    throw new SurnameException("Surname must be only with letters");
                }
            }
           
            public Employee(string name="NoName", string surname="NoSurname")
            {
                Name = name;
                Surname = surname;
                ID = ++counter;

            }
            public void inputName()
            {

                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.WriteLine("Enter Name...");
                        string tmp = Console.ReadLine();
                        checkName(tmp);
                        this.Name = tmp;
                        exit = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            public void inputSurname()
            {

                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.WriteLine("Enter Surname...");
                        string tmp = Console.ReadLine();
                        checkSurname(tmp);
                        this.Surname = tmp;
                        exit = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            public void inputSalary()
            {

                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.WriteLine("Enter Salary...");
                        //string tmp = Console.ReadLine();
                        addSalary(UInt32.Parse(Console.ReadLine()));
                        exit = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($" 1:  {ex.Message}, need correct" );
                    }
                }

            }
            public uint ID_
            {
                get => ID;
            }
            public string Name
            {
                get => name;
                set
                {
                    try
                    {
                        checkName(value);
                    }
                    catch (NameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    this.name = value;
                }
               
            }
            public override string ToString()
            {
                return $"Employee:\n Name: {name},{surname} Salary: {salary}";
            }
            public void addSalary(uint money)
            {
                //try {
                //    this.salary = checked(money + salary);
                //}
                //catch (OverflowException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                checked
                {
                    this.salary += money;
                }
            }

            public string Surname
            {
                get => surname;
                set
                {
                    try
                    {
                        checkSurname(value);
                    }
                    catch (SurnameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    this.surname = value;
                }

            }
            public void inputAddSalary (){
                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.WriteLine("Enter Salary...");
                        addSalary( UInt32.Parse(Console.ReadLine()));
                        exit = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            public uint Salary
            {
                get => salary;
                set
                {
                    this.salary = value;
                }
            }
        }
        class Departament
        {
            List<Employee> employees = new List<Employee>();
            uint count_employees=0;
            public void addEmployee(Employee employee)
            {
                if (employee == null)
                {
                    throw new EmployeeException("Employee is null");
                }
                if (employees.Count+1 > count_employees)
                {
                    throw new EmployeeException("Too many Employeers");
                }
                employees.Add(employee);
            }
            public void inputEmployee() {
                if (employees.Count + 1 > count_employees)
                {
                    throw new EmployeeException("Too many Employeers");
                }
                    Employee employee = new Employee();
                    employee.inputName();
                    employee.inputSurname();
                    employee.inputSalary();
                    addEmployee(employee);
                    Console.WriteLine("Employee is added");
                
            }
            public void deleteEmployee(int index)
            {
                if (employees.Count == 0)
                {
                    throw new EmployeeException("Haven`t Employyers");
                }
                if (index > employees.Count || index < 0)
                {
                    throw new Exception(" Incorrect index ");
                }
                employees.RemoveAt((int)index);
            }
            public override string ToString()
            {
                return $"Departament: {String.Join('\n', employees)}";
            }
            public uint CountEmployees
            {
                get => count_employees;
                set
                {
                    count_employees = value;
                }
            }
            public Departament(Employee employee, uint count_employees)
            {
                CountEmployees = count_employees;
                addEmployee(employee);
            }
            public Departament(uint count_employees)
            {
                CountEmployees = count_employees;
            }
        }
        static void Main(string[] args)
        {
            Employee emp = new Employee("Gosha", "Watrushkin");
            emp.inputName();
            Console.WriteLine("Input add Salary");
            emp.inputAddSalary();
            Console.WriteLine(emp);
            Departament departament_jun = new Departament(5);
            Console.WriteLine("Adding employee:");
            departament_jun.inputEmployee();
            Console.WriteLine(departament_jun);
            departament_jun.deleteEmployee(0);
        }
    }
}
