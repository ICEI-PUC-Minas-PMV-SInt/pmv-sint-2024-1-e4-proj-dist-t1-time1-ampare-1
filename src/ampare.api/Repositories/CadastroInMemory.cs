using ampare.api.Models;

namespace ampare.api.Repositories;

public static class CadastroInMemory
{
    static List<Cadastro> Cadastros { get; }
    static int nextId = 3;
    static CadastroInMemory()
    {
        Cadastros = new List<Cadastro>
        {
            new Cadastro { 
                Id = 1, 
                Nome = "Ong1",
                Email = "ong1@ong.org",
                Senha = "123456",
                Telefone = "11999999999",
                Endereco = "Rua 1, 123",                               
                IsComplete = true  
                },
            new Cadastro {
                Id = 2,
                Nome = "Ong2",
                Email = "ong2@ong.org",
                Senha = "123456",
                Telefone = "11999999999",
                Endereco = "Rua 1, 123",
                IsComplete = true
                },
        };
    }

    public static List<Cadastro> GetAll() => Cadastros; 

    public static Cadastro? Get(int id) => Cadastros.FirstOrDefault(t => t.Id == id); 

    public static void Add(Cadastro cadastro)
    {
        cadastro.Id = nextId++;
        Cadastros.Add(cadastro); 
    }

    public static void Delete(int id)
    {
        var cadastro = Get(id); 
        if (cadastro is null)
            return;

        Cadastros.Remove(cadastro); 
    }

    public static void Update(Cadastro cadastro)
    {
        var index = Cadastros.FindIndex(t => t.Id == cadastro.Id); 
        if (index == -1)
            return;

        Cadastros[index] = cadastro; 
    }
}
