using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula04
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public abstract string PreencherEmail(string texto);
        public abstract string PreencherEtiqueta(string texto);
    }
}