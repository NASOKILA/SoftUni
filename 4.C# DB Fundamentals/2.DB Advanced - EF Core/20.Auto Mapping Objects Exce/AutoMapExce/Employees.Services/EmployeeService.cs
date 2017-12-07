namespace Employees.Services
{
    using AutoMapper;
    using Employees.Data;
    using Employees.DtoModels;
    using Employees.Models;
    using System;
    using System.Linq;

    public class EmployeeService
    {
        //Vzimame si dbContexta
        private readonly EmployeesContext db;

        public EmployeeService(EmployeesContext db)
        {
            this.db = db;
        }

        public EmployeeDto ById(int employeeId)
        {
            //Vzimame si rabotnika
            var employee = db.Employees.Find(employeeId);

            //Pravim si DTO-to kato polzvame Automappera
            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            //nie iskame da dobavim rabotnik v bazata
            //kato parametur priema EmployeeDto

            //POLZVAME AUTOMAPPERA ZA DA SI MAPNEM OBEKTA 
            Employee employee = Mapper.Map<Employee>(dto);

            db.Employees.Add(employee);

            db.SaveChanges();
       
        } 
        
        public Employee EmployeeById(int id)
        {

            var employee = db
                .Employees
                .SingleOrDefault(e => e.Id == id);

            if (employee == null)
                throw new ArgumentException("Employee does not exist !");

            return employee;

            /*
             
            Console.WriteLine($"ID: {employee.Id} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:f2}");
            Console.WriteLine($"BirthDay: {employee.BirthDay}");
            Console.WriteLine($"Address: {employee.Address}");

             */
        }

        public EmployeePersonalDto PeronalById(int employeeId)
        {
            //Vzimame si rabotnika
            var employee = db.Employees.Find(employeeId);

            //Pravim si DTO-to kato polzvame Automappera
            //Tozi put mapvame EmployeePersonalDto kum Employee
            //OBACHE ZA DA STANE TRQBVA DA GO DOBAVIM V AutomapperProfile()
            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            //vruhtame samoto Dto
            return employeeDto;
        }

        public string SetAddress(int id, string address)
        {
            var employee = db
                .Employees
                .SingleOrDefault(e => e.Id == id);

            if (employee == null)
                throw new ArgumentException("Employee does not exist !");

            employee.Address = address;

            db.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }
        
        public string SetBirthday(int id, DateTime date)
        {
            var employee = db
                .Employees
                .SingleOrDefault(e => e.Id == id);

            if (employee == null)
                throw new ArgumentException("Employee does not exist !");
            
            employee.BirthDay = date;

            db.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }
        
    }
}
