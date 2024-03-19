var pessoas = new Pessoa[]
{
    new PessoaFisica() { Nome = "Ana", Filiacao = "Jose" },
    new PessoaFisica() { Nome = "Bruno", Filiacao = "Jose" },
    new PessoaJuridica() { Nome = "Empresa A", Contato = "Carlos"},
};

foreach(var obj in pessoas)
{
    Console.WriteLine("E-mail" + obj.PreencherEmail("Prezado(a) Sr(a). {0}, ..."));
}

foreach(var obj in pessoas)
{
    Console.WriteLine("Etiqueta" + obj.PreencherEtiqueta());
}