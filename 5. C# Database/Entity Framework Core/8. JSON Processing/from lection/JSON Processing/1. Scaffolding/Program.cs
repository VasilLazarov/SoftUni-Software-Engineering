﻿using _1._Scaffolding.Models;
using _1._Scaffolding.Models.DTO;
using _1._Scaffolding.Models.MapperProfiles;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;

//using System.Text.Json;// remove if we use Newtonsoft.Json - because same as under this
using Newtonsoft.Json; // must be removed when use System.Text.Json because have same methods JsonSerialiser and have errors

namespace _1._Scaffolding
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //using SoftUniContext context = new();
            Console.WriteLine("Hello, Mr. Lazarov\n");

            #region create map for autoMapper - for lection auto mapping
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, PersonDto>()
                    .ForMember(dto => dto.AddressText,
                        opt => opt.MapFrom(src => src.Address.AddressText))
                    .ForMember(dto => dto.TownName, 
                        opt => opt.MapFrom(src => src.Address.Town.Name));
            });

            //var mapper = new Mapper(mapperConfig);
            var mapper = mapperConfig.CreateMapper();


            //create mapper with profile class
            var mapperConfig2 = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TestProfile>();
            });
            var mapper2 = mapperConfig.CreateMapper();

            #endregion




            //Exercises from lection EF-Introduction
            #region Exercises from EF-Introduction lection
            #region FirstDemo
            /*
            var employee = await context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == 147);

            
            string query = context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Projects)
                .Where(e => e.EmployeeId == 147)
                .ToQueryString();
            
            
            if (employee == null)
            {
                Console.WriteLine("Employee does't exists");
            }
            else
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName} \n" + 
                    $"Department: {employee.Department.Name}, id: {employee.Department.DepartmentId} \n" +
                    $"Manager: {employee.Manager?.FirstName} {employee.Manager?.LastName} \n" +
                    $"First project: {employee.Projects.OrderBy(p => p.StartDate).FirstOrDefault()?.Name}");


                //Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
                //Console.WriteLine($"Department: {employee.Department.Name} with id: {employee.Department.DepartmentId}");
                //Console.WriteLine($"Manager: {employee.Manager?.FirstName} {employee.Manager?.LastName}");
                //Console.WriteLine($"First project: {employee.Projects.OrderBy(p => p.StartDate).FirstOrDefault()?.Name}");
            }

            var employee2 = await context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Projects)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    //Name = $"{e.FirstName} {e.LastName}", // dont use like this because dont make concatenation in db, make it after gettting data in memory
                    Name = e.FirstName + " " + e.LastName,
                    Department = e.Department.Name,
                    //Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Manager = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.Projects.Select(p => new
                    {
                        p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                })
                .ToQueryString();
                //.FirstOrDefaultAsync(e => e.Id == 147);

            Console.WriteLine();
            */
            #endregion

            #region Add entity
            //make project like this and after that add
            /*var project = new Project()
            {
                Name = "Judge System",
                StartDate = new DateTime(2023, 1, 26),
            };*/
            /*
            //or crate project directly in Add method
            await context.Projects.AddAsync(new Project
            {
                Name = "Judge System",
                StartDate = new DateTime(2023, 1, 26),
                Description = "Description"
            });
            Console.WriteLine();
            await context.SaveChangesAsync();
            Console.WriteLine();
            */
            #endregion

            #region Update entity
            /*
            var employee = await context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == 147);
            if (employee != null)
            {
                employee.ManagerId = 143;

                var project = employee.Projects
                .FirstOrDefault(p => p.ProjectId == 34);
                if(project != null)
                {
                    employee.Projects.Remove(project);
                }
                else
                {
                    project = context.Projects
                        .Find(34);
                    if(project != null)
                    {
                        employee.Projects.Add(project);
                    }
                }
            }

            await context.SaveChangesAsync();
            */
            #endregion
            #endregion


            //Exercises from LINQ lection
            #region Exercises from LINQ lection
            #region first demo - Select
            //Create proection with select for get info when reading and get only data whick we want not all

            //#region ex like in lection
            ///*
            //var employeesWithTown = await context
            //    .Employees
            //    //.Include(e => e.Address)
            //    //.Include(e => e.Address.Town)
            //    .Select(employee => new
            //    {
            //        EmployeeName = employee.FirstName,
            //        TownName = employee.Address.Town.Name,
            //    })
            //    .ToListAsync();
            //foreach (var item in employeesWithTown)
            //{
            //    Console.Write($"{item.EmployeeName} - {item.TownName}");
            //}*/
            //#endregion

            ///*
            //var test = await context
            //    .Employees
            //    .Include(e => e.Address)
            //    .ThenInclude(a => a.Town)
            //    .ToListAsync();*/

            ////from lection with Stamo test difference with and without Select(Second is also with Select but we select everything(almost) - because without select and anonymous objects we cant serialize because have error cycle)
            //var employees = await context
            //    .Employees
            //    .Select(e => new
            //    {
            //        EmployeeName = e.FirstName,
            //        TownName = e.Address.Town.Name
            //    })
            //    .ToListAsync();
            //string empl = JsonSerializer.Serialize(employees);
            //#region test length with serialization
            ////string empl2 = "[";
            ////foreach (var employee in employees)
            ////{
            ////    empl2 += $",{JsonSerializer.Serialize(employee)}";
            ////}
            ////empl2 += "]";
            ////Console.WriteLine($"{empl.Length} == {empl2.Length}");

            ////Console.WriteLine(empl.Substring(0, 60));
            ///*string empl2 = "";
            //foreach (var employee in employees)
            //{
            //    empl2 += JsonSerializer.Serialize(employee);
            //}*/
            ///*Console.WriteLine("first");
            //Console.WriteLine(empl.Substring(0, 20));
            //Console.WriteLine("---------------------------------");
            //Console.WriteLine("second");
            //Console.WriteLine(empl2.Substring(0, 20));*/
            //#endregion

            //var employeesLong = await context
            //    .Employees
            //    .Include(e => e.Address)
            //    .ThenInclude(a => a.Town)
            //    .Select(e => new
            //    {
            //        EmployeeId = e.EmployeeId,
            //        FirstName = e.FirstName,
            //        MiddleName = e.MiddleName,
            //        LastName = e.LastName,
            //        JobTitle = e.JobTitle,
            //        DepartmentId = e.DepartmentId,
            //        ManagerId = e.ManagerId,
            //        HireDate = e.HireDate,
            //        Salary = e.Salary,
            //        AddressId = e.AddressId,
            //        AddressText = e.Address.AddressText,
            //        TownId = e.Address.TownId,
            //        TownName = e.Address.Town.Name
            //    })
            //    .ToListAsync();

            //string emplLong = JsonSerializer.Serialize(employeesLong);
            //#region also for test with upper
            ///*string emplLong = "";
            //foreach (var employee in employeesLong)
            //{
            //    emplLong += JsonSerializer.Serialize(employee);
            //}
            //Console.WriteLine("second");
            //Console.WriteLine(emplLong.Substring(0, 20));*/
            //#endregion

            //Console.WriteLine($"ProjectionLength - {empl.Length}, \nFullLength - {emplLong.Length}");
            #endregion

            #region second demo - Aggregation functions
            ////Use agregation function: Count, Sum, Average, Min and Max 

            //var employeesWithoutMiddleNameCount = await context
            //    .Employees
            //    .CountAsync(e => e.MiddleName == null);

            //Console.WriteLine($"Count of employees without middleName: {employeesWithoutMiddleNameCount}");

            //var employeesWithoutMiddleNameSumOfSalaries = await context
            //    .Employees
            //    .Where(e => e.MiddleName == null)
            //    .SumAsync(e => e.Salary);

            //Console.WriteLine($"Sum of salaries of employees without middleName: {employeesWithoutMiddleNameSumOfSalaries}");

            //var employeesWithoutMiddleNameAverageSalary = await context
            //    .Employees
            //    .Where(e => e.MiddleName == null)
            //    .AverageAsync(e => e.Salary);

            //Console.WriteLine($"Average salary of employees without middleName: {employeesWithoutMiddleNameAverageSalary}");

            //var employeesWithoutMiddleNameMinSalary = await context
            //    .Employees
            //    .Where(e => e.MiddleName == null)
            //    .MinAsync(e => e.Salary);

            //Console.WriteLine($"Min salary of employee without middleName: {employeesWithoutMiddleNameMinSalary}");

            //var employeesWithoutMiddleNameMaxSalary = await context
            //    .Employees
            //    .Where(e => e.MiddleName == null)
            //    .MaxAsync(e => e.Salary);

            //Console.WriteLine($"Max salary of employee without middleName: {employeesWithoutMiddleNameMaxSalary}");

            #endregion

            #region third demo - Join tables
            ////Use function Join to join tables - don't use it in EF because we can make it with Include(expression to navigation property)
            //var employees = context
            //    .Employees.Join(
            //    context.Departments,
            //    e => e.DepartmentId,
            //    d => d.DepartmentId,
            //    (e, d) => new
            //    {
            //        Employee = e.FirstName,
            //        JobTitle = e.JobTitle,
            //        Department = d.Name
            //    });
            //foreach (var item in employees)
            //{
            //    Console.WriteLine($"Name: {item.Employee}, JobTitle: {item.JobTitle}, Department: {item.Department}");
            //}

            #endregion

            #region fourth demo - Grouping
            ////Use Group() to grouping tables

            //var employeesGroupByJobTitle = await context
            //    .Employees
            //    .GroupBy(e => new
            //    {
            //        e.DepartmentId,
            //        e.Department.Name
            //    })
            //    .Select(gr => new
            //    {
            //        Department = gr.Key.Name,
            //        AvgSalary = gr.Average(e => e.Salary)
            //    })
            //    .ToListAsync();

            #endregion

            #region fifth demo - SelectMany

            ///*var addresses = await context.Addresses
            //    .Select(a => new
            //    {
            //        a.AddressText,
            //        a.Town.Name,
            //        a.Employees
            //    })
            //    .ToListAsync();*/
            //var addresses = await context.Addresses
            //    .Select(a => a.Employees)
            //    .ToListAsync();

            //var addresses2 = await context.Addresses
            //    .SelectMany(a => a.Employees)
            //    .ToListAsync();

            //var addresses3 = await context.Addresses
            //    .SelectMany(a => a.Employees,
            //    (a, e) => new
            //    {
            //        Adress = a.AddressText,
            //        Town = a.Town.Name,
            //        Employee = e
            //    })
            //    .OrderBy(e => e.Employee.AddressId)
            //    .ToListAsync();

            ///*
            ////my test
            //var empl = await context.Employees
            //    .OrderBy(e => e.AddressId)
            //    //.GroupBy(e => e.AddressId)
            //    .ToListAsync();
            //*/


            //Console.WriteLine();
            #endregion

            #region Result Models - Dto

            //var employees = await context.Employees
            //    .Select(e => new EmployeeDto()
            //    {
            //        Name = e.FirstName + " " + e.LastName,
            //        Department = e.Department.Name,
            //        Manager = e.Manager.FirstName + " " + e.Manager.LastName
            //    })
            //    .ToListAsync();

            //var employeesQuery = context.Employees
            //    .Select(e => new EmployeeDto()
            //    {
            //        Name = e.FirstName + " " + e.LastName,
            //        Department = e.Department.Name,
            //        Manager = e.Manager.FirstName + " " + e.Manager.LastName
            //    })
            //    .ToQueryString();


            //Console.WriteLine();

            #endregion


            #region my tests
            //var empltest = await context.Employees
            //    .Include(e => e.Address)
            //    .Include(e => e.Department)
            //    .Where(e => e.Salary > 40000 /*&& e.Address.AddressText != null*/)
            //    .ToListAsync();

            //Console.WriteLine();
            #endregion
            #endregion


            //Exercises from Advanced Querying lection
            #region Exercises from Advanced Querying lection

            #region Native Sql query
            //Console.Write("Input min salary: ");
            //int salaryMin = int.Parse(Console.ReadLine());
            //SqlParameter salaryMinSql = new("@salary", salaryMin);

            ///*var employees = context.Employees
            //    .FromSqlRaw("SELECT * FROM Employees WHERE Salary > {0} ORDER BY Salary DESC", salaryMin)
            //    .ToList();*/
            //var employees = context.Employees
            //    .FromSqlRaw("SELECT * FROM Employees WHERE Salary > @salary ORDER BY Salary DESC", salaryMinSql)
            //    .ToList();
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary}");
            //}
            #endregion


            #region State tracking

            #region myTest - test toList does can make changes and save with entity tracker
            //var employeesTest = await context.Employees
            //    .Where(e => e.EmployeeId <= 5)
            //    .ToListAsync();

            //foreach (var e in employeesTest)
            //{
            //    e.Salary -= 1; 
            //}

            //await context.SaveChangesAsync();

            #endregion

            #region Use AsNoTracking
            //// Use AsNoTracking(dettache objects from entity tracker) when we want to show data without modifying
            //var employee = await context.Employees
            //    .Where(e => e.EmployeeId == 1)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync();

            //employee.FirstName = "Pesho";

            //await context.SaveChangesAsync();

            ////for attached object again we do this
            //var entry = context.Entry(employee);
            //entry.State = EntityState.Modified;
            ////and now we can make changes and call SaveChanges to save in DB

            #endregion


            #endregion


            #region Bulk Operations

            //view in presentation and test


            #endregion


            #region Types of Loading

            #region Explicit loading
            //var employee = await context.Employees
            //    .Where(e => e.EmployeeId == 1)
            //    //.AsNoTracking() // if is not tracking we cant use explicit loading after that
            //    .FirstOrDefaultAsync();

            //await context.Entry(employee)
            //    .Reference(e => e.Department)
            //    .LoadAsync();

            //Console.WriteLine();

            #endregion

            #region Eager loading
            ////Eager is better for web aplications
            ////For Eager loading we use .Include()
            //var employee2 = await context.Employees
            //    .Where(e => e.EmployeeId == 1)
            //    .Include(e => e.Department)
            //    .AsNoTracking() // if is not tracking we cant use explicit loading after that
            //    .FirstOrDefaultAsync();

            //Console.WriteLine();

            #endregion

            #region Lazy loading


            //view in presentation and test


            #endregion


            #endregion


            #region Concurrency Checks
            //default it works in mode "last one win"

            //if we want "first win" we must create in model new property:
            //[ConcurrencyCheck]
            //public Guid Consurrency { get; set; }

            #endregion


            #endregion


            //Exercises from Auto Mapping lection
            #region Exercises from Auto Mapping lection

            #region first demo - without DTO
            //var employees = await context.Employees
            //    .Where(e => e.EmployeeId <= 50)
            //    .Include(e => e.Address)
            //    .ThenInclude(a => a.Town)
            //    .AsNoTracking()
            //    .ToListAsync();

            //Console.WriteLine();

            #endregion

            #region first demo - with DTO
            //var employees = await context.Employees
            //    .Where(e => e.EmployeeId <= 50)
            //    .Select(e => new PersonDto()
            //    {
            //        FirstName = e.FirstName,
            //        LastName = e.LastName,
            //        AddressText = e.Address.AddressText,
            //        TownName = e.Address.Town.Name
            //    })
            //    .ToListAsync();

            //Console.WriteLine();


            #endregion

            #region Use Auto mapper
            //var employees = await context.Employees
            //    .FirstOrDefaultAsync();
            //var personDto = mapper.Map<PersonDto>(employees);


            //var employees = await context.Employees
            //    .Where(e => e.EmployeeId <= 50)
            //    .ProjectTo<PersonDto>(mapperConfig2)
            //    .ToListAsync();



            //Console.WriteLine();



            #endregion


            #endregion


            //Exercises from JSON Processing lection
            #region Exercises from JSON Processing lection

            #region Serialize with System.Text.Json
            //remove using Newtonsoft.Json for working - because have same method JsonSerialize and have erorrs
            //var person = new PersonDto()
            //{
            //    FirstName = "Vasil",
            //    LastName = "Lazarov",
            //    AddressText = "Mladost 1",
            //    TownName = "Sofia"
            //};

            //var serializerOptions = new JsonSerializerOptions()
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true,
            //};

            //string result = JsonSerializer.Serialize(person, serializerOptions);

            //File.WriteAllText("../../../person.json", result);

            //Console.WriteLine(result);

            //string json = File.ReadAllText("../../../person.json");

            //var newPerson = JsonSerializer.Deserialize<PersonDto>(json, serializerOptions);

            //Console.WriteLine();
            #endregion


            #region Serialize with Newtonsoft.Json

            //var person = new PersonDto()
            //{
            //    FirstName = "Vasil",
            //    LastName = "Lazarov",
            //    AddressText = "Mladost 1",
            //    TownName = "Sofia"
            //};

            var person = new[] { 
                new PersonDto()
                {
                    FirstName = "Vasil",
                    LastName = "Lazarov",
                    AddressText = "Mladost 1",
                    TownName = "Sofia"
                },
                new PersonDto()
                {
                    FirstName = "Maria",
                    LastName = "Veleva",
                    AddressText = "Studentski grad",
                    TownName = "Sofia"
                },
            };

            //JsonSerializerSettings
            var serializerOptions = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
            };

            string result = JsonConvert.SerializeObject(person, serializerOptions);

            File.WriteAllText("../../../person.json", result);

            Console.WriteLine(result);

            string json = File.ReadAllText("../../../person.json");

            var newPerson = JsonConvert.DeserializeObject<PersonDto[]>(json, serializerOptions);

            Console.WriteLine();


            #endregion



            #endregion


        }
    }
}