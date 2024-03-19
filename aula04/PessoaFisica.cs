using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula04
{
    public class PessoaFisica : Pessoa
    {
        public string Filiacao { get; set; }
        public override string PreencherEmail(string texto)
        {
            return String.Format(texto, this.Nome);
        }
        
        public override string PreencherEmail()
        {
            return $"{Nome}, {Filiacao}";
        }
    }
}