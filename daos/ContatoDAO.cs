using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_Learning.models;

namespace c_Learning.daos
{
    public class ContatoDAO
    {
        public void Inserir(Contato obj)
        {
            if(string.isNullOrWhiteSpace(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString();
            }

            using(var conexao = new SqliteConnection("Data Source=db/dados.db"))
            {
                conexao.Open();
                var query = "INSERT INTO Contato (Id, Nome, Email) VALUES (@Id, @Nome, @Email)";
                conexao.Execute(query, obj);
            }
            throw new NotImplementedException();
        }
        public void Alterar(Contato obj)
        {
            if(string.isNullOrWhiteSpace(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString();
            }

            using(var conexao = new SqliteConnection("Data Source=db/dados.db"))
            {
                conexao.Open();
                var query = "UPDATE Contato SET Nome = @Nome, Email = @Email WHERE Id = @Id";
                conexao.Execute(query, obj);
            }
            throw new NotImplementedException();
        }
        public void Excluir(Contato obj)
        {
            if(string.isNullOrWhiteSpace(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString();
            }

            using(var conexao = new SqliteConnection("Data Source=db/dados.db"))
            {
                conexao.Open();
                var query = "DELETE FROM Contato WHERE Id = @Id";
                conexao.Execute(query, new { Id = obj.Id });
            }
            throw new NotImplementedException();
        }
        public IList<Contato> RetornarTodos()
        {

            using(var conexao = new SqliteConnection("Data Source=db/dados.db"))
            {
                conexao.Open();
                var query = "SELECT * FROM Contato ORDER BY Nome";
                return conexao.Query<Contato>(query).ToList();
            }
            throw new NotImplementedException();
        }
        public Contato RetornarPorId(string id)
        {
            
            if(string.isNullOrWhiteSpace(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString();
            } 

            using(var conexao = new SqliteConnection("Data Source=db/dados.db"))
            {
                conexao.Open();
                var query = "SELECT * FROM Contato WHERE Id = @Id";
                return conexao.QuerySingle<Contato>(query, new { Id = id });
            }
            throw new NotImplementedException();
        }
    }
}