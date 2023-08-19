using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NotePadAPI.Entities
{
	[Table("Usuario")]
	public class Usuario
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
		public string NomeUsuario { get; set; }
		public string SenhaUsuario { get; set; }
		public string Email { get; set; }
		public bool Ativo { get; set; }
	}
}

