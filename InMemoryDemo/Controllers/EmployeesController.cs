using InMemoryDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly EmployeeDbContext _context;

	public EmployeesController(EmployeeDbContext context)
	{
		_context = context;
		SeedData();
	}

	[HttpGet]
	public List<Employee> GetEmployees()
	{
		return _context.Employees.ToList();
	}

	[HttpGet("{id}")]
	public Employee GetEmployeeById(int id) 
	{
		return _context.Employees.SingleOrDefault(e => e.Id == id);
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteEmployee(int id)
	{
		var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
		if (emp != null) 
		{ 
			return NotFound($"Employee with the Id {id} does not exist"); 
		}

		_context.Employees.Remove(emp);
		_context.SaveChanges();

		return Ok($"Employee with the Id {id} deleted Successfully");
	}

	[HttpPost]
	public IActionResult PostEmployee(Employee employee) 
	{
		_context.Employees.Add(employee);
		_context.SaveChanges();
		return Created($"api/employees/{employee.Id}", employee);
		//return Ok(employee);
	}

	[HttpPut("{id}")]
	public IActionResult UpateEmployee(int id, Employee employee)
	{
		var emp = _context.Employees.SingleOrDefault(e => e.Id==id);

		if (emp != null)
		{
			return NotFound($"Employee with the id {id} does not exist");
		}

		if (employee.Name != null)
		{
			emp.Name = employee.Name;
		}

		if (employee.Gender != null)
		{
			emp.Gender = employee.Gender;
		}

		if (employee.Age >  0)
		{
			emp.Age = employee.Age;
		}

		if (employee.Salary != 0)
		{
			emp.Salary = employee.Salary;
		}

		_context.Update(emp);
		_context.SaveChanges();

		return Ok($"Employee with the Id {id} successfully updated");
	}

	private void SeedData()
	{
		Employee emp1 = new Employee()
		{
			Id = 1,
			Name = "uche",
			Gender = "Male",
			Age = 23,
			Salary = 50000
		};

		Employee emp2 = new Employee()
		{
			Id = 2,
			Name = "Onyii",
			Gender = "Male",
			Age = 29,
			Salary = 600000
		};

		_context.Employees.Add(emp1);
		_context.Employees.Add(emp2);
		_context.SaveChanges();
	}
}
