using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new();

            /*
            //exercise 3
            string result = GetEmployeesFullInformation(context);
            Console.WriteLine(result);
            */
            /*
            //exercise 4
            string result = /*await/ GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(result);
            */

            //exercise 5
            string result = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(result);


        }

        #region ex3
        public static /*async Task<string>*/ string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new();

            var employees = /*await*/ context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString().Trim();
        }
        #endregion

        #region ex4
        public static /*async Task<*/ string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new();

            var employees = /*await*/ context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        #endregion

        #region ex5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from {e.DepName} - ${e.Salary:f2}");
            }

            return result.ToString().Trim();
        }
        #endregion





    }
}