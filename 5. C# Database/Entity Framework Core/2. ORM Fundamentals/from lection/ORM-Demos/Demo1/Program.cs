using Microsoft.EntityFrameworkCore;

namespace Demo1
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var context = new ApplicationDbContext();

            //old method with old LINQ
            var result = (from employee
                         in context.Employees
                          where employee.FirstName == "Pesho"
                          select employee);
            //.ToList();
            //new method with new LINQ extention methods
            var result2 = /*await*/ context.Employees
                .Where(v => v.FirstName == "Pesho")
                .AsNoTracking();/*remove tracking from entities*/
            //.ToListAsync();
            var materializedResult2 = await result2.ToListAsync();

            var employee5 = await context.Employees.FindAsync(2);

        }
    }
}