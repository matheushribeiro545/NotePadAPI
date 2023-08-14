using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotePadAPI.Entities;

namespace NotePadAPI.Context
{
	public class NotePadContext : DbContext
	{
		public NotePadContext(DbContextOptions<NotePadContext> options) : base(options)
		{

		}

		public DbSet<Anotacao> Anotacao { get; set; }
		public DbSet<Usuario> Usuario { get; set; }
	}
}

