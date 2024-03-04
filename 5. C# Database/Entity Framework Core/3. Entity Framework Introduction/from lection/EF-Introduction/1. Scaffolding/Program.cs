using _1._Scaffolding.Models;
using Microsoft.EntityFrameworkCore;


namespace _1._Scaffolding
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using SoftUniContext context = new();

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


        }
    }
}