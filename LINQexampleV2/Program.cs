using System.Collections.Generic;
using System.Linq;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList= Data.GetDepartments();

////select and where - method syntax
//var result = employeeList.Select(e => new
//{
//    FullName = e.FirstName + " " + e.LastName,
//    AnnualSalary = e.AnnualSalary
//}).Where(e => e.AnnualSalary >50000);
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.FullName, -20} {item.AnnualSalary, 10}");
//}

////select and where - query syntax
//var result = from emp in employeeList
//             where emp.AnnualSalary >=500
//             select new
//{
//    FullName = emp.FirstName + " " + emp.LastName,
//    AnnualSalary = emp.AnnualSalary
//};
//employeeList.Add(new Employee
//{
//    Id = 5,
//    FirstName = "Sam",
//    LastName = "Altman",
//    AnnualSalary =130000.3m,
//    IsManager = true,
//    DepartmentId = 2,
//});
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
//}

////deferred execution example
//var result = from emp in employeeList.GetHighSalariedEmployees()
//             select new
//             {
//                 FullName = emp.LastName + " " + emp.FirstName,
//                 AnnualSalary = emp.AnnualSalary
//             };
//employeeList.Add(new Employee
//{
//    Id = 5,
//    FirstName = "Sam",
//    LastName = "Altman",
//    AnnualSalary = 130000.20m,
//    IsManager = true,
//    DepartmentId = 2
//});
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
//}

////immediate execution example
//var result = (from emp in employeeList.GetHighSalariedEmployees()
//             select new
//             {
//                 FullName = emp.LastName + " " + emp.FirstName,
//                 AnnualSalary = emp.AnnualSalary
//             }).ToList();
//employeeList.Add(new Employee
//{
//    Id = 5,
//    FirstName = "Sam",
//    LastName = "Altman",
//    AnnualSalary = 130000.20m,
//    IsManager = true,
//    DepartmentId = 2
//});
//foreach (var item in result)
//{
//    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
//}

////join operation example - method syntax
//var results = departmentList.Join(employeeList,
//    department => department.Id,
//    employee => employee.DepartmentId,
//    (department, employee) => new
//    {
//        FullName = employee.FirstName + " " + employee.LastName,
//        AnnualSalary = employee.AnnualSalary,
//        DepartmentName = department.LongName,
//    });
//foreach (var item in results)
//{
//    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
//}

////join operation example - query syntax
//var results = from dep in departmentList
//             join emp in employeeList
//             on dep.Id equals emp.DepartmentId
//             select new
//             {
//                 FullName = emp.FirstName + " " + emp.LastName,
//                 AnnualSalary = emp.AnnualSalary,
//                 DepartmentName = dep.LongName,
//             };
//foreach (var item in results)
//{
//    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
//}

////group join operator example - method syntax
//var result = departmentList.GroupJoin(employeeList,
//    dep => dep.Id,
//    emp =>emp.DepartmentId,
//    (dep,employeesGroup) => new
//    {
//        Employees = employeesGroup,
//        DepartmentName = dep.LongName
//    });
//foreach (var item in result)
//{
//    Console.WriteLine($"Department name: {item.DepartmentName}");
//    foreach (var employee in item.Employees)
//    {
//        Console.WriteLine($"\t{employee.FirstName} {employee.LastName}");
//    }
//}

////group join operator example - query syntax
//var result = from dep in departmentList
//             join emp in employeeList
//             on dep.Id equals emp.DepartmentId
//             into employeeGroup
//             select new
//             {
//                 Employees = employeeGroup,
//                 DepartmentName = dep.LongName
//             };
//foreach (var item in result)
//{
//    Console.WriteLine($"Department name: {item.DepartmentName}");
//    foreach (var employee in item.Employees)
//    {
//        Console.WriteLine($"\t{employee.FirstName} {employee.LastName}");
//    }
//}

Console.ReadKey();

public static class EnumerableCollectionExtensionMethods
{
    public static IEnumerable<Employee> GetHighSalariedEmployees( this IEnumerable<Employee> employees )
    {
        foreach ( Employee emp in employees )
        {
            Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

            if (emp.AnnualSalary >= 50000)
                yield return emp;
        }
    }
}

#region Data and structure
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
}
public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Jones",
            AnnualSalary = 60000.3m,
            IsManager = true,
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.1m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 30000.2m,
            IsManager = false,
            DepartmentId = 3
        };
        employees.Add(employee);

        return employees;
    }
    public static List<Department> GetDepartments()
    {
        List<Department> departments = new List<Department>();
        Department department = new Department
        {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance"
        };
        departments.Add(department);
        department = new Department
        {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology"
        };
        departments.Add(department);
        return departments;
    }
}
#endregion