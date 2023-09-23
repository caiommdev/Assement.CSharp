using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class ListRepository : IRepository
{
    public void Creat(int x)
    {
        Console.WriteLine($"Salvo em lista {x}");
    }

    public int Read()
    {
        throw new NotImplementedException();
    }

    public int Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public List<Paint> ReadLastElements()
    {
        return new List<Paint>();
    }
}