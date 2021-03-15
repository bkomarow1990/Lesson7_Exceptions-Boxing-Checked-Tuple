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
            static Employee(){
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
                    throw new NameException("Name is null or whitespace");
                }
                if (name.All(char.IsDigit))
                {
                    throw new NameException("Name must be only letters");
                }
            }
            public Employee(string name, string surname)
            {
                Name = name;
                Surname = surname;
                ID = ++counter;

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
            public uint Salary
            {
                get => salary;
                set
                {
                    this.salary = value;
                }
            }
        }
        
        static void Main(string[] args)
        {
          
        }
    }
}
