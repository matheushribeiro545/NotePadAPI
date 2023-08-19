using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NotePadAPI.Entities
{
	[Table("Anotacao")]
	public class Anotacao
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnotacao { get; set; }
		public string Titulo { get; set; }
		public string Mensagem { get; set; }
		public DateTime DataInclusao { get; set; }
		public DateTime? DataAlteracao { get; set; }
		public int IdUsuario { get; set; }
		public bool Ativo { get; set; }
	}
}

