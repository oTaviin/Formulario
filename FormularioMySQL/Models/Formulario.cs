using System;
using System.Collections.Generic;

namespace FormularioMySQL.Models
{
    public partial class Formulario
    {
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; } = null!;
        public string DataAula { get; set; } = null!;
        public string NomeDisciplina { get; set; } = null!;
        public int AvaliacaoAula { get; set; }
        public string ComentarioAula { get; set; } = null!;
    }
}
