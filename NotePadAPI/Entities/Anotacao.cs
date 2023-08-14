using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotePadAPI.Entities
{
	[Table("Anotacao")]
	public class Anotacao
	{
		[Key]
		public int IdAnotacao { get; set; }
		public string DescricaoNota { get; set; }
		public DateTime DataInclusao { get; set; }
		public DateTime DataAlteracao { get; set; }
	}
}

