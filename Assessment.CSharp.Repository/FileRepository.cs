using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class FileRepository : IRepository
{
    public void Creat(int x)
    {
        Console.WriteLine($"Salvo em arquivo {x}");
    }

    public int Read()
    {
        throw new NotImplementedException();
    }

    public List<Paint> ReadLastElements()
    {
        return new List<Paint>();
    }

    public int Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }
}