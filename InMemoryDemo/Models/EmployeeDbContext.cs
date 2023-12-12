﻿using Microsoft.EntityFrameworkCore;

namespace InMemoryDemo.Models
{
	public class EmployeeDbContext : DbContext
	{
		public EmployeeDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
	}
}
