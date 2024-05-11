using ampare.api.Models;

namespace ampare.api.Repositories;

public static class OngInMemory
{
    static List<Ong> Ongs { get; }
    static int nextId = 3;
    static OngInMemory()
    {
        Ongs = new List<Ong>
        {
            new Ong { 
                Id = 1, 
                Nome = "Ong1",
                Email = "ong1@ong.org",
                Senha = "123456",
                Telefone = "11999999999",
                Endereco = "Rua 1, 123",                               
                IsComplete = true  
                },
            new Ong {
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

    public static List<Ong> GetAll() => Ongs; 

    public static Ong Get(int id) => Ongs.FirstOrDefault(t => t.Id == id); 

    public static void Add(Ong ong)
    {
        ong.Id = nextId++;
        Ongs.Add(ong); 
    }

    public static void Delete(int id)
    {
        var ong = Get(id); 
        if (ong is null)
            return;

        Ongs.Remove(ong); 
    }

    public static void Update(Ong ong)
    {
        var index = Ongs.FindIndex(t => t.Id == ong.Id); 
        if (index == -1)
            return;

        Ongs[index] = ong; 
    }
}
