using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula04
{
    public class PessoaJuridica : Pessoa
    {
        public string Contato { get; set; } = "";
        public override string PreencherEmail(string texto)
        {
            return String.Format(texto, this.Contato);
        }

        public override string PreencherEmail()
        {
            return $"Aos cuidados de {Contato}, {Nome}, Endereco: ....";
        }
    }
}