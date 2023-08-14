using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotePadAPI.Entities
{
	[Table("Usuario")]
	public class Usuario
	{
		[Key]
		public int IdUsuario { get; set; }
		public string NomeUsuario { get; set; }
		public string SenhaUsuario { get; set; }
	}
}

