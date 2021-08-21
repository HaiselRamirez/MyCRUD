using Microsoft.EntityFrameworkCore;
using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRUD.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{

		}

		public DbSet<Libro> Libro { get; set; }
	}
}
